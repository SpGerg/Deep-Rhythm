using System;
using UnityEngine;
using Views.Editor;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class SectionData
    {
        public int id;

        public Vector2[] enemies;

        [NonSerialized]
        public GameEditorSlotView[] slots;
    }
}
