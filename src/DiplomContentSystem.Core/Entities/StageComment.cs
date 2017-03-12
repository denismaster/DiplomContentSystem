using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class StageComment : IEntity
    {
        public int Id { get; set; }

        public int StageId { get; set; }
        public Stage Stage { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
