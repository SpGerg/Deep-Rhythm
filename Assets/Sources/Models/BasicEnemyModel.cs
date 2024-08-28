using Models.Interfaces;
using Presenters;
using UnityEngine;
using UnityEngine.Events;

namespace Models
{
    public class BasicEnemyModel : EnemyModel
    {
        public BasicEnemyModel(EnemyPresenter presenter, float speed) : base(presenter, speed)
        {
        }
    }
}
