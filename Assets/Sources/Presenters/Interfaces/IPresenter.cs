using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Interfaces
{
    public interface IPresenter
    {
        IModel Model { get; }

        IView View { get; }
    }
}
