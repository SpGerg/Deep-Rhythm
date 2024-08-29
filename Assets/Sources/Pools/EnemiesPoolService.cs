using Services.Interfaces;
using Views;

namespace Pools
{
    public class EnemiesPoolService : PoolBase<EnemyView>, IService
    {
        public EnemiesPoolService(EnemyView enemyView)
        {
            _enemyView = enemyView;
        }

        private readonly EnemyView _enemyView;

        protected override EnemyView Create()
        {
            return UnityEngine.Object.Instantiate(_enemyView);
        }
    }
}
