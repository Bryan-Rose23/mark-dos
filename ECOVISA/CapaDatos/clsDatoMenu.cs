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
    public class clsDatoMenu
    {
        public clsEntidadConexion strCon = new clsEntidadConexion();
        public List<clsEntidadMenu> ListarMenu() 
        {
            List<clsEntidadMenu> listaMenu = new List<clsEntidadMenu>();
            using (SqlConnection cn = new SqlConnection(strCon.CadenaConexion())) 
            {
                SqlCommand cmd = new SqlCommand("PCDLISTARMENUS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) 
                {
                    listaMenu.Add(new clsEntidadMenu()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        NombreMenu = Convert.ToString(dr["NOMBREMENU"]),
                        Ubicacion = Convert.ToString(dr["UBICACION"]),
                        Posicion = Convert.ToInt32(dr["POSICION"]),
                        IdPadre = Convert.ToInt32(dr["IDPADRE"]),
                        Padre = Convert.ToString(dr["PADRE"]),
                        Nivel = Convert.ToInt32(dr["NIVEL"]),
                        Hijos = Convert.ToInt32(dr["HIJO"])
                    }); ;
                }
            }
            return listaMenu;
        }

    }
}
