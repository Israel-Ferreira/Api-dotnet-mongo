using System.Collections.Generic;
using MinhaApi.Models;

namespace MinhaApi.Services 
{
    public interface IService<T>
    {
        List<T> Get();
        T Get(string id);
        T Create(T entity);
        void Update(string id, T entity);
        void Remove(string id);
    }
}