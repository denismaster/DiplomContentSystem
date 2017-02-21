using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class DiplomWorkComment : IEntity
    {
        public int Id { get; set; }

        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
