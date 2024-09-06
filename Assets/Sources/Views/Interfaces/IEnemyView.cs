using Presenters;
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
