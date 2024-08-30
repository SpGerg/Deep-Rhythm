using Models.GameEditor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.GameEditor.Datas
{
    [Serializable]
    public class LevelData
    {
        public SectionData[] sections;

        public MusicType musicType;
    }
}
