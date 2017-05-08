using System;
using System.Collections.Generic;
using System.Linq;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Departments
{
    public class DepartmentService
    {
        private readonly IRepository<Department> _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<DepartmentListItem> GetDepartments(DepartmentRequest request)
        {
            var queryBuilder = new DepartmentsQueryBuilder();
            var response = new ListResponse<DepartmentListItem>();
            string[] includes = {"Specialities"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<DepartmentListItem>>(_repository.Get(query, includes));

            return response;
        }

        public Department Get(int id)
        {   
            var result = _repository.Get(id);
            return result;
        }

        public IEnumerable<SelectListItem> GetAsSelectList()
        {
            return this._repository.Get().Select(item=>new SelectListItem(){
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

         public bool Add(DepartmentEditItem DepartmentDto)
        {
            var dbDepartment = _mapper.Map<Department>(DepartmentDto);
            _repository.Add(dbDepartment);
            _repository.SaveChanges();
            return true;
        }

        public bool Update(DepartmentEditItem DepartmentDto)
        {
            var dbDepartment = _mapper.Map<Department>(DepartmentDto);
            _repository.Update(dbDepartment);
            _repository.SaveChanges();
            return true;
        }
    }
}
