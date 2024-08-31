using Models.GameEditor.Datas;
using Services.Databases.Datas;
using Services.Databases.Enums;
using Services.Databases.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Services.Databases
{
    public class JsonDatabase : IDatabase, IService
    {
        public JsonDatabase()
        {
            _databaseFolder = Path.Combine(Application.persistentDataPath, "database");

            _progress = Path.Combine(_databaseFolder, "progress.json");

            _levelsFolder = Path.Combine(_databaseFolder, "levels");
            _editorLevel = Path.Combine(_levelsFolder, "custom_level.json");

            if (!Directory.Exists(_databaseFolder))
            {
                Directory.CreateDirectory(_databaseFolder);
            }

            if (!Directory.Exists(_levelsFolder))
            {
                Directory.CreateDirectory(_levelsFolder);
            }
        }

        private readonly string _databaseFolder;

        private readonly string _progress;

        private readonly string _levelsFolder;
        private readonly string _editorLevel;

        public void CompleteLevel(LevelType levelType)
        {
            if (!File.Exists(_progress)) 
            {
                var defaultProgress = ProgressData.CreateDefault();
                defaultProgress.CompletedLevels[levelType] = true;

                File.WriteAllText(_progress, JsonUtility.ToJson(defaultProgress));

                return;
            }

            var progress = JsonUtility.FromJson<ProgressData>(File.ReadAllText(_progress));
            progress.CompletedLevels[levelType] = true;

            File.WriteAllText(_progress, JsonUtility.ToJson(progress));
        }

        public LevelData GetLevel(LevelType levelType)
        {
            if (levelType is LevelType.CustomLevel)
            {
                if (!File.Exists(_editorLevel))
                {
                    return null;
                }

                return JsonUtility.FromJson<LevelData>(File.ReadAllText(_editorLevel));
            }

            return JsonUtility.FromJson<LevelData>(((TextAsset)Resources.Load($"Levels\\{levelType}.json")).text);
        }

        public bool IsCompleted(LevelType levelType)
        {
            var progress = JsonUtility.FromJson<ProgressData>(File.ReadAllText(_progress));

            return progress.CompletedLevels[levelType];
        }

        public void SaveCustomLevel(LevelData level)
        {
            File.WriteAllText(_editorLevel, JsonUtility.ToJson(level));
        }
    }
}
