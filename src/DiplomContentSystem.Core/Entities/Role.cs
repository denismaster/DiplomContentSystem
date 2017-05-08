using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
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
}