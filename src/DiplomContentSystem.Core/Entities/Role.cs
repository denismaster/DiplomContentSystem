using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<UserRole> Users { get; set; }
    }
}