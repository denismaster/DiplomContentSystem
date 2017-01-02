using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Student
    {
        public int Id { get; set; }
        public string FIO { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }
    }
}
