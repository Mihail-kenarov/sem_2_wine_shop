using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserRepo : IUserRepo
    {
        public void Create(User user)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);


            using (sqlConnection)
            {

                sqlConnection.Open();

                string sql = "INSERT INTO dbo.Workers (fullname, username, password, salt, role) values (@fullName, @userName, @password, @salt, @role);";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);


                byte[] salt = Encryption.GenerateSalt();
                byte[] password = user.Password;

                cmd.Parameters.AddWithValue("@fullname", user.FullName);
                cmd.Parameters.AddWithValue("@userName", user.UserName);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@role", user.Role);


                cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }


        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select * from Workers";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["user_id"]);

                    string fullname = reader["fullname"].ToString();
                    string username = reader["username"].ToString();

                    byte[] password = (byte[])reader["password"];
                    byte[] salt = (byte[])reader["salt"];

                    string role = reader["role"].ToString();

                    User user = new User(id, fullname, username, password, salt, role);
                    users.Add(user);

                }
                reader.Close();
                return users;

            }
        }

        public void Update(User user)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Update Workers set fullname=@fullname,username=@username,role = @role Where user_id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);


                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@fullname", user.FullName);
                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@role", user.Role);


                cmd.ExecuteNonQuery();

            }


        }


        public void Delete(int user_id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "delete from Workers where user_id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", user_id);
                cmd.ExecuteNonQuery();

            }
        }


        public User? GetById(int user_id)
        {
            User? user = null;

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select * Workers where user_id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@id", user_id);

                SqlDataReader reader = cmd.ExecuteReader();


                int id = Convert.ToInt32(reader["user_id"]);

                string fullname = reader["fullname"].ToString();
                string username = reader["username"].ToString();

                byte[] password = (byte[])reader["password"];


                byte[] salt = (byte[])reader["salt"];

                string role = reader["role"].ToString();

                user = new User(id, fullname, username, password, salt, role);


                return user;

            }
        }
        public User? GetUsername(string username)
        {
            User? user = null;

            string connectionString = "Server=mssqlstud.fhict.local;Database=dbi509460_iassigment;User Id=dbi509460_iassigment;Password=mk050203; TrustServerCertificate=True";
            string sql = "SELECT * FROM dbo.Workers WHERE username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            int id = Convert.ToInt32(reader["user_id"]);
                            string fullname = reader["fullname"].ToString();
                            string fetchedUsername = reader["username"].ToString();
                            byte[] password = (byte[])reader["password"];
                            byte[] salt = (byte[])reader["salt"];
                            string role = reader["role"].ToString();

                            user = new User(id, fullname, fetchedUsername, password, salt, role);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions or log the error message
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return user;
        }


        



    }
}
