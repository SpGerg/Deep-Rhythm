using Services.Databases.Interfaces;
using Services.Databases;
using Services.Interfaces;
using System;
using UnityEngine;
using Views;

namespace Services
{
    public class GameEditorServiceLocator : MonoBehaviour
    {
        public static Lazy<ServiceLocator> Instance { get; } = new();

        public static void Register<T>(T service) where T : IService => Instance.Value.Register(service);

        public static void Unregister<T>() where T : IService => Instance.Value.Unregister<T>();

        public static T Get<T>() where T : IService => Instance.Value.Get<T>();

        public void Awake()
        {
            Register<IDatabase>(new JsonDatabase());
        }
    }
}
