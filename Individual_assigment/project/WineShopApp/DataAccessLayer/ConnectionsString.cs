using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class ConnectionsString
    {
        private string sqlConnection;
        public ConnectionsString()
        {
            sqlConnection = "Server=mssqlstud.fhict.local;Database=dbi509460_iassigment;User Id=dbi509460_iassigment;Password=mk050203; TrustServerCertificate=True ";

        }
        public SqlConnection GetSqlconnection()
        {
            return new SqlConnection(sqlConnection);
        }
    }
}
