using System;
using UnityEngine;
using Views.Editor;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class SectionData
    {
        public int id;

        public EnemyData[] enemies;

        [NonSerialized]
        public GameEditorSlotView[] slots;
    }
}
