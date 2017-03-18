using System;
using System.Linq.Expressions;
using DiplomContentSystem.Core;

namespace DiplomContentSystem.Services
{
    public interface IRequestBuilder<T> where T : class, IEntity
    {
        Request<T> Build();
        RequestBuilder<T> UseFilter();
        RequestBuilder<T> UsePaging(int skip, int take);
        RequestBuilder<T> UseSortings(Func<string, Expression<Func<T, object>>> sortAction);
    }
}