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
        public Sprite Selected => _selected;

        public Sprite UnSelected => _unSelected;

        internal AcceptorsPresenter AcceptorsPresenter => _acceptorsPresenter;

        [SerializeField]
        private AcceptorView[] _acceptors;

        [SerializeField]
        private Sprite _selected;

        [SerializeField]
        private Sprite _unSelected;

        private AcceptorsPresenter _acceptorsPresenter;

        public void Awake()
        {
            _acceptorsPresenter = new AcceptorsPresenter(this, _acceptors);

            foreach (var acceptor in _acceptors)
            {
                acceptor.InitializeAcceptor(_acceptorsPresenter);
            }

            _acceptorsPresenter.ChooseCenter();

            base.Initialize(_acceptorsPresenter);
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
