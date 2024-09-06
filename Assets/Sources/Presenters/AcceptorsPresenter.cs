using Models;
using UnityEngine;
using Views;
using Views.Acceptors;
using Views.Interfaces;

namespace Presenters
{
    public class AcceptorsPresenter : PresenterBase
    {
        public AcceptorsPresenter(AcceptorsView view,
            AcceptorView[] acceptors) : base(view)
        {
            View = view;
            Model = new AcceptorsModel(this, acceptors);

            base.Model = Model;
        }

        public new AcceptorsView View { get; }
        
        protected new AcceptorsModel Model { get; }

        public void ChooseCenter()
        {
            Model.OnSelectedRight();
        }

        public void OnSelectedLeft()
        {
            Model.OnSelectedLeft();
        }

        public void OnSelectedRight()
        {
            Model.OnSelectedRight();
        }

        public void OnCollisionWithEnemy(AcceptorView acceptorView, Collider2D collider)
        {
            if (!collider.TryGetComponent<IEnemyView>(out var enemyView))
            {
                return;
            }

            if (!acceptorView.IsSelected)
            {
                return;
            }

            Model.OnCollisionWithEnemy(enemyView);
        }
    }
}
