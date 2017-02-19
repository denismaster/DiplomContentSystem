using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Speciality : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Сode { get; set; }

        public int InstituteId { get; set; }
        public Institute Institute { get; set; }

        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
    }
}
