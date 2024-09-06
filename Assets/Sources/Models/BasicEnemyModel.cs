using Presenters;

namespace Models
{
    public class BasicEnemyModel : EnemyModel
    {
        public BasicEnemyModel(EnemyPresenter presenter, float speed) : base(presenter, speed)
        {
        }
    }
}
