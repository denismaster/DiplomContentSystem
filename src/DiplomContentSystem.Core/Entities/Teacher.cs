using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Teacher : IEntity
    {
        public int Id { get; set; }
        public string FIO { get; set; }        
        public int MaxWorkCount { get; set; }

        public int PositionId {get;set;}
        public TeacherPosition Position { get; set; }
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<DiplomWork> DiplomWorks { get; set; }
        public List<TeacherComment> TeacherComments { get; set; }
    }
}
