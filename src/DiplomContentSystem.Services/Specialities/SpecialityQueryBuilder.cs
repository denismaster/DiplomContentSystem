using DiplomContentSystem.Core;
using DiplomContentSystem.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Specialities
{
    public class SpecialitysQueryBuilder : QueryBuilderBase<Speciality>
    {
        protected override Expression<Func<Speciality, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return speciality => speciality.Name;
                case "shortName": return speciality => speciality.ShortName;
                case "code": return speciality => speciality.Сode;
                case "department": return speciality => speciality.Department.Name;
                default: return speciality => speciality.Id;
            }
        }

        public override IQueryBuilder<Speciality> UseFilters()
        {
            var specialitysRequest = _requestDto as Dto.SpecialityRequest;
            var expression = Services.PredicateBuilder.True<Speciality>();
            if (!string.IsNullOrEmpty(specialitysRequest.Name))
            {
                expression = expression.And(speciality => speciality.Name.Contains(specialitysRequest.Name));
                expression = expression.Or(speciality => speciality.ShortName.Contains(specialitysRequest.Name));
            }
            if (specialitysRequest.Department > 0)
            {
                expression = expression.And(speciality => speciality.Department.Id == specialitysRequest.Department);
            }
            _dbQuery.FilterExpression = expression;
            return this;
        }
    }
}
