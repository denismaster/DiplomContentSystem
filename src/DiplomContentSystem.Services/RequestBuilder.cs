using System;
using System.Linq.Expressions;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;

namespace DiplomContentSystem.Services
{
    public abstract class RequestBuilder<T> : IRequestBuilder<T> where T : class, Core.IEntity
    {
        protected Dto.Request _requestDto;
        protected Request<T> _dbRequest;
        public RequestBuilder()
        {
            _dbRequest = new Request<T>();
        }
        public RequestBuilder<T> UseDto(Request requestDto)
        {
            if (requestDto == null) throw new ArgumentNullException(nameof(requestDto));
            _requestDto = requestDto;
            return this;
        }
        public virtual RequestBuilder<T> UseFilters()
        {
            return this;
        }
        public virtual RequestBuilder<T> UseSortings(string defaultSorting)
        {
            return this;
        }
        public RequestBuilder<T> UsePaging()
        {
            _dbRequest.Skip = _requestDto.Skip;
            _dbRequest.Take = _requestDto.Take;
            return this;
        }
        public RequestBuilder<T> UsePaging(int skip, int take)
        {
            _dbRequest.Skip = skip;
            _dbRequest.Take = take;
            return this;
        }

        public Request<T> Build()
        {
            return _dbRequest;
        }        
    }
}