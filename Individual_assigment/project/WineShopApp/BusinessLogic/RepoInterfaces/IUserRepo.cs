using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IUserRepo
    { 
        void Create(User user);

        List<User> GetAll();

        void Update(User user);

        void Delete(int user_id);

        User GetById(int user_id);

        User GetUsername(string Username);

       

    }
}
