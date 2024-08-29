using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public class ServiceLocator
    {
        private readonly List<IService> _services = new();

        public void Register<T>(T service) where T : IService
        {
            _services.Add(service);
        }

        public void Unregister<T>() where T : IService
        {
            var service = _services.FirstOrDefault(service1 => service1 is T);

            _services.Remove(service);
        }

        public T Get<T>() where T : IService
        {
            return (T)_services.FirstOrDefault(service => service is T);
        }
    }
}