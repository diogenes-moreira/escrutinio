using System;
using Castle.ActiveRecord;
using Escrutinio2013.Models;
using System.Web.Mvc;

namespace Escrutinio2013.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Init()
        {
            ViewBag.Message = "Todo Creado";
            ActiveRecordStarter.CreateSchema();
            Initializer.CrearEscuelas();
            Initializer.CrearCategorias();
            Initializer.CrearPartidosPoliticos();
            Initializer.TratarExtranjero();
            
            return View();
        }

      

      

        public ActionResult Index()
        {
            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Página de descripción de la aplicación.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }
    }
}
