using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class DiplomWorkMaterial : IEntity
    {
        public int Id { get; set; }
        
        public int AuthorId { get; set; }
        public Student Author { get; set; }

        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }

        public int OrderCount { get; set; }
    }
}
