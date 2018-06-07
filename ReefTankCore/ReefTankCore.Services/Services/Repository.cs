using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReefTankCore.Core.Repositories;

namespace ReefTankCore.Services.Services
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly IBaseRepository _baseRepository;

        public Repository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public IQueryable<T> Queryable => _baseRepository.Context.Set<T>().AsQueryable();

        public void Add(T entity)
        {
            _baseRepository.Context.Set<T>().Add(entity);
            _baseRepository.Context.SaveChanges();
        }

        public IEnumerable<T> FindAll()
        {
            return _baseRepository.Context.Set<T>().AsEnumerable();
        }

        public T FindBy(object id)
        {
            return _baseRepository.Context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _baseRepository.Context.Set<T>().Remove(entity);
            _baseRepository.Context.SaveChanges();
        }

        public void Save(T entity)
        {
            _baseRepository.Context.Set<T>().Update(entity);
            _baseRepository.Context.SaveChanges();
        }

        public void SaveAndFlush(T entity)
        {
            _baseRepository.Context.Set<T>().Update(entity);
            _baseRepository.Context.SaveChanges();
        }

        public void SaveAsync(T entity)
        {
            _baseRepository.Context.Set<T>().Update(entity);
            _baseRepository.Context.SaveChanges();
        }

        public void AddAsync(T entity)
        {
            _baseRepository.Context.Set<T>().AddAsync(entity);
            _baseRepository.Context.SaveChanges();
        }

        public void RemoveAsync(T entity)
        {
            _baseRepository.Context.Set<T>().Remove(entity);
            _baseRepository.Context.SaveChanges();
        }

        //public IEnumerable<T> FindBy(DetachedCriteria query)
        //{
        //    return _baseRepository.Context.Set<IEnumerable<T>>().Find(query);
        //}

        //public IEnumerable<T> FindBy(DetachedCriteria query, int index, int count)
        //{
        //    return _baseRepository.Context.Set<IEnumerable<T>>().Find(query).ToList().GetRange(index, count);
        //}

        //public T FindFirst(DetachedCriteria query)
        //{
        //    return _baseRepository.Context.Set<T>().Find(query);
        //}

        //public T FindOne(DetachedCriteria query)
        //{
        //    return _baseRepository.Context.Set<T>().Find(query);
        //}

        //public int Count(DetachedCriteria query)
        //{
        //    return _baseRepository.Context.Set<IEnumerable<T>>().Find(query).Count();
        //}
    }
}