using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        //если заполнено, то привязана к работе, а не глобально
        public int? DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }
    }
}
