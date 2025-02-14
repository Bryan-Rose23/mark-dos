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
                cnTrabajador.ceTrabajador.Telefono = intTelefono.ToString() == "" ? 0 : Convert.ToInt32(intTelefono); //Convert.ToInt64(intTelefono);
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
        [HttpPost]
        public JsonResult ActualizarTrabajador(string strIdTrabajador, string strPrimerNombre, string strSegundoNombre, string strPrimerApellido, string strSegundoApellido, string strCedula, string strDomicilio, string intTelefono, string strCorreo, string intIdDepartamento, string intIdCargo, string boolEstado, string intIdSucursal)
        {
            try
            {
                //int intIdSucursal = 1;
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                cnTrabajador.ceTrabajador.Id = Convert.ToInt32(strIdTrabajador);
                cnTrabajador.ceTrabajador.PrimerNombre = strPrimerNombre == "" ? null : strPrimerNombre;
                cnTrabajador.ceTrabajador.SegundoNombre = strSegundoNombre;
                cnTrabajador.ceTrabajador.PrimerApellido = strPrimerApellido;
                cnTrabajador.ceTrabajador.SegundoApellido = strSegundoApellido;
                cnTrabajador.ceTrabajador.Cedula = strCedula;
                cnTrabajador.ceTrabajador.Domicilio = strDomicilio;
                cnTrabajador.ceTrabajador.Telefono = intTelefono.ToString() == "" ? 0 : Convert.ToInt32(intTelefono); //Convert.ToInt64(intTelefono);
                cnTrabajador.ceTrabajador.Correo = strCorreo;
                cnTrabajador.ceTrabajador.IdDepartamentoLaboral = Convert.ToInt32(intIdDepartamento);
                cnTrabajador.ceTrabajador.IdCargo = Convert.ToInt32(intIdCargo);
                cnTrabajador.ceTrabajador.Estado = boolEstado == "0"? false:true;

                cnTrabajador.cdTrabajador.ActualizarTrabajador(cnTrabajador.ceTrabajador, Convert.ToInt32(intIdSucursal));
                return Json(new { success = true, message = "Se actualizó el trabajador satisfactoriamente." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error: " + e.Message });
            }

        }

        [HttpPost]
        public JsonResult EliminarTrabajador(string strIdTrabajador)
        {
            try
            {
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                cnTrabajador.ceTrabajador.Id = Convert.ToInt32(strIdTrabajador);
                cnTrabajador.cdTrabajador.EliminarTrabajador(cnTrabajador.ceTrabajador);
                return Json(new { success = true, message = "Se eliminó el trabajador satisfactoriamente." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error: " + e.Message });
            }

        }
        [HttpGet]
        public JsonResult ConsultarTrabajador(string intIdEmpleado)
        {
            try
            {
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                //return Json(new { data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ConsultarTrabajador(cnTrabajador.ceTrabajador.Id)) }, JsonRequestBehavior.AllowGet);
                return Json(new { success = true, data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ConsultarTrabajador(Convert.ToInt32(intIdEmpleado))) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error: " + e.Message });
            }

        }
        [HttpGet]
        public JsonResult ConsultarHistorialTrabajador(string intIdEmpleado)
        {
            try
            {
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                //return Json(new { data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ConsultarTrabajador(cnTrabajador.ceTrabajador.Id)) }, JsonRequestBehavior.AllowGet);
                return Json(new { success = true, data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ConsultarHistorialTrabajador(Convert.ToInt32(intIdEmpleado))) }, JsonRequestBehavior.AllowGet);
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




        public JsonResult ListarSucursales()
        {
            clsNegocioSucursal cnSucursal = new clsNegocioSucursal();
            return Json(new { data = utilidades.DataTableToSerealize(cnSucursal.cdSucursal.ListarSucursal()) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarCargos()
        {
            clsNegocioCargo cnCargo = new clsNegocioCargo();
            return Json(new { data = utilidades.DataTableToSerealize(cnCargo.cdCargo.ListarCargos()) }, JsonRequestBehavior.AllowGet);
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