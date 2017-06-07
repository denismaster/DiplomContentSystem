using DiplomContentSystem.Core;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Users
{
    public class UsersQueryBuilder : QueryBuilderBase<User>
    {
        protected override Expression<Func<User, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "login": return user => user.Login;
                default: return user => user.Id;
            }
        }
        public override IQueryBuilder<User> UseFilters()
        {
            var usersRequest = _requestDto as Dto.UserRequest;
            if (!string.IsNullOrEmpty(usersRequest.Login))
            {
                _dbQuery.FilterExpression = user => user.Login.Contains(usersRequest.Login);
            }
            return this;
        }
    }
}
