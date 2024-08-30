using Services.Interfaces;
using Views;
using Views.Interfaces;

namespace Pools
{
    public class EnemiesPoolService : PoolBase<IEnemyView>, IService
    {
        public EnemiesPoolService(EnemyView enemyView)
        {
            _enemyView = enemyView;
        }

        private readonly EnemyView _enemyView;

        protected override IEnemyView Create()
        {
            return UnityEngine.Object.Instantiate(_enemyView);
        }
    }
}
