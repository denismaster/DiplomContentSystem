using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
using AutoMapper;

namespace DiplomContentSystem.Services
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
                case "position": return teacher => teacher.TeacherPosition.Name;
                case "maxWorkCount": return teacher => teacher.MaxWorkCount;
                default: return teacher => teacher.Id;
            }
        }

        public Dto.ListResponse<TeacherListItem> GetTeachers(TeacherRequest request)
        {
            var dbRequest = new Request<Teacher>();
            var response = new ListResponse<TeacherListItem>();

            string[] includes = { "TeacherPosition", "Speciality" };
            dbRequest.Skip = request.Skip;
            dbRequest.Take = request.Take;
            if (!string.IsNullOrEmpty(request.FIO))
            {
                dbRequest.FilterExpression = teacher => teacher.FIO.Contains(request.FIO);
            }
            dbRequest.SortExpressions = (request == null || request.Sortings == null) ? null : request.Sortings
                .Select(sorting =>
                {
                    return new SortExpression<Teacher>(GetSortExpression(sorting.FieldName), (SortDirection)sorting.Direction);
                })
                .ToList();
            if(!dbRequest.SortExpressions.Any())
            {
                dbRequest.SortExpressions.Add(new SortExpression<Teacher>(GetSortExpression(""),SortDirection.Ascending));
            }
            response.TotalCount = _repository.Count(dbRequest.FilterExpression);
            response.Items = _mapper.Map<IEnumerable<TeacherListItem>>(_repository.Get(dbRequest, includes));
            return response;
        }

        public Teacher Get(int id)
        {   
            string[] includes = {"TeacherPosition","Speciality"};
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
