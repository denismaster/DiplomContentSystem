using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class GostControlComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Teacher Controller { get; set; }
        public int? Page { get; set; }
        public int? Row { get; set; }
        public int Type { get; set; }

        public int MaterialId { get; set; }
        public DiplomWorkMaterial Material { get; set; }
    }
}
