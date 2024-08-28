using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views.Acceptors;

namespace Views
{
    public class AcceptorsView : ViewBase
    {
        [SerializeField]
        private Acceptor[] _acceptors;

        [SerializeField]
        private Sprite _selected;

        [SerializeField]
        private Sprite _unSelected;

        private AcceptorsPresenter _acceptorsPresenter;

        public void Awake()
        {
            _acceptorsPresenter = new AcceptorsPresenter(this, _acceptors, _selected, _unSelected);

            Initialize(_acceptorsPresenter);
        }

        public void OnSelectedLeft()
        {
            _acceptorsPresenter.OnSelectedLeft();
        }

        public void OnSelectedRight()
        {
            _acceptorsPresenter.OnSelectedRight();
        }
    }
}
