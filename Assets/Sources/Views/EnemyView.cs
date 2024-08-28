using Assets.Sources.Views;
using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Views.Interfaces;

namespace Views
{
    public abstract class EnemyView : TransformableView, IEnemyView
    {
        public float Speed => _speed;

        public EnemyPresenter EnemyPresenter => _enemyPresenter;

        public GameObject GameObject => gameObject;

        [SerializeField]
        private float _speed = 5f;

        private EnemyPresenter _enemyPresenter;

        public void InitializeEnemy(EnemyPresenter enemyPresenter)
        {
            _enemyPresenter = enemyPresenter;

            InitializeTransformable(_enemyPresenter, _enemyPresenter.EnemyModel);
        }
    }
}
