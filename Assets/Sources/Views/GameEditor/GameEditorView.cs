using Presenters;
using UnityEngine;

namespace Views
{
    public class GameEditorView : ViewBase
    {
        public GameEditorPresenter GameEditorPresenter => _gameEditorPresenter;

        private GameEditorPresenter _gameEditorPresenter;

        public void Awake()
        {
            _gameEditorPresenter = new GameEditorPresenter(this);

            base.Initialize(_gameEditorPresenter);
        }
    }
}
