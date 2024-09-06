using Models.GameEditor.Enums;
using UnityEngine;
using UnityEngine.UI;
using Views.Editor;

namespace Presenters.GameEditor
{
    public class GameEditorSlotPresenter : PresenterBase
    {
        public GameEditorSlotPresenter(GameEditorSlotView view) : base(view)
        {
            View = view;
        }

        public Vector2 WorldPosition => View.WorldPosition.position;

        public SideType SideType => View.SideType;

        public int SlotId => View.SlotId;

        public bool IsBusy => View.Image.enabled;

        protected new GameEditorSlotView View { get; }

        public void OnSelected()
        {
            View.OnSelected();
        }

        public void ToggleImage(bool toggle)
        {
            View.Image.enabled = toggle;
        }
    }
}
