using System;
using System.Collections.Generic;
using System.Linq;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.CalendarEvents
{
    public class CalendarEventService
    {
        private readonly IRepository<CalendarEvent> _repository;
        private readonly IMapper _mapper;

        public CalendarEventService(IRepository<CalendarEvent> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<CalendarEventListItem> GetCalendarEvents(CalendarEventRequest request)
        {
            var queryBuilder = new CalendarEventsQueryBuilder();
            var response = new ListResponse<CalendarEventListItem>();
            string[] includes = {"Speciality", "Speciality.Department","Students"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<CalendarEventListItem>>(_repository.Get(query, includes));

            return response;
        }

        public CalendarEvent Get(int id)
        {   
            string[] includes = {"Speciality","Speciality.Department","Students"};
            var result = _repository.Get(id, includes);
            result.Speciality.Department.Specialities = null;
            return result;
        }

        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

         public bool Add(CalendarEventEditItem CalendarEventDto)
        {
            var dbCalendarEvent = _mapper.Map<CalendarEvent>(CalendarEventDto);
            _repository.Add(dbCalendarEvent);
            _repository.SaveChanges();
            return true;
        }

        public bool Update(CalendarEventEditItem CalendarEventDto)
        {
            var dbCalendarEvent = _mapper.Map<CalendarEvent>(CalendarEventDto);
            _repository.Update(dbCalendarEvent);
            _repository.SaveChanges();
            return true;
        }
    }
}
