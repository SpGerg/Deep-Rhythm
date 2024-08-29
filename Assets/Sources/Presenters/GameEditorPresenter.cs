using Models.GameEditor;
using Views;
using Views.Editor;

namespace Presenters
{
    public class GameEditorPresenter : PresenterBase
    {
        public GameEditorPresenter(GameEditorView view, GameEditorSlotView[] gameEditorSlots) : base(view)
        {
            GameEditorView = view;
            GameEditorModel = new GameEditorModel(this, gameEditorSlots);
        }

        protected GameEditorModel GameEditorModel { get; }

        protected GameEditorView GameEditorView { get; }

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

        public void NextSection()
        {
            GameEditorModel.NextSection();
        }

        public void PreviousSection()
        {
            GameEditorModel.PreviousSection();
        }
    }
}
