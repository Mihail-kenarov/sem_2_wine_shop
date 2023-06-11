using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class ProductCollectionRepo : IPCRepo
    {
        public void Create(ProductsCollection productsCollection, List<Accessory> accessories, List<Wine> wines)
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
                productCommand.Parameters.AddWithValue("@Name", productsCollection.Name);
                productCommand.Parameters.AddWithValue("@Price", productsCollection.Price);
                productCommand.Parameters.AddWithValue("@Amount", productsCollection.Amount);
                productCommand.Parameters.AddWithValue("@Description", productsCollection.Description);
                int productId = (int)productCommand.ExecuteScalar();

                // Insert a new row into the ProductCollection table
                string enableIdentityInsertSqlPC = "SET IDENTITY_INSERT ProductCollection ON";
                SqlCommand enableIdentityInsertCommandPC = new SqlCommand(enableIdentityInsertSqlPC, connection);
                enableIdentityInsertCommandPC.ExecuteNonQuery();

                string PCSql = "INSERT INTO ProductCollection (Id, Event) " +
                               "VALUES (@ID,@Event)";
                SqlCommand PcCommand = new SqlCommand(PCSql, connection);
                PcCommand.Parameters.AddWithValue("@ID", productId);
                PcCommand.Parameters.AddWithValue("@Event", productsCollection.Event);
                PcCommand.ExecuteNonQuery();

                string disableIdentityInsertSqlPC = "SET IDENTITY_INSERT ProductCollection OFF";
                SqlCommand disableIdentityInsertCommandPC = new SqlCommand(disableIdentityInsertSqlPC, connection);
                disableIdentityInsertCommandPC.ExecuteNonQuery();

                // Enable identity insert for Collection_Product table
                string enableIdentityInsertSql = "SET IDENTITY_INSERT Collection_Product ON";
                SqlCommand enableIdentityInsertCommand = new SqlCommand(enableIdentityInsertSql, connection);
                enableIdentityInsertCommand.ExecuteNonQuery();

                foreach (Accessory accessory in accessories)
                {
                    // Insert a new row into the Collectoin_Product table
                    string accessorySql = "INSERT INTO Collection_Product (Collection_ID, Product_ID) " +
                                          "VALUES (@Collection_id, @Product_id)";
                    SqlCommand accessoryCommand = new SqlCommand(accessorySql, connection);
                    accessoryCommand.Parameters.AddWithValue("@Collection_id", productId);
                    accessoryCommand.Parameters.AddWithValue("@Product_id", accessory.Id);
                    accessoryCommand.ExecuteNonQuery();
                }

                foreach (Wine wine in wines)
                {
                    // Insert a new row into the Collectoin_Product table
                    string wineSql = "INSERT INTO Collection_Product (Collection_ID, Product_ID) " +
                                     "VALUES (@Collection_id, @Product_id)";
                    SqlCommand wineCommand = new SqlCommand(wineSql, connection);
                    wineCommand.Parameters.AddWithValue("@Collection_id", productId);
                    wineCommand.Parameters.AddWithValue("@Product_id", wine.Id);
                    wineCommand.ExecuteNonQuery();
                }

                // Disable identity insert for Collection_Product table
                string disableIdentityInsertSql = "SET IDENTITY_INSERT Collection_Product OFF";
                SqlCommand disableIdentityInsertCommand = new SqlCommand(disableIdentityInsertSql, connection);
                disableIdentityInsertCommand.ExecuteNonQuery();
            }



        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {


                sqlConnection.Open();
                string sql = "delete from Product where product_id=@id";
                SqlCommand deleteProductCmd = new SqlCommand(sql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();


                sqlConnection.Open();
                string deletePCsql = "delete from ProductCollection where Id=@id";
                SqlCommand deleteOCCmd = new SqlCommand(deletePCsql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();

                string deleteCollection_ProductSql = "DELETE FROM Product Collection_Product Collection_ID = @id;";
                SqlCommand deleteCollection_ProductCmd = new SqlCommand(deleteCollection_ProductSql, sqlConnection);
                deleteCollection_ProductCmd.Parameters.AddWithValue("@id", id);
                deleteCollection_ProductCmd.ExecuteNonQuery();

                sqlConnection.Close();

            }
        }

        public List<ProductsCollection> GetAll()
        {
            List<ProductsCollection> productsCollections = new List<ProductsCollection>();
            
            ProductRepo productRepo = new ProductRepo();
            AccessoryRepo accessoryRepo = new AccessoryRepo();
            WineRepo wineRepo = new WineRepo();

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {

                string sql = "SELECT CP.Collection_ID , PC.Event , P.product_id, P.name , P.price, P.description , P.amount " +
                "FROM Collection_Product CP JOIN Product P ON CP.Product_ID = P.product_id " +
                "JOIN ProductCollection PC ON CP.Collection_ID = PC.ID;";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Collection_ID"]);
                    string PCevent = reader["Event"].ToString();
                    int amount = Convert.ToInt32(reader["amount"]);
                    string name = reader["name"].ToString();
                    string description = reader["description"].ToString();
                    double price = Convert.ToDouble(reader["price"]);
                    int productID = Convert.ToInt32(reader["product_id"]);

                    // Move the list declarations here
                    List<Accessory> accessoriesList = new List<Accessory>();
                    List<Wine> wineList = new List<Wine>();

                    foreach (Product product in productRepo.GetAll())
                    {
                        Product neededProduct;
                        neededProduct = accessoryRepo.GetById(productID);
                        if (neededProduct == null)
                        {
                            neededProduct = wineRepo.GetById(productID);
                        }
                        if (neededProduct is Wine)
                        {
                            wineList.Add((Wine)neededProduct);
                        }
                        else
                        {
                            accessoriesList.Add((Accessory)neededProduct);
                        }
                    }

                    ProductsCollection productsCollection = new ProductsCollection(id, amount, name, description, price, accessoriesList, wineList, PCevent);
                    productsCollections.Add(productsCollection);
                }

                reader.Close();
                sqlConnection.Close();

            }
            return productsCollections;
        }

        public ProductsCollection GetById(int id)
        {

                ProductsCollection productCollection = null;
                List<Accessory> accessoriesList = new List<Accessory>();
                List<Wine> wineList = new List<Wine>();

                ProductRepo productRepo = new ProductRepo();
                AccessoryRepo accessoryRepo = new AccessoryRepo();
                WineRepo wineRepo = new WineRepo();

                SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);


                sqlConnection.Open();
                using (sqlConnection)
                {
                    string sql = "SELECT CP.Collection_ID , PC.Event , P.product_id, P.name , P.price, P.description , P.amount " +
                    "FROM Collection_Product CP JOIN Product P ON CP.Products_ID = P.product_id " +
                    "JOIN ProductCollection PC ON CP.Collection_ID = PC.ID;" +
                    "where PC.Id = @id;";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@id", id);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int PCid = Convert.ToInt32(reader["Collection_ID"]);
                        string PCevent = reader["Event"].ToString();
                        int amount = Convert.ToInt32(reader["amount"]);
                        string name = reader["name"].ToString();
                        string description = reader["description"].ToString();
                        double price = Convert.ToDouble(reader["price"]);

                        int productID = Convert.ToInt32(reader["product_id"]);

                        foreach (Product product in productRepo.GetAll())
                        {
                            Product neededProduct;
                            neededProduct = accessoryRepo.GetById(productID);
                            if (neededProduct == null)
                            {
                                neededProduct = wineRepo.GetById(productID);
                            }
                            if (neededProduct is Wine)
                            {
                                wineList.Add((Wine)neededProduct);
                            }
                            else
                            {
                                accessoriesList.Add((Accessory)neededProduct);
                            }
                        }

                        productCollection = new ProductsCollection(PCid, amount, name, description, price, accessoriesList, wineList, PCevent);

                    }
                    reader.Close();
                    sqlConnection.Close();
                    return productCollection;
                }

        }

        public void Update(ProductsCollection productsCollection)
        {
                SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

                using (sqlConnection)
                {
                    sqlConnection.Open();

                    string productSql = "UPDATE Product SET Name=@Name, Amount=@Amount, Price=@Price, Description=@Description WHERE product_id=@ID";
                    SqlCommand productCommand = new SqlCommand(productSql, sqlConnection);
                    productCommand.Parameters.AddWithValue("@Name", productsCollection.Name);
                    productCommand.Parameters.AddWithValue("@Amount", productsCollection.Amount);
                    productCommand.Parameters.AddWithValue("@Price", productsCollection.Price);
                    productCommand.Parameters.AddWithValue("@Description", productsCollection.Description);
                    productCommand.Parameters.AddWithValue("@ID", productsCollection.Id);
                    productCommand.ExecuteNonQuery();


                    // Delete existing entries in the Collection_Product table for the given product collection
                    string deleteSql = "DELETE FROM Collection_Product WHERE Collection_ID = @ProductId";
                    SqlCommand deleteCommand = new SqlCommand(deleteSql, sqlConnection);
                    deleteCommand.Parameters.AddWithValue("@ProductId", productsCollection.Id);
                    deleteCommand.ExecuteNonQuery();

                    foreach (Accessory accessory in productsCollection.Accessories)
                    {
                        string insertSql = "INSERT INTO Collection_Product (Collection_ID, Product_ID) VALUES (@CollectionId, @ProductId)";
                        SqlCommand insertCommand = new SqlCommand(insertSql, sqlConnection);
                        insertCommand.Parameters.AddWithValue("@CollectionId", productsCollection.Id);
                        insertCommand.Parameters.AddWithValue("@ProductId", accessory.Id);
                        insertCommand.ExecuteNonQuery();
                    }

                    // Insert new entries into the Collection_Product table for wines
                    foreach (Wine wine in productsCollection.Wines)
                    {
                        string insertSql = "INSERT INTO Collection_Product (Collection_ID, Product_ID) VALUES (@CollectionId, @ProductId)";
                        SqlCommand insertCommand = new SqlCommand(insertSql, sqlConnection);
                        insertCommand.Parameters.AddWithValue("@CollectionId", productsCollection.Id);
                        insertCommand.Parameters.AddWithValue("@ProductId", wine.Id);
                        insertCommand.ExecuteNonQuery();
                    }
                }
        }
    }
}

