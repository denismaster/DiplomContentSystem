using DiplomContentSystem.Core;
using DiplomContentSystem.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.Templates
{
    public class TemplatesQueryBuilder : QueryBuilderBase<Template>
    {
        protected override Expression<Func<Template, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return template => template.Name;
                default: return template => template.Id;
            }
        }

        public override IQueryBuilder<Template> UseFilters()
        {
            var templatesRequest = _requestDto as Dto.TemplateRequest;
            if (!string.IsNullOrEmpty(templatesRequest.Name))
            {
               _dbQuery.FilterExpression =  template => template.Name.Contains(templatesRequest.Name);
            }
            _dbQuery.Take = _dbQuery.Take==0? 10:_dbQuery.Take;
            return this;
        }
    }
}
