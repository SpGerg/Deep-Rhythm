using Presenters.GameEditor;
using System;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class SectionData
    {
        public int id;

        public EnemyData[] enemies;

        [NonSerialized]
        public GameEditorSlotPresenter[] slots;
    }
}
