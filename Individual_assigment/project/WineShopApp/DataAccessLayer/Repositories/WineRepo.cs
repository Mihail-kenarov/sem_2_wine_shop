using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class WineRepo : ConnectionsString, IWineRepo
    {

        public void Create(Wine wine,WineCeller wineCeller)
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
                productCommand.Parameters.AddWithValue("@Name", wine.Name);
                productCommand.Parameters.AddWithValue("@Price", wine.Price);
                productCommand.Parameters.AddWithValue("@Amount", wine.Amount);
                productCommand.Parameters.AddWithValue("@Description", wine.Description);
                int productId = (int)productCommand.ExecuteScalar();


                string enableIdentityInsertSql = "SET IDENTITY_INSERT Wine ON";
                SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertSql, connection);
                enableIdentityInsertCommand.ExecuteNonQuery();


                // Insert a new row into the Wine table
                string wineSql = "INSERT INTO Wine (ID, region, classification, sortGrape, alcohol, enjoyableTemp, " +
                                 "bottleSize, wineCellerId, photoPath) " +
                                 "VALUES (@ID, @Region, @Classification, @SortGrape, @Alcohol, @EnjoyableTemp, " +
                                 "@BottleSize, @WineCellerId, @PhotoPath)";
                SqlCommand wineCommand = new SqlCommand(wineSql, connection);
                wineCommand.Parameters.AddWithValue("@ID", productId);
                wineCommand.Parameters.AddWithValue("@Region", wine.Region);
                wineCommand.Parameters.AddWithValue("@Classification", wine.Classification);
                wineCommand.Parameters.AddWithValue("@SortGrape", wine.SortGrape);
                wineCommand.Parameters.AddWithValue("@Alcohol", wine.Alcohol);
                wineCommand.Parameters.AddWithValue("@EnjoyableTemp", wine.EnjoyableTemp);
                wineCommand.Parameters.AddWithValue("@BottleSize", wine.BottleSize);
                wineCommand.Parameters.AddWithValue("@WineCellerId", wineCeller.Id);
                wineCommand.Parameters.AddWithValue("@PhotoPath", wine.PhotoPath);
                wineCommand.ExecuteNonQuery();


                string disableIdentityInsertSql = "SET IDENTITY_INSERT Wine OFF";
                SqlCommand disableIdentityInsertCommand = new SqlCommand(disableIdentityInsertSql, connection);
                disableIdentityInsertCommand.ExecuteNonQuery();



            }
        }


        //make sure to have a look at the Amoubnt column that needs to be added
        public List<Wine> GetAll()
        {
            List<Wine> wines = new List<Wine>();
            WineCellerRepo wineCellerRepo = new WineCellerRepo();
            SqlConnection sqlConnection = GetSqlconnection();
            using (sqlConnection)
            {
                string sql = "SELECT * FROM Wine JOIN Product ON Wine.ID = Product.product_id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int wineCellerId = Convert.ToInt32(reader["wineCellerID"]);
                    string region = reader["region"].ToString();
                    string classification = reader["classification"].ToString();
                    string sortGrape = reader["sortGrape"].ToString();
                    double alcohol = Convert.ToDouble(reader["alcohol"]);
                    double enjoyableTemp = Convert.ToDouble(reader["enjoyableTemp"]);
                    int bottleSize = Convert.ToInt32(reader["bottleSize"]);
                    string photoPath = reader["photoPath"].ToString();
                    int amount = Convert.ToInt32(reader["amount"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString(); 

                    WineCeller wineCeller = wineCellerRepo.GetByIdWineCeller(wineCellerId);

                    Wine wine = new Wine(id, amount, name, price, region, classification, sortGrape, alcohol, enjoyableTemp, bottleSize, wineCeller, photoPath, description);
                    wines.Add(wine);
                }
                reader.Close();
                sqlConnection.Close();
                return wines;
            }
        }

        public void Update(Wine wine)
        {

            SqlConnection sqlConnection = GetSqlconnection();

            using (sqlConnection)
            {
                sqlConnection.Open();

                string productSql = "UPDATE Product SET Name=@Name, Amount=@Amount, Price=@Price, Description=@Description WHERE product_id=@ID";
                SqlCommand productCommand = new SqlCommand(productSql, sqlConnection);
                productCommand.Parameters.AddWithValue("@Name", wine.Name);
                productCommand.Parameters.AddWithValue("@Amount", wine.Amount);
                productCommand.Parameters.AddWithValue("@Price", wine.Price);
                productCommand.Parameters.AddWithValue("@Description", wine.Description);
                productCommand.Parameters.AddWithValue("@ID", wine.Id);
                productCommand.ExecuteNonQuery();


                string wineSql = "UPDATE Wine SET region=@Region, classification=@Classification, sortGrape=@SortGrape, " +
                    "alcohol=@Alcohol, enjoyableTemp=@EnjoyableTemp, bottleSize=@BottleSize,photoPath=@Photopath " +
                    "WHERE ID=@ID";
                SqlCommand wineCommand = new SqlCommand(wineSql, sqlConnection);
                wineCommand.Parameters.AddWithValue("@ID", wine.Id);
                wineCommand.Parameters.AddWithValue("@Region", wine.Region);
                wineCommand.Parameters.AddWithValue("@Classification", wine.Classification);
                wineCommand.Parameters.AddWithValue("@SortGrape", wine.SortGrape);
                wineCommand.Parameters.AddWithValue("@Alcohol", wine.Alcohol);
                wineCommand.Parameters.AddWithValue("@EnjoyableTemp", wine.EnjoyableTemp);
                wineCommand.Parameters.AddWithValue("@BottleSize", wine.BottleSize);
                wineCommand.Parameters.AddWithValue("@Photopath", wine.PhotoPath);
                wineCommand.ExecuteNonQuery();
            }


        }


        public void Delete(int id)
        {
            SqlConnection sqlConnection = GetSqlconnection();
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "delete from Wine where ID=@id";
                SqlCommand deleteWineCmd = new SqlCommand(sql, sqlConnection);
                deleteWineCmd.Parameters.AddWithValue("@id", id);
                deleteWineCmd.ExecuteNonQuery();

                string deleteProductSql = "DELETE FROM Product WHERE product_id = @id;";
                SqlCommand deleteProductCmd = new SqlCommand(deleteProductSql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();

                sqlConnection.Close();

            }
        }


        //once again have a look at the amount column
        public Wine GetById(int wine_id)
        {
            Wine wine = null;
            WineCeller wineCeller;
            WineCellerRepo wineCellerRepo = new WineCellerRepo();

            SqlConnection sqlConnection = GetSqlconnection();
            sqlConnection.Open();
            using (sqlConnection)
            {
                string sql = "SELECT * FROM Wine JOIN Product ON Wine.ID = Product.product_id WHERE Accessory.ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@id", wine_id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int wineCellerId = Convert.ToInt32(reader["wineCellerID"]);
                    string region = reader["region"].ToString();
                    string classification = reader["classification"].ToString();
                    string sortGrape = reader["sortGrape"].ToString();
                    double alcohol = Convert.ToDouble(reader["alcohol"]);
                    double enjoyableTemp = Convert.ToDouble(reader["enjoyableTemp"]);
                    int bottleSize = Convert.ToInt32(reader["bottleSize"]);
                    string photoPath = reader["photoPath"].ToString();
                    int amount = Convert.ToInt32(reader["amount"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString();

                    wineCeller = wineCellerRepo.GetByIdWineCeller(wineCellerId);

                    wine = new Wine(id, amount, name, price, region, classification, sortGrape, alcohol, enjoyableTemp, bottleSize, wineCeller, photoPath, description);
                }

                reader.Close();
                sqlConnection.Close();
            }

            return wine;
        }


    }
}

