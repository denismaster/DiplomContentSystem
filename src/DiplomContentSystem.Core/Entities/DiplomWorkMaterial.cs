using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class DiplomWorkMaterial : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public byte[] Data { get; set; }

        public int AuthorId { get; set; }
        public Student Author { get; set; }

        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }

        public List<GostControlTry> GostControlTries { get; set; }
        public List<DiplomWorkMaterialComment> DiplomWorkMaterialComment { get; set; }
    }
}
