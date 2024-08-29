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

        public bool IsBusy => _image.enabled;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private GameEditorView _gameEditorView;

        [SerializeField]
        private Transform _worldPosition;

        public void OnSelected()
        {
            _gameEditorView.GameEditorPresenter.OnSelected(this);
        }
    }
}
