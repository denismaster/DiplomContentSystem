using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class ImplementationStage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        
        public int DiplomWorkId { get; set; }
        public DiplomWork DiplomWork { get; set; }

        public List<SubImplementationStage> SubImplementationStages { get; set; }
        public List<ImplementationStageComment> ImplementationStageComments { get; set; }
    }
}
