using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomContentSystem.Core;

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
        public IEnumerable<Student> GetStudents()
        {
            return _repository.Get();
        }
    }
}
