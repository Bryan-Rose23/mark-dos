using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using Utilidades;

namespace ECOVISA.Controllers
{
    public class AdministracionController : Controller
    {
        clsUtilidades utilidades = new clsUtilidades();
        // GET: Administracion
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public PartialViewResult Trabajador()
        {
            ViewBag.Message = "Administración de Empleados ECOVISA";
            Session["TARGET_PAGE"] = "/Administracion/Trabajador";
            return PartialView();
        }

        public JsonResult ListaTrabajadores()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ListarTrabajador()) }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListarTrabajadoresList()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajadorLista() }, JsonRequestBehavior.AllowGet);
            //  return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajador() }, JsonRequestBehavior.AllowGet);
        }

    }
}