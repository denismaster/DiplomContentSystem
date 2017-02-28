using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DiplomContentSystem.Core
{
    public class Request<T> where T : class, IEntity
    {
        public Expression<Func<T,bool>> FilterExpression { get; set; }
        public IList<SortExpression<T>> SortExpressions { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
