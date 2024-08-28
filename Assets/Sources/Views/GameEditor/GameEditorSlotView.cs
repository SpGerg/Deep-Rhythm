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

        [SerializeField]
        private Image _image;

        [SerializeField]
        private GameEditorView _gameEditorView;

        public void OnSelected()
        {
            _gameEditorView.GameEditorPresenter.OnSelected(this);
        }
    }
}
