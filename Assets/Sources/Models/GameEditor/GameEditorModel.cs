using Models.GameEditor.Datas;
using Presenters;
using Services;
using Services.Databases.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Views.Editor;

namespace Models.GameEditor
{
    public class GameEditorModel : ModelBase
    {
        public GameEditorModel(GameEditorPresenter presenter, GameEditorSlotView[] gameEditorSlots) : base(presenter)
        {
            GameEditorPresenter = presenter;
            _gameEditorSlots = gameEditorSlots;
        }

        public GameEditorPresenter GameEditorPresenter { get; }

        private readonly SortedDictionary<int, SectionData> _sections = new();

        private GameEditorSlotView[] _gameEditorSlots;

        private List<GameEditorSlotView> _currentSectionEnemies = new();

        private int _currentSection;

        public void NextSection()
        {
            var slots = new List<GameEditorSlotView>();
            var enemies = new List<Vector2>();

            foreach (var slot in _currentSectionEnemies)
            {
                slots.Add(slot);
                enemies.Add(slot.WorldPosition.position);
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
            var enemies = new List<Vector2>();

            foreach (var slot in _currentSectionEnemies)
            {
                slots.Add(slot);
                enemies.Add(slot.WorldPosition.position);
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
            var database = GameEditorServiceLocator.Get<IDatabase>();

            var sectionData = new SectionData()
            {
                id = _currentSection,
                enemies = _currentSectionEnemies.Select(enemy => (Vector2)enemy.WorldPosition.position).ToArray()
            };

            if (_sections.TryGetValue(_currentSection, out var section))
            {
                _sections[_currentSection] = sectionData;
            }
            else
            {
                _sections.Add(_currentSection, sectionData);
            }

            database.SaveCustomLevel(new()
            {
                sections = _sections.Select(pair => pair.Value).ToArray()
            });
        }
    }
}
