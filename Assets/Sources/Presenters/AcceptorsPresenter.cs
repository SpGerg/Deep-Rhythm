using Models;
using UnityEngine;
using Views;
using Views.Acceptors;

namespace Presenters
{
    public class AcceptorsPresenter : PresenterBase
    {
        public AcceptorsPresenter(AcceptorsView view,
            Acceptor[] acceptors,
            Sprite selected,
            Sprite unSelected) : base(view)
        {
            AcceptorsView = view;
            AcceptorsModel = new AcceptorsModel(this, acceptors, selected, unSelected);
        }

        protected AcceptorsView AcceptorsView { get; }

        protected AcceptorsModel AcceptorsModel { get; }

        public void OnSelectedLeft()
        {
            AcceptorsModel.OnSelectedLeft();
        }

        public void OnSelectedRight()
        {
            AcceptorsModel.OnSelectedRight();
        }
    }
}
