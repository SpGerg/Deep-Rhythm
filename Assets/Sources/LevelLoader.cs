using Models.GameEditor.Datas;
using Models.GameEditor.Enums;
using Pools;
using Services;
using Services.Databases.Enums;
using Services.Databases.Interfaces;
using System;
using System.Linq;
using UnityEngine;
using Views;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private GameEditorView.MusicTypeAndAudioClipPair[] _clips;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private Transform _left;

    [SerializeField]
    private Transform _center;

    [SerializeField]
    private Transform _right;

    private EnemiesPoolService _enemiesPoolService;

    private const float DistanceToAcceptors = 9f;

    private float MusicDelay => DistanceToAcceptors / EnemyView.GlobalSpeed;

    private const float SectionSize = 10f;

    private float _nextSectionYPosition;

    private bool _isPrime;

    public void Start()
    {
        var currentLevel = PlayerPrefs.GetString("level");

        if (!Enum.TryParse<LevelType>(currentLevel, out var levelType))
        {
            Debug.LogError($"Unknown level with {currentLevel} name");

            return;
        }

        var levelData = GameServiceLocator.Get<IDatabase>().GetLevel(levelType);

        _enemiesPoolService = GameServiceLocator.Get<EnemiesPoolService>();

        var audioClip = _clips.FirstOrDefault(clip => clip.MusicType == levelData.musicType);

        if (audioClip == null)
        {
            Debug.LogError($"Unknown song with {levelData.musicType} name");

            return;
        }

        _audioSource.clip = audioClip.AudioClip;
        _audioSource.PlayDelayed(MusicDelay);

        _nextSectionYPosition = SectionSize;

        //In future i will optimize it
        foreach (var section in levelData.sections)
        {
            SpawnSection(section);
        }
    }

    public void SpawnSection(SectionData sectionData)
    {
        foreach (var enemy in sectionData.enemies)
        {
            var instance = _enemiesPoolService.Get();
            instance.GameObject.SetActive(true);

            if (instance is TransformableView transformableView)
            {
                transformableView.SetPosition(new Vector2(GetPositionBySide(enemy.sideType).x, enemy.y + _nextSectionYPosition));
            }

            _isPrime = !_isPrime;
        }

        _nextSectionYPosition += SectionSize;
    }

    private Vector2 GetPositionBySide(SideType side)
    {
        return side switch
        {
            SideType.Left => (Vector2)_left.position,
            SideType.Right => (Vector2)_right.position,
            SideType.Center => (Vector2)_center.position,
            _ => Vector2.zero,
        };
    }
}
