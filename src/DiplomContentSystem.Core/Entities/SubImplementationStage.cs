using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class SubImplementationStage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int ImplementationStageId { get; set; }
        public ImplementationStage ImplementationStage { get; set; }

        public List<SubImplementationStageComment> SubImplementationStageComment { get; set; }
    }
}
