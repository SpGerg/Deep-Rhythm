using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Views.Editor;
using Views.Interfaces;

namespace Presenters
{
    public class EnemyPresenter : PresenterBase
    {
        public EnemyPresenter(EnemyView view, float speed) : base(view)
        {
            View = view;
            Model = new BasicEnemyModel(this, speed);

            base.Model = Model;

            view.InitializeEnemy(this);
            view.InitializeTransformable(this, Model);
        }

        protected new BasicEnemyModel Model { get; }

        protected new EnemyView View { get; } 
    }
}
