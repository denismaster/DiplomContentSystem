using DiplomContentSystem.Core;
using DiplomContentSystem.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Groups
{
    public class GroupsQueryBuilder : QueryBuilderBase<Group>
    {
        protected override Expression<Func<Group, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return group => group.Name;
                case "speciality": return group => group.Speciality.Name;
                case "department": return group => group.Speciality.Department.Name;
                default: return group => group.Id;
            }
        }

        public override IQueryBuilder<Group> UseFilters()
        {
            var groupsRequest = _requestDto as Dto.GroupRequest;
            var expression  = Services.PredicateBuilder.True<Group>();
            if (!string.IsNullOrEmpty(groupsRequest.Name))
            {
               expression =  expression.And(group => group.Name.Contains(groupsRequest.Name));
            }
            if (groupsRequest.Department > 0)
            {
               expression =  expression.And(group => group.Speciality.Department.Id == groupsRequest.Department);
            }
            _dbQuery.FilterExpression = expression;
            return this;
        }
    }
}
