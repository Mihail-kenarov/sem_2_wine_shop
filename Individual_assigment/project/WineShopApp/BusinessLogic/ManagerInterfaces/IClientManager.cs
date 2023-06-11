using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ManagerInterfaces
{
    public interface IClientManager
    {
        void Add(Client client);
        void Update(Client client);
        void Delete(int client_id);
        List<Client> GetAll();
        string Info(Client client);
        Client GetUserById(int client_id);
        Client GetUserByUsername(string username);
        Client? ValidateUser(string username, string password);

    }
}
