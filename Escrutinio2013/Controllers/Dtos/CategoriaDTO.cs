using System.Collections.Generic;
using System.Linq;
using Escrutinio2013.Models;

namespace Escrutinio2013.Controllers.Dtos
{
    public class CategoriaDTO
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public int Orden { get; set; }

        public static IList<CategoriaDTO> Bind(IList<Categoria> categorias)
        {
            return categorias.Select(Bind).ToList();
        }

        public static CategoriaDTO Bind(Categoria categoria)
        {
            return new CategoriaDTO
                       {
                           Id = categoria.Id,
                           Nombre = categoria.Nombre,
                           Orden = categoria.Orden
                       };
        }
    }
}