using System.Collections.Generic;
using Escrutinio2013.Models;

namespace Escrutinio2013.Controllers.Dtos
{
    public class MesaDTO
    {
        public string Escuela { get; set; }
        public int Id { get; set; }
        public IList<PartidoDTO> PartidosHabilitadas { get; set; }
        public IList<CategoriaDTO> CategoriasHabilitadas { set; get; } 

        public static MesaDTO Bind(Mesa mesa)
        {
            return new MesaDTO
                       {
                           CategoriasHabilitadas = CategoriaDTO.Bind(mesa.CategoriasHabilitadas()),
                           Escuela = mesa.Escuela.ToString(),
                           Id = mesa.Id,
                           PartidosHabilitadas = PartidoDTO.Bind(mesa.ListasHabilitadas()) 
                       };
        }

    }
}