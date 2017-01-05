using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Request<T> where T : class, IEntity
    {
        public Request(Expression<Func<T,bool>> filterBy, Expression<Func<T, object>> sortBy, SortDirection sortDirection, int? skip, int? take)
        {
            FilterExpression = filterBy;
            SortExpression = sortBy;
            SortDirection = sortDirection;
            Skip = skip;
            Take = take;
        }

        public Expression<Func<T,bool>> FilterExpression { get; set; }
        public Expression<Func<T, object>> SortExpression { get; set; }
        public SortDirection SortDirection { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
