using Models.GameEditor.Enums;
using Presenters.GameEditor;
using System;
using UnityEngine;
using Views.Editor;
using Views.GameEditor;

namespace Views
{
    public class GameEditorView : ViewBase
    {
        [Serializable]
        public class MusicTypeAndAudioClipPair
        {
            public MusicType MusicType { get => _type; }

            public AudioClip AudioClip { get => _audioClip; }

            [SerializeField]
            private MusicType _type;

            [SerializeField]
            private AudioClip _audioClip;
        }

        public GameEditorPresenter GameEditorPresenter => _gameEditorPresenter;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private MusicLineView _musicLineView;

        [SerializeField]
        private MusicTypeAndAudioClipPair[] _audioClips;

        private GameEditorSlotView[] _slots;

        private GameEditorPresenter _gameEditorPresenter;

        public void Start()
        {
            //So long in inspector
            _slots = FindObjectsOfType<GameEditorSlotView>();

            _gameEditorPresenter = new GameEditorPresenter(this, _slots, _audioSource, _musicLineView.MusicLinePresenter, _audioClips);

            base.Initialize(_gameEditorPresenter);
        }

        public void Play()
        {
            _gameEditorPresenter.Play();
        }

        public void PlayMusicPart()
        {
            _gameEditorPresenter.PlayMusicPart();
        }

        public void NextSection()
        {
            GameEditorPresenter.NextSection();
        }

        public void PreviousSection()
        {
            GameEditorPresenter.PreviousSection();
        }
    }
}
