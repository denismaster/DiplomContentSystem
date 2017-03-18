using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        private Expression<Func<Teacher, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "fio": return teacher => teacher.FIO;
                case "position": return teacher => teacher.Position.Name;
                case "maxWorkCount": return teacher => teacher.MaxWorkCount;
                default: return teacher => teacher.Id;
            }
        }

        public Dto.ListResponse<TeacherListItem> GetTeachers(TeacherRequest request)
        {
            var queryBuilder = new TeachersRequestBuilder();
            var response = new ListResponse<TeacherListItem>();
            string[] includes = {"Position","Speciality"};
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
            string[] includes = {"Position","Speciality"};
            return _repository.Get(id,includes);
        }

        public bool AddTeacher(TeacherEditItem teacher)
        {
            var dbTeacher = _mapper.Map<Teacher>(teacher);
            _repository.Add(dbTeacher);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateTeacher(TeacherEditItem teacher)
        {
            var dbTeacher = _mapper.Map<Teacher>(teacher);
            _repository.Update(dbTeacher);
            _repository.SaveChanges();
            return true;
        }
    }
}
