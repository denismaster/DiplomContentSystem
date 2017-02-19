using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class DiplomWorkMaterialComment
    {
        public int Id { get; set; }

        public int DiplomWorkMaterialId { get; set; }
        public DiplomWorkMaterial DiplomWorkMaterial { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
