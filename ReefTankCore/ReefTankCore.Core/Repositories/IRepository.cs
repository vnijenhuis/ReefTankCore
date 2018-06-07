using System.Threading.Tasks;

namespace ReefTankCore.Core.Repositories
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
        void SaveAndFlush(T entity);
        void SaveAsync(T entity);
        void AddAsync(T entity);
        void RemoveAsync(T entity);
    }
}