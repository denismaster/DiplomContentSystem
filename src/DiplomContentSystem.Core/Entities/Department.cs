using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName {get;set;}

        public int InstituteId { get; set; }
        public Institute Institute { get; set; }
       
        public List<Speciality> Specialities { get; set; }
    }
}