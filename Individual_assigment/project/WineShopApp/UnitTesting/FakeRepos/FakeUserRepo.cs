using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.FakeRepos
{
    public class FakeUserRepo : IUserRepo
    {
        public List<User> Users { get; set; }

        public FakeUserRepo()
        {
            byte[] salt1 = Encryption.GenerateSalt();
            byte[] salt2 = Encryption.GenerateSalt();
            byte[] salt3 = Encryption.GenerateSalt();
            Users = new List<User>
        {
            new User(1, "John Doe", "john", Encryption.HashPassword("john", salt1), salt1, "CEO"),
            new User(2, "Bob Dan", "bob", Encryption.HashPassword("bob", salt2), salt2, "Employee"),
            new User(3, "Eric Anderson", "eric", Encryption.HashPassword("eric", salt3), salt3, "CEO")
        };
        }

        public void Create(User user)
        {
            Users.Add(user);
        }

        public void Delete(int userId)
        {
            User deleteUser = Users.FirstOrDefault(u => u.Id == userId);
            if (deleteUser != null)
            {
                Users.Remove(deleteUser);
            }
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public User GetById(int userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUsername(string username)
        {
            return Users.FirstOrDefault(u => u.UserName == username);
        }

        public void Update(User user)
        {
            User updateUser = Users.FirstOrDefault(u => u.Id == user.Id);
            if (updateUser != null)
            {
                updateUser.FullName = user.FullName;
                updateUser.UserName = user.UserName;
                updateUser.Password = user.Password;
                updateUser.Salt = user.Salt;
                updateUser.Role = user.Role;
            }
        }


    }

}
