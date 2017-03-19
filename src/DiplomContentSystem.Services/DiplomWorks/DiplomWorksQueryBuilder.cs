using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;

namespace DiplomContentSystem.Services.DiplomWorks
{
    public class DiplomWorksQueryBuilder: QueryBuilderBase<DiplomWork>
    {
        protected override Expression<Func<DiplomWork, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return diplom => diplom.Name;
                case "endDate": return diplom => diplom.EndDate;
                case "startDate": return diplom => diplom.StartDate;
                default: return diplom => diplom.Id;
            }
        }
        public override IQueryBuilder<DiplomWork> UseFilters()
        {
            var request = _requestDto as Dto.DiplomWorkRequest;
            if (!string.IsNullOrEmpty(request.Name))
            {
                this._dbQuery.FilterExpression = DiplomWork => DiplomWork.Name.Contains(request.Name);
            }
            return this;
        }
    }
}
