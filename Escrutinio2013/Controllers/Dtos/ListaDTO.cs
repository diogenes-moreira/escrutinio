using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escrutinio2013.Models;

namespace Escrutinio2013.Controllers.Dtos
{
    public class ListaDTO
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public int Orden { get; set; }

        public static ListaDTO Bind(Lista lista)
        {
            return new ListaDTO
                       {
                           Id = lista.Id,
                           Nombre = lista.Nombre,
                           Orden = lista.Orden
                       };
        }
    }
}