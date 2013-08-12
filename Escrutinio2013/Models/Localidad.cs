using Castle.ActiveRecord;
using System;
using System.Collections.Generic;

namespace Escrutinio2013.Models
{
   [ActiveRecord("Localidades")]
    public class Localidad : ActiveRecordBase<Localidad>
   {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Nombre { get; set; }
        [BelongsTo("PartidoId", Lazy = FetchWhen.OnInvoke)]
        public Partido Partido { get; set; }
        [Property]
        public int CodigoPostal { get; set; }
        [HasMany(typeof(Escuela), ColumnKey = "LocalidadId", Inverse = true, Lazy = true)]
        public IList<Escuela> Escuelas { get; set; }
    }
}