using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class GostControlTryComment : IEntity
    {
        public int Id { get; set; }

        public int GostControlTryId { get; set; }
        public GostControlTry GostControlTry { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
