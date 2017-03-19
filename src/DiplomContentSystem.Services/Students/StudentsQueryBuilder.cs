using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.Services.Students
{
    public class StudentsQueryBuilder : QueryBuilderBase<Student>
    {
        protected override Expression<Func<Student, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "fio": return student => student.FIO;
                case "diplomWork": return student => student.DiplomWork.Name;
                case "group": return student => student.Group.Name;
                default: return student => student.Id;
            }
        }
        public override IQueryBuilder<Student> UseFilters()
        {
            var request = _requestDto as Dto.StudentRequest;
            if (!string.IsNullOrEmpty(request.FIO))
            {
                _dbQuery.FilterExpression = Student => Student.FIO.Contains(request.FIO);
            }
            return this;
        }
    }
}
