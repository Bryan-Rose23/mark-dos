using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using Utilidades;
namespace ECOVISA.Controllers
{
    public class DepartamentosController : Controller
    {
        clsUtilidades utilidades = new clsUtilidades();
        // GET: Departamentos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarDepartamentos()
        {
            clsNegocioDepartamento cnDepartamento = new clsNegocioDepartamento();
            return Json(new { data = utilidades.DataTableToSerealize(cnDepartamento.cdDepartamento.ListarDepartamentos()) }, JsonRequestBehavior.AllowGet);
        }
    }
}