using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.RepoInterfaces
{
    public interface IClientRepo
    {
        void Create(Client client);

        List<Client> GetAll();

        void Update(Client client);

        void Delete(int id);

        Client GetById(int client_id);

        Client GetByUsername(string Username);
    }
}
