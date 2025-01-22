using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsDatoUsuario
    {
        public clsEntidadConexion cn = new clsEntidadConexion();

        public DataTable ValidarUsuario(clsEntidadUsuario ceUsuario) 
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion())) 
            {
                SqlCommand cmd = new SqlCommand("PCDVALIDAR_USUARIO", con);
                cmd.Parameters.AddWithValue("@strUsuario", ceUsuario.Usuario);
                cmd.Parameters.AddWithValue("@strContrasena", ceUsuario.Contrasena);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
        }
    }
}
