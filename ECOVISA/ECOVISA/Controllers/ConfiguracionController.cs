using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using Utilidades;


namespace ECOVISA.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ConfiguracionController : Controller
    {
        // GET: Configuracion
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public PartialViewResult CuentaUsuario()
        {
            ViewBag.Message = "Administración de Empleados ECOVISA";
            Session["TARGET_PAGE"] = "/Configuracion/CuentaUsuario";
            return PartialView();
        }
        [HttpPost]
        public JsonResult ActualizarContrasena(string strIdTrabajador, string strActual, string strContrasena, string strConfirmacion)
        {
            try
            {
                clsNegocioUsuario cnUsuarioContrasena = new clsNegocioUsuario();
                cnUsuarioContrasena.ceUsuario.Id = Convert.ToInt32(strIdTrabajador);
                cnUsuarioContrasena.ceUsuario.Contrasena = strActual;
                String strValidaCambioContrasena = cnUsuarioContrasena.ValidarCambioContrasena(cnUsuarioContrasena.ceUsuario, strContrasena, strConfirmacion);
                if (strValidaCambioContrasena == "")
                {
                    cnUsuarioContrasena.cdUsuario.CambiarContrasena(cnUsuarioContrasena.ceUsuario, cnUsuarioContrasena.ConvertirSHA256(strContrasena));
                    return Json(new { success = true, message = "Se actualizó la contrasena de la cuenta satisfactoriamente." });
                }
                else 
                {
                    return Json(new { success = false, message = strValidaCambioContrasena });
                }

            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error: " + e.Message });
            }

        }


    }
}