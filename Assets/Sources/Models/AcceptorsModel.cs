using Models.Interfaces;
using Presenters;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Views;
using Views.Acceptors;
using Views.Interfaces;

namespace Models
{
    public class AcceptorsModel : ModelBase
    {
        public AcceptorsModel(AcceptorsPresenter presenter,
            AcceptorView[] acceptors) : base(presenter)
        {
            AcceptorsPresenter = presenter;

            _acceptors = acceptors;

            _current = 1;
        }

        public AcceptorsPresenter AcceptorsPresenter { get; }

        public AcceptorView CurrentAcceptor => _acceptors[_current];

        private readonly AcceptorView[] _acceptors;

        private int _current;

        public void OnSelectedLeft()
        {
            CurrentAcceptor.IsSelected = false;

            if (_current - 1 < 0)
            {
                _current = _acceptors.Length - 1;
            }
            else
            {
                _current--;
            }

            CurrentAcceptor.IsSelected = true;
        }

        public void OnSelectedRight()
        {
            CurrentAcceptor.IsSelected = false;

            if (_current + 1 > _acceptors.Length - 1)
            {
                _current = 0;
            }
            else
            {
                _current++;
            }

            CurrentAcceptor.IsSelected = true;
        }

        public void OnCollisionWithEnemy(IEnemyView enemyView)
        {
            UnityEngine.Object.Destroy(enemyView.GameObject);
            EnemyModel.Destroyed.Invoke();
        }
    }
}
