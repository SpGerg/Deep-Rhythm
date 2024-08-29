using Presenters;
using UnityEngine;
using Views.Editor;

namespace Views
{
    public class GameEditorView : ViewBase
    {
        public GameEditorPresenter GameEditorPresenter => _gameEditorPresenter;

        [SerializeField]
        private GameEditorSlotView[] _gameEditorSlots;

        private GameEditorPresenter _gameEditorPresenter;

        public void Awake()
        {
            _gameEditorPresenter = new GameEditorPresenter(this, _gameEditorSlots);

            base.Initialize(_gameEditorPresenter);
        }

        public void Play()
        {
            _gameEditorPresenter.Play();
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
