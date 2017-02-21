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
           _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Entry<T>(item).State = EntityState.Deleted;
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate,IEnumerable<string> includes)
        {
            //if (predicate == null)
            //    throw new ArgumentNullException(nameof(predicate));
            var query = _context.Set<T>().AsNoTracking();
            if(includes!=null)
            {
                foreach(var include in includes)
                query = query.Include(include);
            }
            if(predicate!=null)
            {
                query = query.Where(predicate);
            }
            return query.AsEnumerable();
        }

        public ListResponse<T> Get(Request<T> request)
        {
            var filter = request.FilterExpression;
            var includePaths = new List<string>().ToArray();
            var sortExpression = request.SortExpression;
            IQueryable<T> query = _context.Set<T>();
 
            if (filter != null)
            {
                query = query.Where(filter);
            }
 
            /*if (includePaths != null)
            {
                for (var i = 0; i < includePaths.Count(); i++)
                {
                    query = query.Include(includePaths[i]);
                }
            }*/
 
            if (sortExpression != null)
            {
                IOrderedQueryable<T> orderedQuery = null;
                if (request.SortDirection == SortDirection.Ascending)
                {
                    orderedQuery = query.OrderBy(sortExpression);
                }
                else
                {
                    orderedQuery = query.OrderByDescending(sortExpression);
                }
                if (request.Skip != null)
                {
                    query = orderedQuery.Skip(((int)request.Skip - 1) * (int)request.Take);
                }
            }

            if (request.Take!= null)
            {
                query = query.Take((int)request.Take);
            }
            return null;
        }
        public void Update(T item)
        {
            _context.Entry<T>(item).State = EntityState.Modified;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
