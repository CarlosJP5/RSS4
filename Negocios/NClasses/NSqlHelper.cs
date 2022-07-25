using Datos.Classes;

namespace Negocios.NClasses
{
    public class NSqlHelper
    {
        public bool IsConnetion(string stringConnection)
        {
            SqlHelper helper = new SqlHelper(stringConnection);
            return helper.IsConnetion;
        }
    }
}
