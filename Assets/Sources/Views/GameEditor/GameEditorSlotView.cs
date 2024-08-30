using Models.GameEditor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Editor
{
    public class GameEditorSlotView : ViewBase
    {
        public Image Image => _image;

        public Transform WorldPosition => _worldPosition;

        public SideType SideType => _sideType;

        public bool IsBusy => _image.enabled;

        public int SlotId { get => _slotId; set => _slotId = value; }

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

        public void OnSelected()
        {
            _gameEditorView.GameEditorPresenter.OnSelected(this);
        }
    }
}
