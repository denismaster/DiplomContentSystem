using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public interface IRepository<T> where T: class, IEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null);
        ListResponse<T> Get(Request<T> request);
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void SaveChanges();
    }
}
