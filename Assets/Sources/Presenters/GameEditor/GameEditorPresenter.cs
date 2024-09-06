using Models.GameEditor;
using Models.GameEditor.Enums;
using System.Linq;
using UnityEngine;
using Views;
using Views.Editor;

namespace Presenters.GameEditor
{
    public class GameEditorPresenter : PresenterBase
    {
        public GameEditorPresenter(GameEditorView view, GameEditorSlotView[] _slots, AudioSource audioSource, MusicLinePresenter musicLinePresenter, GameEditorView.MusicTypeAndAudioClipPair[] clips) : base(view)
        {
            View = view;
            Model = new GameEditorModel(this, _slots.Select(slot => slot.GameEditorSlotPresenter).ToArray(), audioSource, musicLinePresenter);

            _clips = clips;

            SetMusic(MusicType.BaseAfterBase);
        }

        protected new GameEditorModel Model { get; }

        protected new GameEditorView View { get; }

        private readonly GameEditorView.MusicTypeAndAudioClipPair[] _clips;

        public void OnSelected(GameEditorSlotPresenter gameEditorSlotPresenter)
        {
            if (!gameEditorSlotPresenter.IsBusy)
            {
                Model.SetEnemy(gameEditorSlotPresenter);
            }
            else
            {
                Model.RemoveEnemy(gameEditorSlotPresenter);
            }
        }

        public void Play()
        {
            Model.Play();
        }

        public void PlayMusicPart()
        {
            Model.PlayMusicPart();
        }

        public void NextSection()
        {
            Model.NextSection();
        }

        public void PreviousSection()
        {
            Model.PreviousSection();
        }

        public void SetMusic(MusicType musicType)
        {
            var audioClip = _clips.FirstOrDefault(clip => clip.MusicType == musicType);

            if (audioClip is null)
            {
                return;
            }

            Model.SetAudioClip(audioClip.AudioClip);
        }
    }
}
