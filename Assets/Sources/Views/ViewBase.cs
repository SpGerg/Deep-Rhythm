using Models.Interfaces;
using Presenters.Interfaces;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public abstract class ViewBase : MonoBehaviour, IView
    {
        public IPresenter Presenter { get; private set; }

        private IUpdatable _updatable;

        public virtual void Initialize(IPresenter presenter)
        {
            Presenter = presenter;

            if (Presenter.Model is IUpdatable updatable)
            {
                _updatable = updatable;
            }
        }

        public virtual void Update()
        {
            _updatable?.Update();
        }

        public virtual void LateUpdate()
        {
            _updatable?.LateUpdate();
        }
    }
}
