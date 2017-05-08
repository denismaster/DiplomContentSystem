using System;
using System.Collections.Generic;
using System.Linq;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Specialities
{
    public class SpecialityService
    {
        private readonly IRepository<Speciality> _repository;
        private readonly IMapper _mapper;

        public SpecialityService(IRepository<Speciality> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<SpecialityListItem> GetSpecialitys(SpecialityRequest request)
        {
            var queryBuilder = new SpecialitysQueryBuilder();
            var response = new ListResponse<SpecialityListItem>();
            string[] includes = {"Department"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<SpecialityListItem>>(_repository.Get(query, includes));

            return response;
        }

        public Speciality Get(int id)
        {   
            string[] includes = {"Department"};
            var result = _repository.Get(id, includes);
            result.Department.Specialities = null;
            return result;
        }

        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

         public bool Add(SpecialityEditItem SpecialityDto)
        {
            var dbSpeciality = _mapper.Map<Speciality>(SpecialityDto);
            _repository.Add(dbSpeciality);
            _repository.SaveChanges();
            return true;
        }

        public bool Update(SpecialityEditItem SpecialityDto)
        {
            var dbSpeciality = _mapper.Map<Speciality>(SpecialityDto);
            _repository.Update(dbSpeciality);
            _repository.SaveChanges();
            return true;
        }
    }
}
