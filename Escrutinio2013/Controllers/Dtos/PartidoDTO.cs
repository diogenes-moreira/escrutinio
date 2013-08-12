using System;
using System.Collections.Generic;

using Escrutinio2013.Models;

namespace Escrutinio2013.Controllers.Dtos
{
    public class PartidoDTO
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public IList<ListaDTO> Listas { get; set; }

        public static IList<PartidoDTO> Bind(IList<Lista> listas)
        {
            var salida = new List<PartidoDTO>();
            foreach (var lista in listas)
            {
                var partidoDto = salida.Find(partido => partido.Id == lista.Partido.Id);
                var listaDto = ListaDTO.Bind(lista);
                try
                {
                    partidoDto.Listas.Add(listaDto);
                } catch
                {
                    partidoDto = Bind(lista.Partido);
                    salida.Add(partidoDto);
                    partidoDto.Listas.Add(listaDto);
                } 
            }

            return salida;
        }

        public static PartidoDTO Bind(PartidoPolitico partido)
        {
            return new PartidoDTO
                       {
                           Id = partido.Id,
                           Nombre = partido.Nombre,
                           Listas = new List<ListaDTO>()
                       };
        }

    }
}