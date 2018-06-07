using System.Collections.Generic;
using System.Linq;

namespace ReefTankCore.Core.Repositories
{
    public interface IReadOnlyRepository<T> where T : IAggregateRoot
    {
        T FindBy(object id);
        IEnumerable<T> FindAll();
        //IEnumerable<T> FindBy(DetachedCriteria query);
        //T FindOne(DetachedCriteria query);
        //IEnumerable<T> FindBy(DetachedCriteria query, int index, int count);
        //T FindFirst(DetachedCriteria query);
        //int Count(DetachedCriteria detachedCriteria);
        IQueryable<T> Queryable { get; }
    }
}