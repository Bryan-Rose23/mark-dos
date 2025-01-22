using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Data.SqlClient;  
using System.Configuration;  
 
namespace CapaDatos
{
    public class clsEntidadConexion
    {
        public static string cn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        public string CadenaConexion() 
        {
            return cn;
        }
    }
}
