using Presenters;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public abstract class EnemyView : TransformableView, IEnemyView
    {
        public static float GlobalSpeed { get; private set; }

        public float Speed => _speed;

        public EnemyPresenter EnemyPresenter => _enemyPresenter;

        public GameObject GameObject => gameObject;

        [SerializeField]
        private float _speed = 5f;

        private EnemyPresenter _enemyPresenter;

        public void InitializeEnemy(EnemyPresenter enemyPresenter)
        {
            _enemyPresenter = enemyPresenter;

            GlobalSpeed = _speed;

            InitializeTransformable(_enemyPresenter, _enemyPresenter.EnemyModel);
        }
    }
}
