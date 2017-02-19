﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class SubImplementationStageComment
    {
        public int Id { get; set; }

        public int SubImplementationStageId { get; set; }
        public SubImplementationStage SubImplementationStage { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
