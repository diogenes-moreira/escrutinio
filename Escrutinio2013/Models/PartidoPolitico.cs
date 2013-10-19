using Castle.ActiveRecord;
using System;
using System.Collections.Generic;

namespace Escrutinio2013.Models
{
    [ActiveRecord("PartidosPoliticos")]
    public class PartidoPolitico : ActiveRecordBase<PartidoPolitico>
    {
        public PartidoPolitico(){
            Listas = new List<Lista>();
        }
        
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Nombre { get; set; }
        [Property]
        public int Orden { get; set; }

        [Property]
        public String Numero { get; set; }

        [Property]
        public bool Servicio { get; set; }


        [HasMany(typeof(Lista), ColumnKey = "PartidoPoliticoId", Inverse = true, Lazy = true)]
        public IList<Lista> Listas { get; set; }
    }
}