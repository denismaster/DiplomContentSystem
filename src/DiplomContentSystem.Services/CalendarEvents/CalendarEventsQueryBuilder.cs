using DiplomContentSystem.Core;
using DiplomContentSystem.Services;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace DiplomContentSystem.Services.CalendarEvents
{
    public class CalendarEventsQueryBuilder : QueryBuilderBase<CalendarEvent>
    {
        protected override Expression<Func<CalendarEvent, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "name": return event => event.Name;
                case "speciality": return event => event.Speciality.Name;
                case "department": return event => event.Speciality.Department.Name;
                default: return event => event.Id;
            }
        }

        public override IQueryBuilder<CalendarEvent> UseFilters()
        {
            var eventsRequest = _requestDto as Dto.CalendarEventRequest;
            var expression  = Services.PredicateBuilder.True<CalendarEvent>();
            if (!string.IsNullOrEmpty(eventsRequest.Name))
            {
               expression =  expression.And(event => event.Name.Contains(eventsRequest.Name));
            }
            if (eventsRequest.Department > 0)
            {
               expression =  expression.And(event => event.Speciality.Department.Id == eventsRequest.Department);
            }
            _dbQuery.FilterExpression = expression;
            return this;
        }
    }
}
