using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ClientRepo : IClientRepo
    {
   
        public void Create(Client client)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();

                string sql = "INSERT INTO dbo.Client (username, email, password, salt, subscribtion) values (@username, @email, @password, @salt, @subscribtion);";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);


                byte[] salt = Encryption.GenerateSalt();
                byte[] password = client.Password;

                cmd.Parameters.AddWithValue("@username", client.Username);
                cmd.Parameters.AddWithValue("@email", client.Email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@subscribtion", client.Subscribtion);
                cmd.ExecuteNonQuery();

                sql = @"
                        Select top (1) ID
                        from Client
                        Order by ID desc
                       ";
                cmd = new SqlCommand(sql, sqlConnection);
                int clientID = (int)cmd.ExecuteScalar();


                sql = @"Insert into [Order]
                                    VALUES (@ClientID, @DateTime, @status , @TotalPrice, @Location)";
                SqlCommand orderCommand = new SqlCommand(sql, sqlConnection);
                orderCommand.Parameters.AddWithValue("@ClientID", clientID);
                orderCommand.Parameters.AddWithValue("@DateTime", DateTime.UtcNow);
                orderCommand.Parameters.AddWithValue("@status", "new");
                orderCommand.Parameters.AddWithValue("@TotalPrice", 0);
                orderCommand.Parameters.AddWithValue("@Location", "Ungiven");
                orderCommand.ExecuteScalar();
                
                sqlConnection.Close();


            }


        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "delete from Client where ID=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select * from Client";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);

                    string username = reader["username"].ToString();
                    string email = reader["email"].ToString();

                    byte[] password = (byte[])reader["password"];
                    byte[] salt = (byte[])reader["salt"]; 

                    string subscribtion = reader["subscribtion"].ToString();

                    Client client = new Client(id, username, email, subscribtion, password, salt);
                    clients.Add(client);

                }
                reader.Close();
                return clients;

            }
        }

        public Client? GetById(int client_id)
        {
            Client? client = null;

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select * from [Client] where ID=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@id", client_id);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);

                    string username = reader["username"].ToString();
                    string email = reader["email"].ToString();

                    byte[] password = (byte[])reader["password"];
                    byte[] salt = (byte[])reader["salt"];

                    string subscribtion = reader["subscribtion"].ToString();

                    client = new Client(id, username, email, subscribtion, password, salt);
                }


                return client;

            }
        }

        public Client GetByUsername(string Username)
        {
            Client? client = null;

            string connectionString = "Server=mssqlstud.fhict.local;Database=dbi509460_iassigment;User Id=dbi509460_iassigment;Password=mk050203; TrustServerCertificate=True";
            string sql = "SELECT * FROM dbo.Client WHERE username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", Username);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            int id = Convert.ToInt32(reader["ID"]);
                            string username = reader["username"].ToString();
                            string email = reader["email"].ToString();
                            byte[] password = (byte[])reader["password"];
                            byte[] salt = (byte[])reader["salt"];
                            string subscribtion = reader["subscribtion"].ToString();

                            client = new Client(id, username, email, subscribtion, password, salt);
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

            return client;
        }






        public void Update(Client client)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Update Client set username=@username,email=@email Where ID=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@id", client.Id);
                cmd.Parameters.AddWithValue("@username", client.Username);
                cmd.Parameters.AddWithValue("@email", client.Email);



                cmd.ExecuteNonQuery();

            }
        }
    }
}
