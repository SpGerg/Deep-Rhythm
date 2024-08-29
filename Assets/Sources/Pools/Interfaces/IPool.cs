namespace Pools.Interfaces
{
    public interface IPool<T>
    {
        T Get();

        void Return(T value);
    }
}
