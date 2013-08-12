using Escrutinio2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Escrutinio2013.Controllers
{
    public class ListasController : ApiController
    {
        [HttpGet]
        public IEnumerable<Lista> Index()
        {
            return Lista.FindAll();
        }

        [HttpGet]
        public Lista GetListaById(int id)
        {
            return Lista.Find(id);
        }
    }
}
