using Models.GameEditor.Enums;
using System;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class LevelData
    {
        public SectionData[] sections;

        public MusicType musicType;
    }
}
