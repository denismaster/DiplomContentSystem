using System;
using System.Linq.Expressions;

namespace DiplomContentSystem.Services
{
    //TODO REDONE WITH BUILDER PATTERN.
    public class RequestBuilder<T> where T : class, Core.IEntity
    {
        private readonly Func<string, Expression<Func<T, object>>> SortingBuilder;
        private readonly Func<string, Expression<Func<T, object>>> FilterBuilder;
        public RequestBuilder<T> UseFilters()
        {
            return null;
        }
        public RequestBuilder<T> UseSortings()
        {
            return null;
        }
        public RequestBuilder<T> UsePaging()
        {
            return null;
        }
    }
}