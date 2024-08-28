using Pools;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views;

namespace Assets.Sources.Pools
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
