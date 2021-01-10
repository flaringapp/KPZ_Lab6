
using System.Data.SqlClient;

namespace Lab6.Data.DB
{
    static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-HVULQQV;Initial Catalog=KpzLab6;Integrated Security=True");
        }

    }
}
