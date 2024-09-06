using Presenters.Interfaces;

namespace Models.Interfaces
{
    public interface IModel
    {
        IPresenter Presenter { get; }
    }
}
