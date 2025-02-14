using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsEntidadUsuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public Boolean Estado  { get; set; }
        public int IdEmpleado { get; set; }
        public int IdGrupo { get; set; }
        public int IdSucursal { get; set; }

    }
}
