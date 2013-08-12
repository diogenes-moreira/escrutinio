using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Escrutinio2013.Models;
using NHibernate.Criterion;

namespace Escrutinio2013.Controllers
{
    public class CargaController : Controller
    {
        //
        // GET: /Carga/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Simple()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CargaMesa(string mesa)
        {
            return View(Mesa.FindFirst(Restrictions.Eq("Numero",mesa) ));
        }

        [HttpPost]
        public ActionResult CargaMesaSimple(string mesa)
        {
            return View(Mesa.FindFirst(Restrictions.Eq("Numero", mesa)));
        }


        public ActionResult ControlRecepcion()
        {
            var c = new List<Order>{Order.Asc("Circuito")};
            return View(Escuela.FindAll(c.ToArray()));
           // return View( new Escuela[]{ Escuela.Find(80)});
        }

        [HttpPost]
        public ActionResult Persistir()
        {
            PersistValues();
            return View();
        }

        private void PersistValues()
        {
            var valores =
                Request.Form.AllKeys.Where(key => key.StartsWith("escrutinio_")).ToDictionary(
                    key => int.Parse(key.Substring(11)), key => int.Parse(Request.Form[key]));
            Escrutinio.FastUpdate(valores);
        }

        public ActionResult PersistirSimplificado()
        {
           PersistValues();
            return View();
        }
    }
}
