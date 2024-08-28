using Models.Interfaces;
using Presenters;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Models
{
    public class BasicEnemyModel : TransformableModel, IUpdatable
    {
        public BasicEnemyModel(EnemyPresenter presenter, float speed) : base(presenter)
        {
            EnemyPresenter = presenter;
            _speed = speed;
        }

        public EnemyPresenter EnemyPresenter { get; }

        private float _speed;

        public void LateUpdate() { }

        public void Update()
        {
            Translate(new Vector2(0, _speed * Time.deltaTime));
        }
    }
}
