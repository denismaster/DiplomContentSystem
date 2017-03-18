using DiplomContentSystem.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Teachers
{
    public class TeachersRequestBuilder : QueryBuilder<Teacher>
    {
        private Expression<Func<Teacher, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "fio": return teacher => teacher.FIO;
                case "position": return teacher => teacher.Position.Name;
                case "maxWorkCount": return teacher => teacher.MaxWorkCount;
                default: return teacher => teacher.Id;
            }
        }
        public override QueryBuilder<Teacher> UseFilters()
        {
            var teachersRequest = _requestDto as Dto.TeacherRequest;
            if (!string.IsNullOrEmpty(teachersRequest.FIO))
            {
                _dbQuery.FilterExpression = teacher => teacher.FIO.Contains(teachersRequest.FIO);
            }
            return this;
        }
        public override QueryBuilder<Teacher> UseSortings(string defaultSorting)
        {
            _dbQuery.SortExpressions = new System.Collections.Generic.List<SortExpression<Teacher>>();
            if (_requestDto.Sortings == null || !_requestDto.Sortings.Any())
            {
                _dbQuery.SortExpressions.Add(new SortExpression<Teacher>(GetSortExpression(defaultSorting), SortDirection.Ascending));
            }
            else
            {
                foreach(var sorting in _requestDto.Sortings)
                {
                    _dbQuery.SortExpressions.Add(new SortExpression<Teacher>(GetSortExpression(sorting.FieldName), (SortDirection)sorting.Direction));
                }
            }
            return this;
        }
    }
}
