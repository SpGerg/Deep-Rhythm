using Models.GameEditor;
using Models.GameEditor.Enums;
using System.Linq;
using UnityEngine;
using Views;
using Views.Editor;
using Views.GameEditor;

namespace Presenters.GameEditor
{
    public class GameEditorPresenter : PresenterBase
    {
        public GameEditorPresenter(GameEditorView view, GameEditorSlotView[] _slots, AudioSource audioSource, MusicLinePresenter musicLinePresenter, GameEditorView.MusicTypeAndAudioClipPair[] clips) : base(view)
        {
            GameEditorView = view;
            GameEditorModel = new GameEditorModel(this, _slots.Select(slot => slot.GameEditorSlotPresenter).ToArray(), audioSource, musicLinePresenter);

            _clips = clips;

            SetMusic(MusicType.BaseAfterBase);
        }

        protected GameEditorModel GameEditorModel { get; }

        protected GameEditorView GameEditorView { get; }

        private readonly GameEditorView.MusicTypeAndAudioClipPair[] _clips;

        public void OnSelected(GameEditorSlotPresenter gameEditorSlotPresenter)
        {
            if (!gameEditorSlotPresenter.IsBusy)
            {
                GameEditorModel.SetEnemy(gameEditorSlotPresenter);
            }
            else
            {
                GameEditorModel.RemoveEnemy(gameEditorSlotPresenter);
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
