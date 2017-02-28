using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public interface IRepository<T> where T: class, IEntity
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate,IEnumerable<string> includes = null);
        IEnumerable<T> Get(Request<T> request, IEnumerable<string> includes=null);
        T Get(int id, IEnumerable<string> includes=null);
        long Count(Expression<Func<T,bool>> predicate);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void SaveChanges();
    }
}
