using System.Linq;
using Escrutinio2013.Controllers.Dtos;
using Escrutinio2013.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace Escrutinio2013.Controllers
{
    public class MesasController : ApiController
    {
      
        [HttpGet]
        public MesaDTO Index(int id)
        {
            return MesaDTO.Bind(Mesa.Find(id));
        }
        
    }

   
}
