using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class Institute : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<Department> Departments { get; set; }
    }
}
