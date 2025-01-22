using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using Utilidades;

namespace ECOVISA.Controllers
{
    public class TrabajadorController : Controller
    {
        clsUtilidades utilidades = new clsUtilidades();

        [HttpGet]
        public PartialViewResult Index()
        {
            ViewBag.Message = "Administración de Empleados ECOVISA";
            Session["TARGET_PAGE"] = "/Trabajador/Index";
            return PartialView();
        }

        public JsonResult ListaTrabajadores()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = utilidades.DataTableToSerealize(cnTrabajador.cdTrabajador.ListarTrabajador()) }, JsonRequestBehavior.AllowGet);
        }

        /*
                strPrimerNombre: primerNombre, strSegundoNombre: segundoNombre, strPrimerApellido: primerApellido, strSegundoApellido: segundoApellido,
                strCedula: cedula, intTelefono: telefono, intIdDepartamento: departamento, intIdCargo: cargo*/
        //string strSegundoApellido, string strCedula, string intTelefono, string intDepartamento, string intCargo
        [HttpPost]
        public JsonResult GuardarTrabajador(string strPrimerNombre, string strSegundoNombre, string strPrimerApellido, string strSegundoApellido, string strCedula, string strDomicilio, string intTelefono, string strCorreo, string intIdDepartamento, string intIdCargo)
        {
            try 
            {
                clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
                cnTrabajador.ceTrabajador.PrimerNombre = strPrimerNombre;
                cnTrabajador.ceTrabajador.SegundoNombre = strSegundoNombre;
                cnTrabajador.ceTrabajador.PrimerApellido = strPrimerApellido;
                cnTrabajador.ceTrabajador.SegundoApellido = strSegundoApellido;
                cnTrabajador.ceTrabajador.Cedula = strCedula;
                cnTrabajador.ceTrabajador.Domicilio = strDomicilio;
                cnTrabajador.ceTrabajador.Telefono = Convert.ToInt32(intTelefono.Substring(3)); //Convert.ToInt64(intTelefono);
                cnTrabajador.ceTrabajador.Correo = strCorreo;
                cnTrabajador.ceTrabajador.IdDepartamentoLaboral = Convert.ToInt32(intIdDepartamento);
                cnTrabajador.ceTrabajador.IdCargo = Convert.ToInt32(intIdCargo);
                cnTrabajador.cdTrabajador.GuardarTrabajador(cnTrabajador.ceTrabajador);
                return Json(new { success = true, message = "Se guardó nuevo trabajador satisfactoriamente." });
            }
            catch (Exception e) 
            {
                return Json(new { success = false, message = "Error: "+ e.Message });
            }
            
        }

        public JsonResult ListarTrabajadoresList()
        {
            clsNegocioTrabajador cnTrabajador = new clsNegocioTrabajador();
            return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajadorLista() }, JsonRequestBehavior.AllowGet);
            //  return Json(new { data = cnTrabajador.cdTrabajador.ListarTrabajador() }, JsonRequestBehavior.AllowGet);
        }
        
    }
}