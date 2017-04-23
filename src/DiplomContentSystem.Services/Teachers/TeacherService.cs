using System;
using System.Collections.Generic;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;
namespace DiplomContentSystem.Services.Teachers
{
    public class TeacherService
    {
        private readonly IRepository<Teacher> _repository;
        private readonly IMapper _mapper;

        public TeacherService(IRepository<Teacher> repository, IMapper mapper)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            _repository = repository;
            _mapper = mapper;
            
        }

        public Dto.ListResponse<TeacherListItem> GetTeachers(TeacherRequest request)
        {
            var queryBuilder = new TeachersQueryBuilder();
            var response = new ListResponse<TeacherListItem>();
            string[] includes = {"Position","Department"};

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting:"id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<TeacherListItem>>(_repository.Get(query, includes));

            return response;
        }

        public Teacher Get(int id)
        {   
            string[] includes = {"Position","Department"};
            return _repository.Get(id,includes);
        }

        public bool AddTeacher(TeacherEditItem teacherDto)
        {
            var dbTeacher = _mapper.Map<Teacher>(teacherDto);
            _repository.Add(dbTeacher);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateTeacher(TeacherEditItem teacherDto)
        {
            var dbTeacher = _mapper.Map<Teacher>(teacherDto);
            _repository.Update(dbTeacher);
            _repository.SaveChanges();
            return true;
        }
    }
}
