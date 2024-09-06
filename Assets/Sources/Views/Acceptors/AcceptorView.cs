using Presenters;
using UnityEngine;

namespace Views.Acceptors
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
    public class AcceptorView : ViewBase
    {
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;

                if (_isSelected)
                {
                    _renderer.sprite = _acceptorsPresenter.View.Selected;
                }
                else
                {
                    _renderer.sprite = _acceptorsPresenter.View.UnSelected;
                }
            }
        }

        [SerializeField]
        private SpriteRenderer _renderer;

        private AcceptorsPresenter _acceptorsPresenter;

        private bool _isSelected;

        public void InitializeAcceptor(AcceptorsPresenter acceptorsPresenter)
        {
            _acceptorsPresenter = acceptorsPresenter;

            base.Initialize(_acceptorsPresenter);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            _acceptorsPresenter.OnCollisionWithEnemy(this, collision);
        }
    }
}
