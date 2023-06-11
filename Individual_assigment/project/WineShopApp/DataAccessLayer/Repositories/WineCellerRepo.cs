using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Repositories
{
    public class WineCellerRepo : IWineCellerRepo
    {
        public void Create(WineCeller wineCeller)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);


            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Insert into WineCeller (name, yearCreated, wineStyle, email, region, country)" +
                    " values (@Name, @YearCreated, @WineStyle, @Email, @Region, @Country)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Name", wineCeller.Name);
                cmd.Parameters.AddWithValue("@YearCreated", wineCeller.YearCreated);
                cmd.Parameters.AddWithValue("@WineStyle", wineCeller.WineStyle);
                cmd.Parameters.AddWithValue("@Email", wineCeller.Email);
                cmd.Parameters.AddWithValue("@Region", wineCeller.Region);
                cmd.Parameters.AddWithValue("@Country", wineCeller.Country);


                cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }

        public List<WineCeller> GetAll()
        {

            List<WineCeller> winesCellers = new List<WineCeller>();
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select  * from WineCeller";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int wc_id = Convert.ToInt32(reader["wc_id"]);
                    string name = reader["name"].ToString();
                    int yearCreated = Convert.ToInt32(reader["yearCreated"]);
                    string wineStyle = reader["wineStyle"].ToString();
                    string email = reader["email"].ToString();
                    string region = reader["region"].ToString();
                    string country = reader["country"].ToString();



                    WineCeller wineCeller = new WineCeller(wc_id, name, yearCreated, wineStyle, email, region, country);
                    winesCellers.Add(wineCeller);
                }
                reader.Close();
                sqlConnection.Close();
                return winesCellers;
            }

        }


        public void Update(WineCeller wineCeller)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);


            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Update WineCeller set name=@Name, yearCreated=@YearCreated, wineStyle=@WineStyle, email=@Email, region=@Region, country=@Country  Where wc_id=@id";


                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@Name", wineCeller.Name);
                cmd.Parameters.AddWithValue("@YearCreated", wineCeller.YearCreated);
                cmd.Parameters.AddWithValue("@WineStyle", wineCeller.WineStyle);
                cmd.Parameters.AddWithValue("@Email", wineCeller.Email);
                cmd.Parameters.AddWithValue("@Region", wineCeller.Region);
                cmd.Parameters.AddWithValue("@Country", wineCeller.Country);
                cmd.Parameters.AddWithValue("@id", wineCeller.Id);


                cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }


        }

        public void Delete(int wineCeller_id)
        {


            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);
            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "delete from WineCeller where wc_id=@id";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.AddWithValue("@id", wineCeller_id);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }

        }

     




        public WineCeller GetByIdWineCeller(int wineCeller_id)
        {
            WineCeller wineCeller = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr))
            {
                sqlConnection.Open();

                string sql = "SELECT * FROM WineCeller WHERE wc_id = @id";
                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@id", wineCeller_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int wc_id = Convert.ToInt32(reader["wc_id"]);
                            string name = reader["name"].ToString();
                            int yearCreated = Convert.ToInt32(reader["yearCreated"]);
                            string wineStyle = reader["wineStyle"].ToString();
                            string email = reader["email"].ToString();
                            string region = reader["region"].ToString();
                            string country = reader["country"].ToString();

                            wineCeller = new WineCeller(wc_id, name, yearCreated, wineStyle, email, region, country);
                            
                        }
                        reader.Close();
                        
                    }
                }
                sqlConnection.Close();
            }

            return wineCeller;
            
        }





        public WineCeller GetName(string Name)
        {
            WineCeller? wineCeller = null;

            SqlConnection sqlConnection = new SqlConnection(ConnString.sqlConnStr);

            using (sqlConnection)
            {
                sqlConnection.Open();
                string sql = "Select * WineCeller where name=@Name";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);

                cmd.Parameters.AddWithValue("@name", Name);

                SqlDataReader reader = cmd.ExecuteReader();

                int wc_id = Convert.ToInt32(reader["wc_id"]);
                string name = reader["name"].ToString();
                int yearCreated = Convert.ToInt32(reader["yearCreated"]);
                string wineStyle = reader["wineStyle"].ToString();
                string email = reader["email"].ToString();
                string region = reader["region"].ToString();
                string country = reader["country"].ToString();


                wineCeller = new WineCeller(wc_id, name, yearCreated, wineStyle, email, region, country);

                return wineCeller;
                sqlConnection.Close();

            }
           
        }


    }
}
