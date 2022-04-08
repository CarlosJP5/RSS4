using Datos.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
