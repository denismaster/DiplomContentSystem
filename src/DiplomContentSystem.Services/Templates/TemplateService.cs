using System;
using System.Collections.Generic;
using System.Linq;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Templates
{
    public class TemplateService
    {
        private readonly IRepository<Template> _repository;
        private readonly IMapper _mapper;

        public TemplateService(IRepository<Template> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<TemplateListItem> GetTemplates(TemplateRequest request)
        {
            var queryBuilder = new TemplatesQueryBuilder();
            var response = new ListResponse<TemplateListItem>();
            string[] includes = {"TemplateType"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<TemplateListItem>>(_repository.Get(query, includes));

            return response;
        }

        public Template Get(int id)
        {   
            var result = _repository.Get(id);
            return result;
        }
        /*
        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }
        
         public bool Add(TemplateEditItem TemplateDto)
        {
            var dbTemplate = _mapper.Map<Template>(TemplateDto);
            _repository.Add(dbTemplate);
            _repository.SaveChanges();
            return true;
        }

        public bool Update(TemplateEditItem TemplateDto)
        {
            var dbTemplate = _mapper.Map<Template>(TemplateDto);
            _repository.Update(dbTemplate);
            _repository.SaveChanges();
            return true;
        } */
    }
}
