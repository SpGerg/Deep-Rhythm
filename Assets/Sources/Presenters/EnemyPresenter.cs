using Models;
using Views;

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
