using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class TemplateType : IEntity
    {
        public static TemplateType StagePlan = new TemplateType() { Name="Календарный план" };
        public int Id { get; set; }
        public string Name { get; set; }
    
        public List<Template> Templates { get; set; }
    }
}