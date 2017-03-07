using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Dto
{
    public class StudentListItem
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Group { get; set; }
        public string DiplomWork { get; set; }
        public string Teacher { get; set; }
    }
}
