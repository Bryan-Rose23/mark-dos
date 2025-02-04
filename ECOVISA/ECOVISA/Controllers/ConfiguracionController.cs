using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOVISA.Controllers
{
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


    }
}