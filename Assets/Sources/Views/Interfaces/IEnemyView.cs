using Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Views.Interfaces
{
    public interface IEnemyView
    {
        float Speed { get; }

        EnemyPresenter EnemyPresenter { get; }

        GameObject GameObject { get; }
    }
}
