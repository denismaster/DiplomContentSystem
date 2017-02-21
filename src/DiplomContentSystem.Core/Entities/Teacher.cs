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
        //TODO: добавить возможность менять должности и ставить их в зависимости от периода
        public TeacherPosition Position { get; set; }
        //TODO: число дипломников также зависит от периода
        public int MaxWorkCount { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public List<DiplomWork> DiplomWorks { get; set; }
        public List<TeacherComment> TeacherComments { get; set; }
    }
}
