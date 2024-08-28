using Models.Interfaces;
using Presenters.Interfaces;

namespace Models
{
    public abstract class ModelBase : IModel
    {
        public ModelBase(IPresenter presenter)
        {
            Presenter = presenter;
        }

        public IPresenter Presenter { get; }
    }
}
