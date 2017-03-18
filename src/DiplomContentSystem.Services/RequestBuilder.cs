using System;
using System.Linq.Expressions;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;

namespace DiplomContentSystem.Services
{
    public abstract class QueryBuilder<T> : IQueryBuilder<T> where T : class, Core.IEntity
    {
        protected Dto.Request _requestDto;
        protected Query<T> _dbQuery;
        public QueryBuilder()
        {
            _dbQuery = new Query<T>();
        }
        public IQueryBuilder<T> UseDto(Request requestDto)
        {
            if (requestDto == null) throw new ArgumentNullException(nameof(requestDto));
            _requestDto = requestDto;
            return this;
        }
        public virtual IQueryBuilder<T> UseFilters()
        {
            return this;
        }
        public virtual IQueryBuilder<T> UseSortings(string defaultSorting)
        {
            return this;
        }
        public IQueryBuilder<T> UsePaging()
        {
            _dbQuery.Skip = _requestDto.Skip;
            _dbQuery.Take = _requestDto.Take;
            return this;
        }
        public IQueryBuilder<T> UsePaging(int skip, int take)
        {
            _dbQuery.Skip = skip;
            _dbQuery.Take = take;
            return this;
        }

        public Query<T> Build()
        {
            return _dbQuery;
        }        
    }
}