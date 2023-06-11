using BusinessLogic.Entities;
using BusinessLogic.ManagerInterfaces;
using BusinessLogic.RepoInterfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class ClientManager : IClientManager
    {
        private IClientRepo clientRepo;

        public ClientManager(IClientRepo clientRepo)
        {
            this.clientRepo = clientRepo;
        }

        public void Add(Client client)
        {
            clientRepo.Create(client);
        }

        public void Delete(int client_id)
        {
            clientRepo.Delete(client_id);
        }

        public List<Client> GetAll()
        {
            return clientRepo.GetAll();
        }

        public Client GetUserById(int client_id)
        {
            return clientRepo.GetById(client_id);
        }

        public Client GetUserByUsername(string username)
        {
            return clientRepo.GetByUsername(username);
        }

        public string Info(Client client)
        {
            return $"ID: {client.Id}, Name: {client.Username}";
        }

        public void Update(Client client)
        {
            clientRepo.Update(client);
        }

        public Client? ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username is null or empty");
            }

            Client client = clientRepo.GetByUsername(username);

            if (client != null)
            {

                byte[] storedHashedPassword = client.Password;
                byte[] salt = client.Salt;
                bool isValid = Encryption.VerifyPassword(password, salt, storedHashedPassword);


            }
            return client;
        }
    }
}
