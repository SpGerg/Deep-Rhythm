using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views.Interfaces
{
    public interface IView
    {
        IPresenter Presenter { get; }
    }
}
