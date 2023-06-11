using BusinessLogic.Entities;
using BusinessLogic.RepoInterfaces;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DataAccessLayer.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        IClientRepo _clientRepo;
      

        public OrderRepo(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
            
        }

        public void Create(Order order)
        {
            SqlConnection sqlConnection;

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                //Order table
                string orderSQL = @"Insert into [Order]
                                    VALUES (@ClientID, @DateTime, @status , @TotalPrice, @Location) ";
                SqlCommand orderCommand = new SqlCommand(orderSQL, connection);
                orderCommand.Parameters.AddWithValue("@ClientID", order.Client.Id);
                orderCommand.Parameters.AddWithValue("@DateTime", DateTime.UtcNow) ;
                orderCommand.Parameters.AddWithValue("@status","new");
                orderCommand.Parameters.AddWithValue("@TotalPrice", 0);
                orderCommand.Parameters.AddWithValue("@Location", "Not given");

                orderCommand.ExecuteScalar();


            }
        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {

                sqlConnection.Open();


                string deleteAccessorySql = "DELETE FROM Order WHERE ID = @id;";
                SqlCommand deleteAccessoryCmd = new SqlCommand(deleteAccessorySql, sqlConnection);
                deleteAccessoryCmd.Parameters.AddWithValue("@id", id);
                deleteAccessoryCmd.ExecuteNonQuery();


                string deleteProductSql = "DELETE FROM Order_Product WHERE Order_ID = @id;";
                SqlCommand deleteProductCmd = new SqlCommand(deleteProductSql, sqlConnection);
                deleteProductCmd.Parameters.AddWithValue("@id", id);
                deleteProductCmd.ExecuteNonQuery();
            }
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = "SELECT * FROM [Order]"; // Select all columns from the Order table
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.Id= Convert.ToInt32(reader["ID"]);
                        order.Client = _clientRepo.GetById(Convert.ToInt32(reader["ClientID"])); 
                        order.DateTime = Convert.ToDateTime(reader["DateTime"]);
                        order.Status = Convert.ToString(reader["status"]);
                        order.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
                        order.Location = Convert.ToString(reader["Location"]);

                        // Retrieve the products for the order
                        order.Products = GetProductsForOrder(order.Id); 

                        orders.Add(order);
                    }
                }
            }

            return orders;
        
        }


        public Order GetById(int order_id)
        {
            Order order = null;

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = "SELECT * FROM [Order] WHERE ID = @OrderId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@OrderId", order_id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Order();
                        order.Id = Convert.ToInt32(reader["ID"]);
                        order.Client = _clientRepo.GetById(Convert.ToInt32(reader["ClientID"])); // Assuming you have a method to retrieve the client information
                        order.DateTime = Convert.ToDateTime(reader["DateTime"]);
                        order.Status = Convert.ToString(reader["status"]);
                        order.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);

                        // Retrieve the products for the order
                        order.Products = GetProductsForOrder(order.Id); // Assuming you have a method to retrieve the products for an order
                    }
                }
            }

            return order;
        }

        public void UpdateAsFulFilled(Order order)
        {
            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = "UPDATE [Order] SET status = @Status WHERE ID = @OrderId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Status", "fulfilled");
                command.Parameters.AddWithValue("@OrderId", order.Id);

                command.ExecuteNonQuery();
            }
        }


        public List<Product> GetProductsForOrder(int orderId)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = "SELECT P.* " +
                             "FROM Product P " +
                             "JOIN Order_Product OP ON P.product_id = OP.Product_ID " +
                             "WHERE OP.Order_ID = @OrderId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product;
                        int id = Convert.ToInt32(reader["product_id"]);
                        int amount = Convert.ToInt32(reader["amount"]);
                        string name = Convert.ToString(reader["name"]);
                        double price = Convert.ToDouble(reader["price"]);
                        string description = Convert.ToString(reader["description"]);

                        product = new Product(id, amount, name, description, price);
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        //public Order GetById(int order_id)
        //{
        //    Order order = null;

        //    using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
        //    {
        //        connection.Open();

        //        string sql = "SELECT * FROM [Order] WHERE OrderID = @OrderId";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        command.Parameters.AddWithValue("@OrderId", order_id);

        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                order = new Order();
        //                order.Id = Convert.ToInt32(reader["OrderID"]);
        //                order.Client = _clientRepo.GetById(Convert.ToInt32(reader["ClientID"])); // Assuming you have a method to retrieve the client information
        //                order.DateTime = Convert.ToDateTime(reader["DateTime"]);
        //                order.Status = Convert.ToString(reader["status"]);
        //                order.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);

        //                // Retrieve the products for the order
        //                order.Products = GetProductsForOrder(order.Id); // Assuming you have a method to retrieve the products for an order
        //            }
        //        }
        //    }

        //    return order;
        //}

        public void PutProductToOrder(int product_id,int order_id)
        {
            SqlConnection sqlConnection;

            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();
                string productSql = "Insert into Order_Product(Order_ID,Product_ID)" +
                                   "VALUES (@Order_ID, @Product_ID);";

                SqlCommand orderProductCommand = new SqlCommand(productSql, connection);
                orderProductCommand.Parameters.AddWithValue("@Order_ID", order_id);
                orderProductCommand.Parameters.AddWithValue("@Product_ID",product_id);
                orderProductCommand.ExecuteNonQuery();
            }
        }

        public Order GetOrderByClientID(int client_id)
        {
            Order order = new Order();
            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = @" SELECT *
                                FROM [Order]
                                WHERE ClientID = @ClientID AND status = 'new';";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ClientID", client_id);
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        order.Id = Convert.ToInt32(reader["ID"]);
                        order.Client = _clientRepo.GetById(Convert.ToInt32(reader["ClientID"]));
                        order.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
                        order.Products = GetProductsForOrder(order.Id); 
                    }
                }
            }
            return order;

        }

        public void FinishOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(ConnString.sqlConnStr))
            {
                connection.Open();

                string sql = "UPDATE [Order] SET status = @Status,DateTime = @DateTime,TotalPrice=@TotalPrice,Location=@Location WHERE ID = @OrderId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Status", "finished");
                command.Parameters.AddWithValue("@DateTime",DateTime.UtcNow);
                command.Parameters.AddWithValue("@OrderId", order.Id);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                command.Parameters.AddWithValue("@Location", order.Location);

                command.ExecuteNonQuery();

                

            }
            this.Create(new Order()
            {
                Client = order.Client
            });

        }
    }
}
