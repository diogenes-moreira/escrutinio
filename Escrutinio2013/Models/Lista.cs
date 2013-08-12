using Castle.ActiveRecord;
using System;


namespace Escrutinio2013.Models
{
    [ActiveRecord]
    public class Lista : ActiveRecordBase<Lista>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Nombre { get; set; }
        [Property]
        public int Orden { get; set; }
        [BelongsTo("PartidoPoliticoId", Lazy = FetchWhen.OnInvoke)]
        public PartidoPolitico Partido { get; set; }
        [Property]
        public bool Simplificado { get; set; }


    }
}