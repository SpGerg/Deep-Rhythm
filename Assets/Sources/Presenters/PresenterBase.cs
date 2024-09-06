using Models.Interfaces;
using Presenters.Interfaces;
using Views.Interfaces;

namespace Presenters
{
    public abstract class PresenterBase : IPresenter
    {
        protected PresenterBase(IView view)
        {
            View = view;
        }

        public IModel Model { get; protected set; }

        public IView View { get; protected set; }
    }
}
