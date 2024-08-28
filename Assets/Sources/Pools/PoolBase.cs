using Pools.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pools
{
    public abstract class PoolBase<T> : IPool<T>
    {
        private ConcurrentQueue<T> _pool = new();

        public T Get()
        {
            if (_pool.TryDequeue(out var result))
            {
                return result;
            }

            return Create();
        }

        public void Return(T value)
        {
            _pool.Enqueue(value);
        }

        protected abstract T Create();
    }
}
