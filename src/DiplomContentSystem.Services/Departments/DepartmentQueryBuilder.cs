using DiplomContentSystem.Core;
using DiplomContentSystem.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Departments
{
    public class DepartmentsQueryBuilder : QueryBuilderBase<Department>
    {
        protected override Expression<Func<Department, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return department => department.Name;
                case "specialities": return department => department.Specialities.Count;
                default: return department => department.Id;
            }
        }

        public override IQueryBuilder<Department> UseFilters()
        {
            var departmentsRequest = _requestDto as Dto.DepartmentRequest;
            var expression  = Services.PredicateBuilder.True<Department>();
            if (!string.IsNullOrEmpty(departmentsRequest.Name))
            {
               expression =  expression.And(department => department.Name.Contains(departmentsRequest.Name));
            }
            _dbQuery.FilterExpression = expression;
            return this;
        }
    }
}
