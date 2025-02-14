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
            if (contrasena.Length > 7 && contrasena.Length <= 12)
            {
                return "";
            }
            else 
            {
                return "La contraseña debe tener entre 7 y 12 caracteres.";
            }
            
        }
    }
}
