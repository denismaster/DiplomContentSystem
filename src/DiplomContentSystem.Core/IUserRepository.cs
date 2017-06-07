using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public interface IUserRepository: IRepository<User>
    {
        User GetUser(string login);
        Task<User> GetUserAsync(string login);
    }
}
