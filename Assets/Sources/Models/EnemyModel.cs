using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;
using Models.Interfaces;

namespace Models
{
    public abstract class EnemyModel : TransformableModel, IUpdatable
    {
        public static UnityEvent Destroyed { get; } = new();

        public static UnityEvent Completed { get; } = new();

        public EnemyModel(EnemyPresenter presenter, float speed) : base(presenter)
        {
            EnemyPresenter = presenter;
            _speed = speed;
        }

        public EnemyPresenter EnemyPresenter { get; }

        private readonly float _speed;

        public void LateUpdate() { }

        public void Update()
        {
            Translate(new Vector2(0, -(_speed * Time.deltaTime)));
        }
    }
}
