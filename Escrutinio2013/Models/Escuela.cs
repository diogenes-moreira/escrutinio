using Castle.ActiveRecord;
using System;
using System.Collections.Generic;

namespace Escrutinio2013.Models
{
    [ActiveRecord]
    public class Escuela : ActiveRecordBase<Escuela>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Circuito { get; set; }
        [Property(Length = 255)]
        public String Codigo { get; set; }
        [Property(Length = 255)]
        public String Nombre { get; set; }
        [Property(Length = 255)]
        public String Responsable { get; set; }
        [Property(Length = 255)]
        public String ContactoResponsable { get; set; }
        [Property(Length = 255)]
        public String Direccion { get; set; }
        
        [BelongsTo("LocalidadId", Lazy = FetchWhen.OnInvoke)]
        public Localidad Localidad { get; set; }

        [HasMany(typeof(Mesa), Inverse = true, Lazy = true)]
        public IList<Mesa> Mesas { get; set; }

        [Property]
        public int MesaDesde { get; set; }
        [Property]
        public int MesaHasta { get; set; }


        public override string ToString()
        {
            return Id + '-' + Nombre;
        }

        public static void Init()
        {
            
        }

    }
}