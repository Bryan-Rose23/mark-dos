using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class clsDatoTrabajador
    {
        clsEntidadConexion cn = new clsEntidadConexion();
                
        public void GuardarTrabajador(clsEntidadTrabajador ceTrabajador, int intIdSucursal)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion())) 
            {
                SqlCommand cmd = new SqlCommand("PCDINSERTAR_EMPLEADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@strPrimerNombre", ceTrabajador.PrimerNombre);
                cmd.Parameters.AddWithValue("@strSegundoNombre", ceTrabajador.SegundoNombre);
                cmd.Parameters.AddWithValue("@strPrimerApellido", ceTrabajador.PrimerApellido);
                cmd.Parameters.AddWithValue("@strSegundoApellido", ceTrabajador.SegundoApellido);
                cmd.Parameters.AddWithValue("@strCedula", ceTrabajador.Cedula);
                cmd.Parameters.AddWithValue("@strDomicilio", ceTrabajador.Domicilio);
                cmd.Parameters.AddWithValue("@intTelefono", ceTrabajador.Telefono);
                cmd.Parameters.AddWithValue("@strCorreo", ceTrabajador.Correo);
                cmd.Parameters.AddWithValue("@intIdDepartamento", ceTrabajador.IdDepartamentoLaboral);
                cmd.Parameters.AddWithValue("@intIdCargo", ceTrabajador.IdCargo);
                cmd.Parameters.AddWithValue("@intIdSucursal", intIdSucursal);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarTrabajador(clsEntidadTrabajador ceTrabajador, int intIdSucursal)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDACTUALIZAR_EMPLEADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdEmpleado", ceTrabajador.Id);
                cmd.Parameters.AddWithValue("@strPrimerNombre", ceTrabajador.PrimerNombre);
                cmd.Parameters.AddWithValue("@strSegundoNombre", ceTrabajador.SegundoNombre);
                cmd.Parameters.AddWithValue("@strPrimerApellido", ceTrabajador.PrimerApellido);
                cmd.Parameters.AddWithValue("@strSegundoApellido", ceTrabajador.SegundoApellido);
                cmd.Parameters.AddWithValue("@strCedula", ceTrabajador.Cedula);
                cmd.Parameters.AddWithValue("@strDomicilio", ceTrabajador.Domicilio);
                cmd.Parameters.AddWithValue("@intTelefono", ceTrabajador.Telefono);
                cmd.Parameters.AddWithValue("@strCorreo", ceTrabajador.Correo);
                cmd.Parameters.AddWithValue("@intIdDepartamento", ceTrabajador.IdDepartamentoLaboral);
                cmd.Parameters.AddWithValue("@intIdCargo", ceTrabajador.IdCargo);
                cmd.Parameters.AddWithValue("@boolEstado", ceTrabajador.Estado);
                cmd.Parameters.AddWithValue("@intIdSucursal", intIdSucursal);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EliminarTrabajador(clsEntidadTrabajador ceTrabajador)
        {
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("PCDELIMINAR_EMPLEADO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intIdEmpleado", ceTrabajador.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ConsultarTrabajador(int intIdTrabajador)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PCDCONSULTAR_EMPLEADO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@intIdEmpleado", intIdTrabajador);
                    da.Fill(dt);
                }
            }

            /*using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                /*using (SqlCommand cmd = new SqlCommand("PCDCONSULTAR_EMPLEADO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intIdTrabajador", intIdTrabajador);

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }*
            *using (SqlDataAdapter da = new SqlDataAdapter("PCDCONSULTAR_EMPLEADO", con))
                {
                   
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@intIdTrabajador", intIdTrabajador);
                   

                    da.Fill(dt);

                }*
            }*/
            return dt;
        }
        public DataTable ListarTrabajador() 
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion())) 
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM VWLISTAR_EMPLEADO", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }

        public List<clsEntidadTrabajador> ListarTrabajadorLista()
        {
            List<clsEntidadTrabajador> listTrabajador = new List<clsEntidadTrabajador>();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBLEMPLEADO", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
            
                while (dr.Read()) 
                {
                    listTrabajador.Add(new clsEntidadTrabajador(){
                        Id = Convert.ToInt32(dr["ID"]),
                        PrimerNombre = Convert.ToString(dr["PRIMER_NOMBRE"]),
                        SegundoNombre = Convert.ToString(dr["SEGUNDO_NOMBRE"]),
                        PrimerApellido = Convert.ToString(dr["SEGUNDO_NOMBRE"]),
                        SegundoApellido = Convert.ToString(dr["SEGUNDO_NOMBRE"]),
                        Cedula = Convert.ToString(dr["CEDULA"]),
                        Domicilio = Convert.ToString(dr["DOMICILIO"]),
                        Telefono = Convert.ToInt32(dr["TELEFONO"]),
                        Correo = Convert.ToString(dr["CORREO_ELECTRONICO"]),
                        Estado = Convert.ToBoolean(dr["ESTADO"]),
                        IdDepartamentoLaboral = Convert.ToInt32(dr["IDDEPARTAMENTO_LABORAL"]),
                        IdCargo = Convert.ToInt32(dr["IDCARGO"])
                    });
                }
            }
            return listTrabajador;
        }
    }
}
