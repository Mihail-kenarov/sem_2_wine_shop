using BusinessLogic.Entities;
using BusinessLogic.Managers;
using DataAccessLayer.Repositories.FakeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class UserManagmentTest
    {
        private FakeUserRepo _userRepo;
        private UserManager _userManager;
        

        [TestInitialize]
        public void Initialise()
        {
            _userRepo = new FakeUserRepo();
            _userManager = new UserManager(_userRepo);
        }


        [TestMethod]
        public void CreateUser()
        {
            // Arrange
            User user = new User(4, "Jane Smith", "jane", new byte[] { }, new byte[] { }, "Employee");

            // Act
            _userManager.Add(user);

            // Assert
            CollectionAssert.Contains(_userRepo.Users, user);
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            int userIdToDelete = 1;

            // Act
            _userManager.Delete(userIdToDelete);

            // Assert
            Assert.IsNull(_userRepo.GetById(userIdToDelete));
        }


        [TestMethod]
        public void GetAllUsers()
        {
            // Act
            List<User> allUsers = _userManager.GetAll();

            // Assert
            Assert.AreEqual(3, allUsers.Count);
            CollectionAssert.AllItemsAreNotNull(allUsers);
        }

        [TestMethod]
        public void GetUserById()
        {
            // Arrange
            int userIdToGet = 1;

            // Act
            User user = _userManager.GetUserById(userIdToGet);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userIdToGet, user.Id);
        }

        [TestMethod]
        public void GetUserByUsername()
        {
            // Arrange
            string usernameToGet = "john";

            // Act
            User user = _userManager.GetUserByUsername(usernameToGet);

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(usernameToGet, user.UserName);
        }

        [TestMethod]
        public void Update_UpdatesUserInList()
        {
            // Arrange
            User userToUpdate = new User(1, "John Doe Jr.", "johnjr", new byte[] { }, new byte[] { }, "CEO");

            // Act
            _userManager.Update(userToUpdate);

            // Assert
            User updatedUser = _userRepo.GetById(userToUpdate.Id);
            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(userToUpdate.FullName, updatedUser.FullName);
            Assert.AreEqual(userToUpdate.UserName, updatedUser.UserName);
            Assert.AreEqual(userToUpdate.Password, updatedUser.Password);
            Assert.AreEqual(userToUpdate.Salt, updatedUser.Salt);
            Assert.AreEqual(userToUpdate.Role, updatedUser.Role);
        }

        [TestMethod]
        public void UserInfo()
        {
            // Arrange
            User user = new User(1, "John Doe", "john ", new byte[] { }, new byte[] { }, "CEO");

            // Act
            string info = _userManager.Info(user);

            // Assert
            Assert.AreEqual("ID: 1, Name: john ", info);
        }





    }
}






