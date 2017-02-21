using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class GostControlTry : IEntity
    {
        public int Id { get; set; }
        public string Сontroller { get; set; }
        public DateTime Date { get; set; }
        public string Discription { get; set; }
        public bool Result { get; set; }

        public int DiplomWorkMaterialId { get; set; }
        public DiplomWorkMaterial DiplomWorkMaterial { get; set; }            
    }
}
