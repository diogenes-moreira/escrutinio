using Castle.ActiveRecord;
using System;
namespace Escrutinio2013.Models
{

    [ActiveRecord]
    public class Categoria : ActiveRecordBase<Categoria>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length=255)]
        public String Nombre { get; set; }
        [Property]
        public int Orden { get; set; }
        [Property]
        public bool Simplificado { get; set; }

    }
}