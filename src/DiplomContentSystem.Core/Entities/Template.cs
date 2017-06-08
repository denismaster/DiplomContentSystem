using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class Template : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TemplateType TemplateType { get;set;}
        public int TemplateTypeId {get;set;}
        public string FileName {get;set;}
        public string Type => System.IO.Path.GetExtension(FileName);
    }
}