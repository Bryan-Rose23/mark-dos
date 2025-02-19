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
    public class clsDatoDepartamento
    {
        clsEntidadConexion cn = new clsEntidadConexion();
        public void GuardarDepartamento(clsEntidadDepartamento ceDepartamento)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDINSERTAR_DEPARTAMENTO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strDescripcion", ceDepartamento.Descripcion);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarDepartamento(clsEntidadDepartamento ceDepartamento)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDACTUALIZAR_DEPARTAMENTO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdDepartamento", ceDepartamento.Id);
                cmd.Parameters.AddWithValue("@strDescripcion", ceDepartamento.Descripcion);
                cmd.Parameters.AddWithValue("@boolEstado", ceDepartamento.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ConsultarDepartamento(int intIdDepartamento)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PCDCONSULTAR_DEPARTAMENTO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@intIdDepartamento", intIdDepartamento);
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable ListarDepartamentos() 
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion())) 
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VWLISTAR_DEPARTAMENTOS", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }
    }
}
