using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class AccessoryRepo : ConnectionsString, IAccessoryRepo
    {

        public void Create(Accessory accessory)
        {
            SqlConnection sqlConnection;

            using (SqlConnection connection = GetSqlconnection())
            {
                connection.Open();

                // Insert a new row into the Product table
                string productSql = "INSERT INTO Product (Name, Price, Amount, Description) " +
                                    "VALUES (@Name, @Price, @Amount, @Description);" +
                                    "SELECT CAST(SCOPE_IDENTITY() AS int)";
                SqlCommand productCommand = new SqlCommand(productSql, connection);
                productCommand.Parameters.AddWithValue("@Name", accessory.Name);
                productCommand.Parameters.AddWithValue("@Price", accessory.Price);
                productCommand.Parameters.AddWithValue("@Amount", accessory.Amount);
                productCommand.Parameters.AddWithValue("@Description", accessory.Description);
                int productId = (int)productCommand.ExecuteScalar();

                string enableIdentityInsertSql = "SET IDENTITY_INSERT Accessory ON";
                SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertSql, connection);
                enableIdentityInsertCommand.ExecuteNonQuery();

           
                string accessorySQL = "INSERT INTO Accessory (ID,type) " +
                                 "VALUES (@ID, @type)";

                SqlCommand accessoryCommand = new SqlCommand(accessorySQL, connection);
                accessoryCommand.Parameters.AddWithValue("@ID", productId);
                accessoryCommand.Parameters.AddWithValue("@type", accessory.Type);
                accessoryCommand.ExecuteNonQuery();


                string disableIdentityInsertSql = "SET IDENTITY_INSERT Accessory OFF";
                SqlCommand disableIdentityInsertCommand = new SqlCommand(disableIdentityInsertSql, connection);
                disableIdentityInsertCommand.ExecuteNonQuery();



                connection.Close();
            }
        }


        public List<Accessory> GetAll()
        {

            List<Accessory> accessories = new List<Accessory>();
            SqlConnection sqlConnection = GetSqlconnection();
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "SELECT * FROM Accessory JOIN Product ON Accessory.ID = Product.product_id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int amount = Convert.ToInt32(reader["amount"]);
                    string name = reader["name"].ToString();
                    double price = Convert.ToDouble(reader["price"]);
                    string description = reader["description"].ToString();
                    string type = reader["type"].ToString();




                    Accessory accessory = new Accessory(id, amount, name, description, price, type);
                    accessories.Add(accessory);
                }
                sqlConnection.Close();
                reader.Close();
                return accessories;
            }
        }


        public void Update(Accessory accessory)
        {
            SqlConnection sqlConnection = GetSqlconnection();

            using (sqlConnection)
            {
                sqlConnection.Open();
                // Update the Product table
                string productSql = "UPDATE Product SET Name=@Name, Amount=@Amount, Price=@Price, Description=@Description WHERE product_id=@ID";
                SqlCommand productCommand = new SqlCommand(productSql, sqlConnection);
                productCommand.Parameters.AddWithValue("@Name", accessory.Name);
                productCommand.Parameters.AddWithValue("@Amount", accessory.Amount);
                productCommand.Parameters.AddWithValue("@Price", accessory.Price);
                productCommand.Parameters.AddWithValue("@Description", accessory.Description);
                productCommand.Parameters.AddWithValue("@ID", accessory.Id);
                productCommand.ExecuteNonQuery();

                // Update the Wine table
                string wineSql = "UPDATE Accessory SET type=@Type WHERE ID=@ID"
                    ;
                SqlCommand wineCommand = new SqlCommand(wineSql, sqlConnection);
                wineCommand.Parameters.AddWithValue("@ID", accessory.Id);
                wineCommand.Parameters.AddWithValue("@Type", accessory.Type);

                wineCommand.ExecuteNonQuery();
            }
        }


        public void Delete(int id)
        {
            SqlConnection sqlConnection = GetSqlconnection();
            using (sqlConnection)
            {

                sqlConnection.Open();

              
                string deleteAccessorySql = "DELETE FROM Accessory WHERE ID = @id;";
                SqlCommand deleteAccessoryCmd = new SqlCommand(deleteAccessorySql, sqlConnection);
                deleteAccessoryCmd.Parameters.AddWithValue("@id", id);
                deleteAccessoryCmd.ExecuteNonQuery();


                string deleteProductSql = "DELETE FROM Product WHERE product_id = @id;";
                SqlCommand deleteProductCmd = new SqlCommand(deleteProductSql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();
            }
        }



        public Accessory GetById(int accessory_id)
        {
            SqlConnection sqlConnection = GetSqlconnection();
            using (sqlConnection)
            {
                string sql = "SELECT * FROM Accessory JOIN Product ON Accessory.ID = Product.product_id WHERE Accessory.ID = @id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", accessory_id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int amount = Convert.ToInt32(reader["Amount"]);
                    string name = reader["Name"].ToString();
                    string type = reader["type"].ToString();
                    double price = Convert.ToDouble(reader["Price"]);
                    string description = reader["Description"].ToString();

                    Accessory accessory = new Accessory(id, amount, name, description, price, type);
                    return accessory;
                }
                else
                {
                    return null;
                }
            }
        }

        public Accessory GetByName(string name)
        {
            SqlConnection sqlConnection = GetSqlconnection();

            using (sqlConnection)
            {
                string sql = "SELECT * FROM Accessory JOIN Product ON Accessory.ID = Product.product_id WHERE Product.Name = @name";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int amount = Convert.ToInt32(reader["Amount"]);
                    string accessoryName = reader["Name"].ToString();
                    double price = Convert.ToDouble(reader["Price"]);
                    string description = reader["Description"].ToString();
                    string type = reader["type"].ToString();

                    Accessory accessory = new Accessory(id, amount, accessoryName, description, price, type);
                    reader.Close();
                    return accessory;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }


    }
}



