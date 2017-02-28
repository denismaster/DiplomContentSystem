using System;
using System.Linq.Expressions;

namespace DiplomContentSystem.Services
{
    public class RequestBuilder<T> where T : class, Core.IEntity
    {
        private readonly Func<string, Expression<Func<T, object>>> SortingBuilder;
        private readonly Func<string, Expression<Func<T, object>>> FilterBuilder;
        public Core.Request<T> Build(Dto.Request requestDto)
        {
            var request = new Core.Request<T>();
            request.Skip = requestDto.Skip;
            request.Take = requestDto.Take;
            return null;
        }
    }
}