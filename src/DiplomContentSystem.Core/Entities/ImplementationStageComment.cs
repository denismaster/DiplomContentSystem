using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class ImplementationStageComment : IEntity
    {
        public int Id { get; set; }

        public int ImplementationStageId { get; set; }
        public ImplementationStage ImplementationStage { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
