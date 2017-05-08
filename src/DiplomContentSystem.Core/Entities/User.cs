using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        
        public List<UserRole> Roles { get; set; }
    }
}
