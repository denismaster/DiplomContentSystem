using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, int? skip, int? take);
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
