using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
