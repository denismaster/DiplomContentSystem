using System;

namespace DiplomContentSystem.Dto
{
    public class CalendarEventListItem
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public bool Accepted {get;set;}
    }
}