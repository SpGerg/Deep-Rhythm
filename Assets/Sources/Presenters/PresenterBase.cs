using Models.Interfaces;
using Presenters.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views.Interfaces;

namespace Presenters
{
    public abstract class PresenterBase : IPresenter
    {
        protected PresenterBase(IView view)
        {
            View = view;
        }

        public IModel Model { get; }

        public IView View { get; }
    }
}
