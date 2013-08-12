using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
 using Newtonsoft.Json;

namespace Escrutinio2013.Models
{
    [ActiveRecord("Partidos")]
    public class Partido : ActiveRecordBase<Partido>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Nombre { get; set; }

        [HasMany(typeof(Localidad), ColumnKey = "PartidoId", Inverse = true, Lazy = true)]
        public IList<Localidad> Localidades { get; set; }
       
    }
}