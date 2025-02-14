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

        public DataTable ValidarContrasenaActual(clsEntidadUsuario ceUsuario) 
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDVALIDAR_CONTRASENA_ACTUAL", con);
                cmd.Parameters.AddWithValue("@intIdUsuario", ceUsuario.Id);
                cmd.Parameters.AddWithValue("@strContrasena", ceUsuario.Contrasena);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
        }
        public void CambiarContrasena(clsEntidadUsuario ceUsuario, String strNuevaContrasena)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDCAMBIAR_CONTRASENA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdUsuario", ceUsuario.Id);
                cmd.Parameters.AddWithValue("@strNuevaContrasena", strNuevaContrasena);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
