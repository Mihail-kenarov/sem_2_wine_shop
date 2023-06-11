namespace BusinessLogic.Entities
{
    public class User
    {
        private int id;
        private string fullName;
        private string userName;
        private byte[] password;
        private byte[] salt;
        private string role;

        public User(int id, string fullName, string username, byte[] passwordHash, byte[] salt, string role)
        {
            Id = id;
            UserName = username;
            Password = passwordHash;
            Salt = salt;
            Role = role;
            FullName = fullName;
        }

        public User(string fullName, string username, byte[] passwordHash, byte[] salt, string role)
        {
            UserName = username;
            Password = passwordHash;
            Salt = salt;
            Role = role;
            FullName = fullName;
        }

        public User(int id, string fullName, string username, string role)
        {
            Id = id;
            UserName = username;
            Role = role;
            FullName = fullName;
        }



        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); fullName = value; } }
        public string UserName { get => userName; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); userName = value; } }
        public byte[] Password { get => password; set => password = value; }
        public byte[] Salt { get => salt; set => salt = value; }
        public string Role { get => role; set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid validation"); role = value; } }
    }
}
