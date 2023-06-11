using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IUserManager
    {
        void Add(User user);
        void Update(User user);
        void Delete(int user_id);
        List<User> GetAll();
        string Info(User user);
        User GetUserById(int user_id);
        User GetUserByUsername(string username);
        User? ValidateUser(string username, string password);
    }
}
