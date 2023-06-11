using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Client
    {
        private int id;
        private string username;
        private string email;
        private string subscribtion;
        private byte[] password;
        private byte[] salt;
        private int orderId;

        public Client() { }

        public Client(int id, string username, string email, string subscribtion, byte[] passwordHash, byte[] salt)
        {
            Id = id;
            Username = username;
            Password = passwordHash;
            Salt = salt;
            Subscribtion = subscribtion;
            Email = email;
        }

        public Client(string username, string email, string subscribtion, byte[] passwordHash, byte[] salt)
        {
            Username = username;
            Password = passwordHash;
            Salt = salt;
            Subscribtion = subscribtion;
            Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); username = value; } }
        public string Email { get => email; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); email = value; } }
        public string Subscribtion { get => subscribtion; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); subscribtion = value; } }
        public byte[] Password { get => password; set => password = value; }
        public byte[] Salt { get => salt; set => salt = value; }
        public int OrderId { get => orderId; set => orderId = value; }








    }
}
