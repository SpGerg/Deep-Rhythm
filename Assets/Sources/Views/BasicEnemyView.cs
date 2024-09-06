using Presenters;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Collider2D))]
    public class BasicEnemyView : EnemyView
    {
        public void Awake()
        {
            InitializeEnemy(new EnemyPresenter(this, Speed));
        }
    }
}
