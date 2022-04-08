using System.Data;
using System.Data.SqlClient;

namespace Datos.Classes
{
    public class SqlHelper
    {
        private readonly SqlConnection cn;
        public SqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }

        public bool IsConnetion
        {
            get
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                return true;
            }
        }
    }
}
