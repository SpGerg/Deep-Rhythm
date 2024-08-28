using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
    public class BasicEnemyView : EnemyView
    {
        public void Awake()
        {
            InitializeEnemy(new EnemyPresenter(this, speed));
        }
    }
}
