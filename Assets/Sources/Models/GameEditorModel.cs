using Presenters;
using UnityEngine;
using UnityEngine.UI;
using Views.Editor;

namespace Models
{
    public class GameEditorModel : ModelBase
    {
        public GameEditorModel(GameEditorPresenter presenter) : base(presenter)
        {
            GameEditorPresenter = presenter;
        }

        public GameEditorPresenter GameEditorPresenter { get; }

        public void SetEnemy(Image image)
        {
            image.enabled = true;
        }

        public void RemoveEnemy(Image image)
        {
            image.enabled = false;
        }
    }
}
