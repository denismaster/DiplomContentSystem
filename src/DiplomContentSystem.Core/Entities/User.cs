using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        
        public List<UserRole> Roles { get; set; }
    }

    public class Role : IEntity
    {
        public static Role Admin = new Role(){Name="Admin"};
        public static Role Owner = new Role(){Name="Owner"};
        public static Role Teacher = new Role(){Name="Teacher"};
        public static Role Student = new Role(){Name="Student"};
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<UserRole> Users { get; set; }
    }
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
