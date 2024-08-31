using Models.GameEditor.Datas;
using Models.GameEditor.Enums;
using Presenters;
using Services;
using Services.Databases.Enums;
using Services.Databases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views.Editor;
using Views.GameEditor;

namespace Models.GameEditor
{
    public class GameEditorModel : ModelBase, IDisposable
    {
        public GameEditorModel(GameEditorPresenter presenter, GameEditorSlotView[] slots, AudioSource audioSource, MusicLineView musicLineView) : base(presenter)
        {
            GameEditorPresenter = presenter;

            _musicLineView = musicLineView;
            _audioSource = audioSource;

            _musicLineView.Ended.AddListener(StopPlayingOnEnded);

            _database = GameEditorServiceLocator.Get<IDatabase>();
            _slots = slots;

            var level = _database.GetLevel(LevelType.CustomLevel);

            if (level is null)
            {
                return;
            }

            var sections = level.sections;

            for (var i = 0;i < sections.Length;i++)
            {
                var section = sections[i];

                var newSection = new SectionData()
                {
                    id = i,
                    enemies = section.enemies,
                    //no idea how to find the right slot optimized.
                    slots = _slots.Where(slot => section.enemies.FirstOrDefault(enemy => enemy.slotId == slot.SlotId) is not null).ToArray()
                };

                _sections.Add(i, newSection);
            }

            LoadSection(_sections[0]);
        }

        public GameEditorPresenter GameEditorPresenter { get; }

        private readonly SortedDictionary<int, SectionData> _sections = new();

        private readonly AudioSource _audioSource;

        private readonly MusicLineView _musicLineView;

        private readonly IDatabase _database;

        private readonly GameEditorSlotView[] _slots;

        private readonly List<GameEditorSlotView> _currentSectionEnemies = new();

        private AudioClip _audioClip;

        private const float SectionTime = 1.6f;

        private const int MainGameSceneId = 0;

        private bool _isDisposed;

        private int _currentSection;

        public void SetAudioClip(AudioClip clip)
        {
            _audioClip = clip;
        }

        public void NextSection()
        {
            var slots = new List<GameEditorSlotView>();
            var enemies = new List<EnemyData>();

            foreach (var slot in _currentSectionEnemies)
            {
                slots.Add(slot);
                enemies.Add(new EnemyData()
                {
                    enemyType = EnemyType.Circle,
                    sideType = slot.SideType,
                    y = slot.WorldPosition.position.y,
                    slotId = slot.SlotId
                });
            }

            foreach (var slot in _currentSectionEnemies.ToArray())
            {
                RemoveEnemy(slot);
            }

            if (_sections.TryGetValue(_currentSection + 1, out var section))
            {
                LoadSection(section);
            }

            var newSection = new SectionData()
            {
                id = _currentSection,
                enemies = enemies.ToArray(),
                slots = slots.ToArray()
            };

            if (_sections.ContainsKey(_currentSection))
            {
                _sections[_currentSection] = newSection;
            }
            else
            {
                _sections.Add(_currentSection, newSection);
            }   

            _currentSection++;
        }

        public void PreviousSection()
        {
            if (_currentSection - 1 < 0)
            {
                return;
            }

            var slots = new List<GameEditorSlotView>();
            var enemies = new List<EnemyData>();

            foreach (var slot in _currentSectionEnemies)
            {
                slots.Add(slot);
                enemies.Add(new EnemyData()
                {
                    enemyType = EnemyType.Circle,
                    sideType = slot.SideType,
                    y = slot.WorldPosition.position.y,
                    slotId = slot.SlotId
                });
            }

            foreach (var slot in _currentSectionEnemies.ToArray())
            {
                RemoveEnemy(slot);
            }

            if (_sections.TryGetValue(_currentSection - 1, out var section))
            {
                LoadSection(section);
            }

            var newSection = new SectionData()
            {
                id = _currentSection,
                enemies = enemies.ToArray(),
                slots = slots.ToArray()
            };

            if (_sections.ContainsKey(_currentSection))
            {
                _sections[_currentSection] = newSection;
            }
            else
            {
                _sections.Add(_currentSection, newSection);
            }

            _currentSection--;
        }

        public void LoadSection(SectionData section)
        {
            foreach (var slot in section.slots)
            {
                SetEnemy(slot);
            }
        }

        public void SetEnemy(GameEditorSlotView gameEditorSlotView)
        {
            gameEditorSlotView.Image.enabled = true;

            _currentSectionEnemies.Add(gameEditorSlotView);
        }

        public void RemoveEnemy(GameEditorSlotView gameEditorSlotView)
        {
            gameEditorSlotView.Image.enabled = false;

            _currentSectionEnemies.Remove(gameEditorSlotView);
        }

        public void Play()
        {
            var sectionData = new SectionData()
            {
                id = _currentSection,
                enemies = _currentSectionEnemies.Select(enemy => new EnemyData()
                {
                    enemyType = EnemyType.Circle,
                    sideType = enemy.SideType,
                    y = enemy.WorldPosition.position.y,
                    slotId = enemy.SlotId
                }).ToArray()
            };

            if (_sections.TryGetValue(_currentSection, out var section))
            {
                _sections[_currentSection] = sectionData;
            }
            else
            {
                _sections.Add(_currentSection, sectionData);
            }

            _database.SaveCustomLevel(new()
            {
                sections = _sections.Select(pair => pair.Value).ToArray()
            });

            PlayerPrefs.SetString("level", LevelType.CustomLevel.ToString());
            SceneManager.LoadScene(MainGameSceneId);
        }

        public void PlayMusicPart()
        {
            _audioSource.clip = _audioClip;
            _audioSource.time = SectionTime * _currentSection;
            _audioSource.Play();

            _musicLineView.IsMove = true;
        }

        private void StopPlayingOnEnded()
        {
            _audioSource.Stop();
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _musicLineView.Ended.RemoveListener(StopPlayingOnEnded);

            _isDisposed = true;
        }
    }
}
