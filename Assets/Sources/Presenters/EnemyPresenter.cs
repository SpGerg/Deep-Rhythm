using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Views.Interfaces;

namespace Presenters
{
    public class EnemyPresenter : PresenterBase
    {
        public EnemyPresenter(EnemyView view, float speed) : base(view)
        {
            EnemyView = view;
            EnemyModel = new BasicEnemyModel(this, speed);
        }

        public BasicEnemyModel EnemyModel { get; }

        protected EnemyView EnemyView { get; } 
    }
}
