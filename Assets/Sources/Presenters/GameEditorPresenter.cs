using Models.GameEditor;
using Models.GameEditor.Enums;
using System.Linq;
using UnityEngine;
using Views;
using Views.Editor;
using Views.GameEditor;

namespace Presenters
{
    public class GameEditorPresenter : PresenterBase
    {
        public GameEditorPresenter(GameEditorView view, GameEditorSlotView[] _slots, AudioSource audioSource, MusicLineView musicLineView, GameEditorView.MusicTypeAndAudioClipPair[] clips) : base(view)
        {
            GameEditorView = view;
            GameEditorModel = new GameEditorModel(this, _slots, audioSource, musicLineView);

            _clips = clips;

            musicLineView.Initialize(this);

            SetMusic(MusicType.BaseAfterBase);
        }

        protected GameEditorModel GameEditorModel { get; }

        protected GameEditorView GameEditorView { get; }

        private readonly GameEditorView.MusicTypeAndAudioClipPair[] _clips;

        public void OnSelected(GameEditorSlotView gameEditorSlotView)
        {
            if (!gameEditorSlotView.IsBusy)
            {
                GameEditorModel.SetEnemy(gameEditorSlotView);
            }
            else
            {
                GameEditorModel.RemoveEnemy(gameEditorSlotView);
            }
        }

        public void Play()
        {
            GameEditorModel.Play();
        }

        public void PlayMusicPart()
        {
            GameEditorModel.PlayMusicPart();
        }

        public void NextSection()
        {
            GameEditorModel.NextSection();
        }

        public void PreviousSection()
        {
            GameEditorModel.PreviousSection();
        }

        public void SetMusic(MusicType musicType)
        {
            var audioClip = _clips.FirstOrDefault(clip => clip.MusicType == musicType);

            if (audioClip is null)
            {
                return;
            }

            GameEditorModel.SetAudioClip(audioClip.AudioClip);
        }
    }
}
