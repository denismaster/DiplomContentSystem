using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Dto
{
    public class StudentRequest: Request
    {
        public string FIO { get; set; }
        public int Position { get; set; }
    }
}
