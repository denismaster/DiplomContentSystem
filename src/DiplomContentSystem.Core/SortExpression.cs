using System;
using System.Linq.Expressions;
namespace DiplomContentSystem.Core
{
    public class SortExpression<TEntity> where TEntity : class
    {
        public SortExpression(Expression<Func<TEntity, object>> sortBy, SortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }
        public Expression<Func<TEntity, object>> SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
