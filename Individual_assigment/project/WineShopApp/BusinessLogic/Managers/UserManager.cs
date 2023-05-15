using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
       private IUserRepo userRepository;

        public UserManager(IUserRepo userRepo) 
        {
            this.userRepository = userRepo;
        }
        

        public void Add(User user)
        {
            userRepository.Create(user);
        }

        public void Delete(int user_id)
        {
            userRepository.Delete(user_id);
        }

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetUserById(int user_id)
        {
            return userRepository.GetById(user_id);
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetUsername(username);
        }

        public string Info(User user)
        {
            return $"ID: {user.Id}, Name: {user.UserName}";
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}
