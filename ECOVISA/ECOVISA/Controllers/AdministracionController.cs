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
            ViewBag.Message = "Registro de Empleados ECOVISA";
            Session["TARGET_PAGE"] = "/Administracion/Trabajador";
            return PartialView();
        }

        [HttpPost]
        public JsonResult GuardarTrabajador(string strPrimerNombre, string strSegundoNombre, string strPrimerApellido, string strSegundoApellido, string strCedula, string strDomicilio, string intTelefono, string strCorreo, string intIdDepartamento, string intIdCargo)
        {
            try
            {
                int intIdSucursal = 1;
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                cnTrabajador.ceTrabajador.PrimerNombre = strPrimerNombre == "" ? null : strPrimerNombre;
                cnTrabajador.ceTrabajador.SegundoNombre = strSegundoNombre;
                cnTrabajador.ceTrabajador.PrimerApellido = strPrimerApellido;
                cnTrabajador.ceTrabajador.SegundoApellido = strSegundoApellido;
                cnTrabajador.ceTrabajador.Cedula = strCedula;
                cnTrabajador.ceTrabajador.Domicilio = strDomicilio;
                cnTrabajador.ceTrabajador.Telefono = intTelefono.ToString() == "" ? 0 : Convert.ToInt32(intTelefono.Substring(3)); //Convert.ToInt64(intTelefono);
                cnTrabajador.ceTrabajador.Correo = strCorreo;
                cnTrabajador.ceTrabajador.IdDepartamentoLaboral = Convert.ToInt32(intIdDepartamento);
                cnTrabajador.ceTrabajador.IdCargo = Convert.ToInt32(intIdCargo);
                cnTrabajador.cdTrabajador.GuardarTrabajador(cnTrabajador.ceTrabajador, intIdSucursal);
                return Json(new { success = true, message = "Se guardó nuevo trabajador satisfactoriamente." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error: " + e.Message });
            }

        }

        public JsonResult ListaTrabajadores()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ListarTrabajador()) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCargos()
        {
            clsNegocioCargo cnCargo = new clsNegocioCargo();
            return Json(new { data = utilidades.DataTableToSerealize(cnCargo.cdDato.ListarCargos()) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarDepartamentos()
        {
            clsNegocioDepartamento cnDepartamento = new clsNegocioDepartamento();
            return Json(new { data = utilidades.DataTableToSerealize(cnDepartamento.cdDepartamento.ListarDepartamentos()) }, JsonRequestBehavior.AllowGet);
        }





        public JsonResult ListarTrabajadoresList()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajadorLista() }, JsonRequestBehavior.AllowGet);
            //  return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajador() }, JsonRequestBehavior.AllowGet);
        }

    }
}