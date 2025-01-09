using System.Collections.Generic;
using users.Models;

namespace users.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        bool Save(User user);
        void Update(int id, User user);
    }
}
