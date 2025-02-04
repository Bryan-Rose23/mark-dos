using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using Utilidades;

namespace ECOVISA.Controllers
{
    public class CargosController : Controller
    {
        clsUtilidades utilidades = new clsUtilidades();

        // GET: Cargos
        public ActionResult Index()
        {
            return View();
        }
        
    }
}