using Models.GameEditor.Datas;
using Services.Databases.Enums;
using Services.Interfaces;

namespace Services.Databases.Interfaces
{
    public interface IDatabase : IService
    {
        void SaveCustomLevel(LevelData level);

        LevelData GetLevel(LevelType levelType);

        void CompleteLevel(LevelType levelType);

        bool IsCompleted(LevelType levelType);
    }
}
