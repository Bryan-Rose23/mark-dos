using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class clsNegocioUsuario
    {
        public clsDatoUsuario cdUsuario = new clsDatoUsuario();
        public clsEntidadUsuario ceUsuario = new clsEntidadUsuario();

        public string ConvertirSHA256(string strCadena) 
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create()) 
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(strCadena));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public string ValidarCambioContrasena(clsEntidadUsuario ceUsuarioCambio, String strNuevaContrasena, String strConfirmacionContrasena) 
        {
            if (ceUsuarioCambio.Contrasena == strNuevaContrasena)
            {
                return "La nueva contraseña debe ser diferente a la contraseña actual.";
            }
            else 
            {
                if (strNuevaContrasena == strConfirmacionContrasena) 
                {
                    //consultar contraseña actual
                    ceUsuarioCambio.Contrasena = ConvertirSHA256(ceUsuarioCambio.Contrasena);
                    System.Data.DataTable dt = cdUsuario.ValidarContrasenaActual(ceUsuarioCambio);
                    if (dt.Rows.Count > 0)
                    {
                        //validar criterios de validacion de contraseña
                        return ValidarCriteriosContrasena(strNuevaContrasena);
                    }
                    else 
                    {
                        return "La contraseña actual ingresada no coincide con la contraseña de uso actual registrada.";
                    }
                }
                return "No se encontró coincidencia entre los datos ingresados en el campo Nueva contraseña y el campo Confirmar contraseña.";
            }

        }

        public string ValidarCriteriosContrasena(String contrasena)
        {
<<<<<<< HEAD
            int intCountCaracter = 0;
            int intCountUpper = 0;
            int intCountMin = 0;
            int intCountNum = 0;
            int intCountGrupos = 0;
            //string strMensaje = "La Contraseña debe cumplir al menos tres de los cuatro criterios:   1.- Letras mayúsculas [A-Z]   2.- Letras minúsculas [a-z]   3.- Caracteres numéricos [0-9]   4.- Caracteres especial [!@#$%^&*()_+=...]";
            System.Text.RegularExpressions.Regex upper = new System.Text.RegularExpressions.Regex("[A-Z]");
            System.Text.RegularExpressions.Regex lower = new System.Text.RegularExpressions.Regex("[a-z]");
            System.Text.RegularExpressions.Regex numbers = new System.Text.RegularExpressions.Regex("[0-9]");
            System.Text.RegularExpressions.Regex special = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");

            if (contrasena.Length < 7 || contrasena.Length > 12)
            {
                return "La contraseña debe tener entre 7 y 12 caracteres."; ;
            }

            intCountUpper = upper.Matches(contrasena).Count;
            intCountMin = lower.Matches(contrasena).Count;
            intCountNum = numbers.Matches(contrasena).Count;
            intCountCaracter = special.Matches(contrasena).Count;

            if (intCountUpper>0) 
            {
                intCountGrupos = intCountGrupos + 1;
            }
            if (intCountMin > 0)
            {
                intCountGrupos = intCountGrupos + 1;
            }
            if (intCountNum > 0)
            {
                intCountGrupos = intCountGrupos + 1;
            }
            if (intCountCaracter > 0)
            {
                intCountGrupos = intCountGrupos + 1;
            }

            if (intCountGrupos < 3) 
            {
                return "La Contraseña debe cumplir al menos tres de los cuatro criterios:   1.- Letras mayúsculas [A-Z]   2.- Letras minúsculas [a-z]   3.- Caracteres numéricos [0-9]   4.- Caracteres especial [!@#$%^&*()_+=...]";
            }

            return "";
=======
            if (contrasena.Length > 7 && contrasena.Length <= 12)
            {
                return "";
            }
            else 
            {
                return "La contraseña debe tener entre 7 y 12 caracteres.";
            }
            
>>>>>>> c2dcb41df0e6f4e8bab492976c4e4a682271fbb6
        }
    }
}
