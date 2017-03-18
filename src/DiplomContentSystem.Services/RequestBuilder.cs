using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DiplomContentSystem.Services
{
    //TODO REDONE WITH BUILDER PATTERN.
    public class RequestBuilder<T> where T : class, Core.IEntity
    {
        protected RequestBuilder()
        {

        }
        public static RequestBuilder<T> Create(Dto.Request requestDto)
        {
            return null;
        }
        public RequestBuilder<T> UseFilter()
        {
            return this;
        }
        public RequestBuilder<T> UseSortings(Func<string, Expression<Func<T, object>>> sortAction)
        {
            return this;
        }
        public RequestBuilder<T> UsePaging(int skip, int take)
        {
            return this;
        }
        public Core.Request<T> Build()
        {
            return null;
        }
    }
}