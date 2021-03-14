using System;
namespace Core.CrossCuttingCorcerns.Caching
{
    public interface ICacheService
    {
        void Add(string key, object value, int duration);
        void Remove(string key);
        bool IsAdd(string key);
        void RemoveByPattern(string pattern);
        T Get<T>(string key);
        object Get(string key);
    }
}
