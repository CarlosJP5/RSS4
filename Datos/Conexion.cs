using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public abstract class Conexion
    {
        private readonly string cadenaConexion = zConexion.CadenaConexion;

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
