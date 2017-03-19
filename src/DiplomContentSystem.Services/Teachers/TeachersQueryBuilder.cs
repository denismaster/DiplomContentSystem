using DiplomContentSystem.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Teachers
{
    public class TeachersQueryBuilder : QueryBuilderBase<Teacher>
    {
        protected override Expression<Func<Teacher, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "fio": return teacher => teacher.FIO;
                case "position": return teacher => teacher.Position.Name;
                case "maxWorkCount": return teacher => teacher.MaxWorkCount;
                default: return teacher => teacher.Id;
            }
        }
        public override IQueryBuilder<Teacher> UseFilters()
        {
            var teachersRequest = _requestDto as Dto.TeacherRequest;
            if (!string.IsNullOrEmpty(teachersRequest.FIO))
            {
                _dbQuery.FilterExpression = teacher => teacher.FIO.Contains(teachersRequest.FIO);
            }
            return this;
        }
    }
}
