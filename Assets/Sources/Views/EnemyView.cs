using Presenters;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public abstract class EnemyView : TransformableView, IEnemyView
    {
        public static float GlobalSpeed { get; private set; } = 6.5f;

        public float Speed => GlobalSpeed;

        public EnemyPresenter EnemyPresenter => _enemyPresenter;

        public GameObject GameObject => gameObject;

        private EnemyPresenter _enemyPresenter;

        public void InitializeEnemy(EnemyPresenter enemyPresenter)
        {
            _enemyPresenter = enemyPresenter;
        }
    }
}
