using System;
using System.Collections.Generic;
using System.Linq;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Groups
{
    public class GroupService
    {
        private readonly IRepository<Group> _repository;
        private readonly IMapper _mapper;

        public GroupService(IRepository<Group> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<GroupListItem> GetGroups(GroupRequest request)
        {
            var queryBuilder = new GroupsQueryBuilder();
            var response = new ListResponse<GroupListItem>();
            string[] includes = {"Speciality", "Speciality.Department"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<GroupListItem>>(_repository.Get(query, includes));

            return response;
        }

        public Group Get(int id)
        {   
            string[] includes = {"Speciality","Speciality.Department"};
            return _repository.Get(id,includes);
        }

        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

        /* public bool AddGroup(GroupEditItem GroupDto)
        {
            var dbGroup = _mapper.Map<Group>(GroupDto);
            _repository.Add(dbGroup);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateGroup(GroupEditItem GroupDto)
        {
            var dbGroup = _mapper.Map<Group>(GroupDto);
            _repository.Update(dbGroup);
            _repository.SaveChanges();
            return true;
        }*/
    }
}
