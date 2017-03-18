using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Dto
{
    public class DiplomWorkRequest: Request
    {
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
