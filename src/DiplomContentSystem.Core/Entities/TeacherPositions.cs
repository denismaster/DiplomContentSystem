using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class TeacherPosition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}