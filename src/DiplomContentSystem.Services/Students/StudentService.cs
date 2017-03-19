using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
using DiplomContentSystem.Dto;
namespace DiplomContentSystem.Services.Students
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

        public Dto.ListResponse<StudentListItem> GetStudents(StudentRequest request)
        {
            var queryBuilder = new StudentsQueryBuilder();
            var response = new ListResponse<StudentListItem>();

            string[] includes = { "Group", "Teacher","DiplomWork" };

            var query = queryBuilder.UseDto(request)
                                    .UsePaging()
                                    .UseFilters()
                                    .UseSortings(defaultSorting: "id")
                                    .Build();

            response.TotalCount = _repository.Count(query.FilterExpression);
            response.Items = _repository.Get(query, includes).Select(x =>
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
