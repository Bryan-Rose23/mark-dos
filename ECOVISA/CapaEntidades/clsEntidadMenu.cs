using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsEntidadMenu
    {
        public int Id{ get; set; }
        public string NombreMenu { get; set; }
        public string Ubicacion { get; set; }
        public int Posicion  { get; set; }
        public int IdPadre { get; set; }
        public string Padre { get; set; }
        public int Nivel { get; set; }
        public int Hijos { get; set; }

    }
}
