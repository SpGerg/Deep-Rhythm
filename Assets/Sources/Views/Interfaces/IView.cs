using Presenters.Interfaces;

namespace Views.Interfaces
{
    public interface IView
    {
        IPresenter Presenter { get; }
    }
}
