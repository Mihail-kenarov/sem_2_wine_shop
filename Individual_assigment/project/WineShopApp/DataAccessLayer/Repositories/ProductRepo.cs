using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class ProductRepo : IProductRepo
    {
        public void Create(Product product)
        {
            SqlConnection sqlConnection;

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                // Insert a new row into the Product table
                string productSql = "INSERT INTO Product (Name, Price, Amount, Description) " +
                                    "VALUES (@Name, @Price, @Amount, @Description);" +
                                    "SELECT CAST(SCOPE_IDENTITY() AS int)";
                SqlCommand productCommand = new SqlCommand(productSql, connection);
                productCommand.Parameters.AddWithValue("@Name", product.Name);
                productCommand.Parameters.AddWithValue("@Price", product.Price);
                productCommand.Parameters.AddWithValue("@Amount", product.Amount);
                productCommand.Parameters.AddWithValue("@Description", product.Description);
                int productId = (int)productCommand.ExecuteScalar();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {

                sqlConnection.Open();

                string deleteProductSql = "DELETE FROM Product WHERE product_id = @id;";
                SqlCommand deleteProductCmd = new SqlCommand(deleteProductSql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAll()
        {

            List<Product> products = new List<Product>();
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["product_id"]);
                    int amount = Convert.ToInt32(reader["amount"]);
                    string name = reader["name"].ToString();
                    double price = Convert.ToDouble(reader["price"]);
                    string description = reader["description"].ToString();

                    Product product = new Product(id, amount, name, description, price);
                    products.Add(product);
                }
                sqlConnection.Close();
                reader.Close();
                return products;
            }
        }

        public Product GetById(int product_id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "SELECT * FROM Product WHERE Product.product_id = @id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", product_id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["product_id"]);
                    int amount = Convert.ToInt32(reader["amount"]);
                    string name = reader["name"].ToString();
                    double price = Convert.ToDouble(reader["price"]);
                    string description = reader["description"].ToString();

                    Product product = new Product(id, amount, name, description, price);
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(Product product)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                // Update the Product table
                string productSql = "UPDATE Product SET Name=@Name, Amount=@Amount, Price=@Price, Description=@Description WHERE product_id=@ID";
                SqlCommand productCommand = new SqlCommand(productSql, sqlConnection);
                productCommand.Parameters.AddWithValue("@Name", product.Name);
                productCommand.Parameters.AddWithValue("@Amount", product.Amount);
                productCommand.Parameters.AddWithValue("@Price", product.Price);
                productCommand.Parameters.AddWithValue("@Description", product.Description);
                productCommand.Parameters.AddWithValue("@ID", product.Id);
                productCommand.ExecuteNonQuery();


            }
        }


        public List<Product> GetAllProductsAndWines()
        {
            WineCellerRepo wineCellerRepo = new WineCellerRepo();
            List<Product> products = new List<Product>();
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = @" SELECT p.*,w.*
                                FROM Product p 
                                left JOIN Wine w ON w.ID = p.product_id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["product_id"]);
                    int amount = Convert.ToInt32(reader["amount"]);
                    string name = reader["name"].ToString();
                    double price = Convert.ToDouble(reader["price"]);
                    string description = reader["description"].ToString();


                    if (reader["bottleSize"] != DBNull.Value)
                    {
                        int wineCellerId = Convert.ToInt32(reader["wineCellerID"]);
                        string region = reader["region"].ToString();
                        string classification = reader["classification"].ToString();
                        string sortGrape = reader["sortGrape"].ToString();
                        double alcohol = Convert.ToDouble(reader["alcohol"]);
                        double enjoyableTemp = Convert.ToDouble(reader["enjoyableTemp"]);
                        string photoPath = reader["photoPath"].ToString();
                        int bottleSize = Convert.ToInt32(reader["bottleSize"]);
                        WineCeller wineCeller = wineCellerRepo.GetByIdWineCeller(wineCellerId);

                        Wine wine = new Wine(id, amount, name, price, region, classification, sortGrape, alcohol, enjoyableTemp, bottleSize, wineCeller, photoPath, description);
                        products.Add(wine);

                    }
                    else
                    {
                        Product product = new Product(id, amount, name, description, price);
                        products.Add(product);
                    }

                }
            }
            return products;


        }
    }
}
