using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Services
{
    public class TeacherService
    {
        private readonly IRepository<Teacher> _repository;
        public TeacherService(IRepository<Teacher> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            else
                _repository = repository;
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
            var dbRequest = new Request<Teacher>();
            var response = new ListResponse<TeacherListItem>();

            string[] includes = {"Position","Speciality"};
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
            response.Items =  _repository.Get(dbRequest, includes).Select(x =>
                {
                    return new TeacherListItem()
                    {
                        Id = x.Id,
                        FIO = x.FIO,
                        Position = x.Position.Name,
                        Speciality = x.Speciality.ShortName,
                        MaxWorkCount = x.MaxWorkCount
                    };
                });
            return response;
        }

        public Teacher Get(int id)
        {   
            string[] includes = {"Position","Speciality"};
            return _repository.Get(id,includes);
        }

        public bool AddTeacher(Teacher teacher)
        {
            var dbTeacher = new Teacher();
            dbTeacher.FIO = teacher.FIO;
            dbTeacher.PositionId = teacher.PositionId;
            dbTeacher.MaxWorkCount = teacher.MaxWorkCount;
            dbTeacher.SpecialityId = 1;
            _repository.Add(dbTeacher);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            var dbTeacher = new Teacher();
            dbTeacher.Id = teacher.Id;
            dbTeacher.FIO = teacher.FIO;
            dbTeacher.PositionId = teacher.PositionId;
            dbTeacher.MaxWorkCount = teacher.MaxWorkCount;
            dbTeacher.SpecialityId = 1;
            _repository.Update(dbTeacher);
            _repository.SaveChanges();
            return true;
        }
    }
}
