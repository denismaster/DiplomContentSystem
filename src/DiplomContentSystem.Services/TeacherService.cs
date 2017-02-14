﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomContentSystem.Core;
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
        public IEnumerable<Teacher> GetTeachers()
        {
            return _repository.Get();
        }
        public Teacher Get(int id)
        {
            return _repository.Get(id);
        }
        
        public bool AddTeacher(Teacher teacher)
        {
            _repository.Add(teacher);
            _repository.SaveChanges();
            return true;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _repository.Update(teacher);
            _repository.SaveChanges();
            return true;
        }
    }
}
