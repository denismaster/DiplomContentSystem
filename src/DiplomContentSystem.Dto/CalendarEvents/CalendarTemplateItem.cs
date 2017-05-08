using System.Collections.Generic;

namespace DiplomContentSystem.Dto
{
    public class CalendarTemplateStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Accepted { get; set; }
    }
    public class CalendarTemplateItem
    {
        public string Teacher { get; set; }
        public string Student { get; set; }
        public IEnumerable<CalendarTemplateStage> Stages { get; set; }
    }
}