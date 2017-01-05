using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //TODO: Предусмотреть добавление специальностей
        public string Profession { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
