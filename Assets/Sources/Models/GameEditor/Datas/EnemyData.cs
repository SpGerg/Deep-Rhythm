using Models.GameEditor.Enums;
using System;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType enemyType;

        public SideType sideType;

        public float y;

        public float slotId;
    }
}
