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
        private readonly IRepository<ImplementationStage> _globalStagesRepository;
         private readonly IRepository<CustomStage> _customStagesRepository;
        private readonly IMapper _mapper;

        public CalendarEventService(IRepository<ImplementationStage> globalStagesRepository,IRepository<CustomStage> customStagesRepository, IMapper mapper)
        {
            if (globalStagesRepository == null) throw new ArgumentNullException(nameof(globalStagesRepository));
            if (customStagesRepository == null) throw new ArgumentNullException(nameof(customStagesRepository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _globalStagesRepository = globalStagesRepository;
            _customStagesRepository = customStagesRepository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<CalendarEventListItem> GetCalendarEvents(int diplomWorkId)
        {
            //var queryBuilder = new CalendarEventsQueryBuilder();
            var response = new ListResponse<CalendarEventListItem>();
            string[] includes = {"GlobalStage"};

            var globalStages = _globalStagesRepository.Get(stage=>stage.DiplomWorkId==diplomWorkId, includes).OfType<IStage>().ToList();
            var customStages = _customStagesRepository.Get(stage=>stage.DiplomWorkId==diplomWorkId).OfType<IStage>().ToList();

            var stages = globalStages.Union(customStages).ToList();
            response.TotalCount = stages.Count();
            response.Items = _mapper.Map<List<CalendarEventListItem>>(stages);

            return response;
        }

        public Dto.CalendarTemplateItem GetTemplateData(int diplomWorkId)
        {
            var result = new CalendarTemplateItem();
            result.Stages = this.GetCalendarEvents(diplomWorkId).Items.Select(item=>{
                return new CalendarTemplateStage()
                {
                    StartDate = item.StartDate.ToString("dd.MM.yyyy"),
                    EndDate = item.EndDate.ToString("dd.MM.yyyy"),
                    Accepted = item.Accepted,
                    Name = item.Name
                };
            });
            var i = 1;
            foreach(var stage in result.Stages)
            {
                var _i = i;
                stage.Id = _i;
                i++;
            }
            result.Teacher = "Авдеев А.И.";
            result.Student = "Курашин М.А.";

            return result;
        }
       /* public CalendarEvent Get(int id)
        {   
            string[] includes = {"Speciality","Speciality.Department","Students"};
            var result = _repository.Get(id, includes);
            result.Speciality.Department.Specialities = null;
            return result;
        } */

        /* 
        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }
        */

/*         public bool Add(CalendarEventEditItem CalendarEventDto)
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
        }*/
    }
}
