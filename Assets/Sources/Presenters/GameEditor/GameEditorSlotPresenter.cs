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
            GameEditorSlotView = view;
        }

        public Vector2 WorldPosition => GameEditorSlotView.WorldPosition.position;

        public SideType SideType => GameEditorSlotView.SideType;

        public int SlotId => GameEditorSlotView.SlotId;

        public bool IsBusy => GameEditorSlotView.Image.enabled;

        protected GameEditorSlotView GameEditorSlotView { get; }

        public void OnSelected()
        {
            GameEditorSlotView.OnSelected();
        }

        public void ToggleImage(bool toggle)
        {
            GameEditorSlotView.Image.enabled = toggle;
        }
    }
}
