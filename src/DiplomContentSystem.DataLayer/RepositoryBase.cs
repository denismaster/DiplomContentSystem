using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.DataLayer
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DiplomContext _context;

        public RepositoryBase(DiplomContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable();
        }
        public T Get(int id, IEnumerable<string> includes = null)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return query.FirstOrDefault(entity => entity.Id == id);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, IEnumerable<string> includes = null)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return query.Where(predicate).AsEnumerable();
        }

        public long Count(Expression<Func<T, bool>> predicate = null)
        {
            var query = _context.Set<T>().AsNoTracking();
            if (predicate != null)
                query = query.Where(predicate);
            return query.LongCount();
        }

        public IEnumerable<T> Get(Query<T> request, IEnumerable<string> includes = null)
        {
            var result = new PagedEnumerable<T>();
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (request.FilterExpression != null)
            {
                query = query.Where(request.FilterExpression);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            var sortExpressions = request.SortExpressions;
            if (sortExpressions != null && sortExpressions.Any())
            {
                IOrderedQueryable<T> orderedQuery = null;
                for (var i = 0; i < sortExpressions.Count(); i++)
                {
                    if (i == 0)
                    {
                        if (sortExpressions[i].SortDirection == SortDirection.Ascending)
                        {
                            orderedQuery = query.OrderBy(sortExpressions[i].SortBy);
                        }
                        else
                        {
                            orderedQuery = query.OrderByDescending(sortExpressions[i].SortBy);
                        }
                    }
                    else
                    {
                        if (sortExpressions[i].SortDirection == SortDirection.Ascending)
                        {
                            orderedQuery = orderedQuery.ThenBy(sortExpressions[i].SortBy);
                        }
                        else
                        {
                            orderedQuery = orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                        }

                    }
                }
                query = orderedQuery;


            }
            if (request.Skip.HasValue)
            {
                query = query.Skip(request.Skip.Value);
            }
            if (request.Take != null)
            {
                query = query.Take(request.Take.Value);
            }
            return query.AsEnumerable();
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }

        public void Delete(T item)
        {
            _context.Entry<T>(item).State = EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
