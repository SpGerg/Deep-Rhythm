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
            AcceptorsView = view;
            AcceptorsModel = new AcceptorsModel(this, acceptors);

            Model = AcceptorsModel;
        }

        public AcceptorsView AcceptorsView { get; }

        protected AcceptorsModel AcceptorsModel { get; }

        public void ChooseCenter()
        {
            AcceptorsModel.OnSelectedRight();
        }

        public void OnSelectedLeft()
        {
            AcceptorsModel.OnSelectedLeft();
        }

        public void OnSelectedRight()
        {
            AcceptorsModel.OnSelectedRight();
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

            AcceptorsModel.OnCollisionWithEnemy(enemyView);
        }
    }
}
