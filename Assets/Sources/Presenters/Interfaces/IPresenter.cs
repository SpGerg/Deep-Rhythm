using Models.Interfaces;
using Views.Interfaces;

namespace Presenters.Interfaces
{
    public interface IPresenter
    {
        IModel Model { get; }

        IView View { get; }
    }
}
