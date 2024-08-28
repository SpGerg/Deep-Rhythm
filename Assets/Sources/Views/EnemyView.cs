using Assets.Sources.Views;
using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Views
{
    public abstract class EnemyView : TransformableView
    {
        public float speed = 5f;

        private EnemyPresenter _enemyPresenter;

        public void InitializeEnemy(EnemyPresenter enemyPresenter)
        {
            _enemyPresenter = enemyPresenter;

            InitializeTransformable(_enemyPresenter, _enemyPresenter.EnemyModel);
        }
    }
}
