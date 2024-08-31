using Models.GameEditor.Enums;
using Presenters.GameEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Editor
{
    public class GameEditorSlotView : ViewBase
    {
        public GameEditorSlotPresenter GameEditorSlotPresenter => _presenter;

        public Image Image => _image;

        public Transform WorldPosition => _worldPosition;

        public SideType SideType => _sideType;

        public int SlotId => _slotId;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private GameEditorView _gameEditorView;

        [SerializeField]
        private Transform _worldPosition;

        [SerializeField]
        private int _slotId;

        [SerializeField]
        private SideType _sideType;

        private GameEditorSlotPresenter _presenter;

        public void Awake()
        {
            _presenter = new GameEditorSlotPresenter(this);

            Initialize(_presenter);
        }

        public void OnSelected()
        {
            _gameEditorView.GameEditorPresenter.OnSelected(_presenter);
        }
    }
}
