using Presenters;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views.Acceptors;

namespace Models
{
    public class AcceptorsModel : ModelBase
    {
        public AcceptorsModel(AcceptorsPresenter presenter,
            Acceptor[] acceptors,
            Sprite selected,
            Sprite unSelected) : base(presenter)
        {
            AcceptorsPresenter = presenter;

            _acceptors = acceptors;
            _selected = selected;
            _unSelected = unSelected;

            _current = 1;

            SelectAcceptor();
        }

        public AcceptorsPresenter AcceptorsPresenter { get; }

        public Acceptor CurrentAcceptor => _acceptors[_current];

        private Acceptor[] _acceptors;

        private Sprite _selected;

        private Sprite _unSelected;

        private int _current;

        public void OnSelectedLeft()
        {
            UnSelectAcceptor();

            if (_current - 1 < 0)
            {
                _current = _acceptors.Length - 1;
            }
            else
            {
                _current--;
            }

            SelectAcceptor();
        }

        public void OnSelectedRight()
        {
            UnSelectAcceptor();

            if (_current + 1 > _acceptors.Length - 1)
            {
                _current = 0;
            }
            else
            {
                _current++;
            }

            SelectAcceptor();
        }

        public bool IsSelected(GameObject target)
        {
            for (var i = 0; i < _acceptors.Length; i++)
            {
                var acceptor = _acceptors[i];

                if (acceptor != target)
                {
                    continue;
                }

                if (i != _current)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        private void UnSelectAcceptor()
        {
            CurrentAcceptor.Renderer.sprite = _unSelected;
        }

        private void SelectAcceptor()
        {
            CurrentAcceptor.Renderer.sprite = _selected;
        }
    }
}
