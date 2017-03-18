using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem
{
    public class DiplomWorkListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public int? TeacherId {get;set;}
        public string Teacher { get; set; }
        public int? StudentId { get; set; }
        public string Student { get; set; }
    }
}
