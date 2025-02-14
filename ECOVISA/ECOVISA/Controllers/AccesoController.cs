using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CapaNegocio;
namespace ECOVISA.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string strUsuario, string strContrasena) 
        {
            try {
                if (strUsuario == "" || strContrasena == "") 
                {
                    return Json(new { success = false, message = "Complete los campos." });
                }
                System.Data.DataTable dt = new System.Data.DataTable();
                clsNegocioUsuario cnUsuario = new clsNegocioUsuario();
                cnUsuario.ceUsuario.Usuario = strUsuario;
                cnUsuario.ceUsuario.Contrasena = cnUsuario.ConvertirSHA256(strContrasena);
                dt = cnUsuario.cdUsuario.ValidarUsuario(cnUsuario.ceUsuario);
                if (dt.Rows.Count>0) 
                {
                    CapaEntidades.clsEntidadUsuario ceUsuario = new CapaEntidades.clsEntidadUsuario();
                    ceUsuario.Id = Convert.ToInt32(dt.Rows[0][0]);
                    ceUsuario.NombreUsuario = Convert.ToString(dt.Rows[0][1]);
                    ceUsuario.Usuario = Convert.ToString(dt.Rows[0][2]);
                    ceUsuario.Correo = Convert.ToString(dt.Rows[0][4]);
                    ceUsuario.Estado = Convert.ToBoolean(dt.Rows[0][5]);
                    ceUsuario.IdEmpleado = Convert.ToInt32(dt.Rows[0][6]);
                    ceUsuario.IdGrupo = Convert.ToInt32(dt.Rows[0][7]);
                    ceUsuario.IdSucursal = Convert.ToInt32(dt.Rows[0][8]);
                    Session["SesionUsuario"] = ceUsuario;
                    return Json(new { success=true, message="ok"});
                }
                return Json(new { success=false, message = "No se econtr\u00f3 el usuario ingresado."});
            }
            catch (Exception e) 
            {
                return Json(new { success = false, message = "No se econtr\u00f3 el usuario ingresado." });
            }
        }

        /*[HttpPost]
        public ActionResult Login(CapaEntidades.clsEntidadUsuario oUsuario)
        {
            try
            {
                if (oUsuario.Usuario == null || oUsuario.Contrasena == null)
                {
                    TempData["SweetAlertTitulo"] = "Error";
                    TempData["SweetAlertMensaje"] = "Completar los campos.";
                    TempData["SweetAlertTipo"] = "error";
                    return View();
                }

                System.Data.DataTable dt = new System.Data.DataTable();
                clsNegocioUsuario cnUsuario = new clsNegocioUsuario();
                cnUsuario.ceUsuario.Usuario = oUsuario.Usuario;
                cnUsuario.ceUsuario.Contrasena = cnUsuario.ConvertirSHA256(oUsuario.Contrasena);
                dt = cnUsuario.cdUsuario.ValidarUsuario(cnUsuario.ceUsuario);
                if (dt.Rows.Count > 0)
                {
                    Session["SesionUsuario"] = dt;
                    return RedirectToAction("Inicio", "Home");
                }
                else
                {
                    //Implementar Alerts
                    TempData["SweetAlertTitulo"] = "Error";
                    TempData["SweetAlertMensaje"] = "No se encontro el usuario ingresado.";
                    TempData["SweetAlertTipo"] = "error"; // You can sset 'success', 'error', 'warning', 'info'
                    return View();
                } 
            }
            catch (Exception e) 
            {
                string strErrorMsg = e.Message;
                TempData["SweetAlertTitulo"] = "Error";
                TempData["SweetAlertMensaje"] = "Ocurri&oacute; un error inesperado. Intentelo más tarde.";
                TempData["SweetAlertTipo"] = "error"; // You can set 'success', 'error', 'warning', 'info'
                return View();
            }
        }*/

        /*[HttpPost]
        public string IniciarSesion(string strUsuario, string strContrasena)//(CapaEntidades.clsEntidadUsuario oUsuario)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                clsNegocioUsuario cnUsuario = new clsNegocioUsuario();
                cnUsuario.ceUsuario.Usuario = strUsuario;
                cnUsuario.ceUsuario.Contrasena = cnUsuario.ConvertirSHA256(strContrasena);
                dt = cnUsuario.cdUsuario.ValidarUsuario(cnUsuario.ceUsuario);
                if (dt.Rows.Count > 0)
                {
                    Session["SesionUsuario"] = dt;
                    //return RedirectToAction("Index", "Home");
                    return "Ok";
                }
                else
                {
                    //Implementar Alerts
                    TempData["SweetAlertMessage"] = "No se encontró el usuario ingresado.";
                    TempData["SweetAlertType"] = "error"; // You can sset 'success', 'error', 'warning', 'info'
                    return TempData["SweetAlertMessage"].ToString();
                    //return View();
                }
            }
            catch (Exception e)
            {
                TempData["SweetAlertMessage"] = "Completar los campos";
                TempData["SweetAlertType"] = "error"; // You can set 'success', 'error', 'warning', 'info'
                return TempData["SweetAlertMessage"].ToString();
            }
        }*/
    }
}