using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class GostControlTrying
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }

        public DateTime Date { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
