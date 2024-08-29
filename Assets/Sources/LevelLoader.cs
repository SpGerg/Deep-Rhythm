using Services;
using Services.Databases.Enums;
using Services.Databases.Interfaces;
using UnityEngine;
using Views;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private EnemyView _enemyView;

    public void Awake()
    {
        var levelData = GameServiceLocator.Get<IDatabase>().GetLevel(LevelType.CustomLevel);

        foreach (var section in levelData.sections)
        {

        }
    }
}
