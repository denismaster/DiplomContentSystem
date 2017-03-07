using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Services
{
    public class StudentService
    {
        private readonly IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            else
                _repository = repository;
        }

        private Expression<Func<Student, object>> GetSortExpression(string sortFieldName)
        {
            switch (sortFieldName)
            {
                case "fio": return Student => Student.FIO;
                case "diplomWork": return Student => Student.DiplomWork.Name;
                case "group": return Student => Student.Group.Name;
                default: return Student => Student.Id;
            }
        }

        public Dto.ListResponse<StudentListItem> GetStudents(StudentRequest request)
        {
            var dbRequest = new Request<Student>();
            var response = new ListResponse<StudentListItem>();

            string[] includes = { "Group", "Teacher","DiplomWork" };
            dbRequest.Skip = request.Skip;
            dbRequest.Take = request.Take;
            if (!string.IsNullOrEmpty(request.FIO))
            {
                dbRequest.FilterExpression = Student => Student.FIO.Contains(request.FIO);
            }
            dbRequest.SortExpressions = (request == null || request.Sortings == null) ? null : request.Sortings
                .Select(sorting =>
                {
                    return new SortExpression<Student>(GetSortExpression(sorting.FieldName), (SortDirection)sorting.Direction);
                })
                .ToList();
            if (!dbRequest.SortExpressions.Any())
            {
                dbRequest.SortExpressions.Add(new SortExpression<Student>(GetSortExpression(""), SortDirection.Ascending));
            }
            response.TotalCount = _repository.Count(dbRequest.FilterExpression);
            response.Items = _repository.Get(dbRequest, includes).Select(x =>
            {
                return new StudentListItem()
                {
                    Id = x.Id,
                    FIO = x.FIO,
                    Group = x.Group?.Name ?? "",
                    DiplomWork = x.DiplomWork?.Name??"",
                    DiplomWorkId = x.DiplomWorkId,
                    Teacher = x.Teacher?.FIO??"",
                    TeacherId = x.TeacherId
                };
            });
            return response;
        }

        public Student Get(int id)
        {
            string[] includes = { "Position", "Speciality" };
            return _repository.Get(id, includes);
        }

        public bool AddStudent(Student Student)
        {
            var dbStudent = new Student();
            dbStudent.FIO = Student.FIO;
           // dbStudent.PositionId = Student.PositionId;
           // dbStudent.MaxWorkCount = Student.MaxWorkCount;
           // dbStudent.SpecialityId = 1;
            _repository.Add(dbStudent);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateStudent(Student Student)
        {
            var dbStudent = new Student();
            dbStudent.Id = Student.Id;
            dbStudent.FIO = Student.FIO;
          //  dbStudent.PositionId = Student.PositionId;
           // dbStudent.MaxWorkCount = Student.MaxWorkCount;
          //  dbStudent.SpecialityId = 1;
            _repository.Update(dbStudent);
            _repository.SaveChanges();
            return true;
        }
    }
}
