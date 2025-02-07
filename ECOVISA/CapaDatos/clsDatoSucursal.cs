using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class clsDatoSucursal
    {
        clsEntidadConexion cn = new clsEntidadConexion();
        public DataTable ListarSucursal()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cn.CadenaConexion()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM TBLSUCURSAL ORDER BY NOMBRE ASC", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }
    }
}
