using Services.Databases.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Databases.Datas
{
    public class ProgressData
    {
        public Dictionary<LevelType, bool> CompletedLevels { get; set; }

        public static ProgressData CreateDefault()
        {
            var levels = new Dictionary<LevelType, bool>();

            foreach (var levelType in Enum.GetValues(typeof(LevelType)).Cast<LevelType>())
            {
                if (levelType is LevelType.CustomLevel)
                {
                    continue;
                }

                levels[levelType] = false;
            }

            return new ProgressData()
            {
                CompletedLevels = levels
            };
        }
    }
}
