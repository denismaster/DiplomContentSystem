using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.DataLayer
{
    public class RepositoryBase<T> : IRepository<T> where T: class, IEntity
    {
        private readonly DiplomContext _context;

        public RepositoryBase(DiplomContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _context.Set<T>().AsNoTracking().Where(predicate).AsEnumerable();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
