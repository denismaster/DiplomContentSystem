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
        public int MaxWorkCount { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int PeriodId { get; set; }
        public Period Period { get; set; }
    }
}