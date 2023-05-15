namespace BusinessLogic.Entities
{
    public class User
    {
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

        public User(int id,string fullName, string username, string role)
        {
            Id = id;
            UserName = username;
            Role = role;
            FullName = fullName;
        }



        public int Id { get; set; }
        public string FullName { get;  set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
    }
}
