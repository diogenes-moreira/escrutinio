using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Escrutinio2013.Models
{
   [ActiveRecord]
    public class Mesa : ActiveRecordBase<Mesa>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [Property(Length = 255)]
        public String Numero { get; set; }
        [BelongsTo("EscuelaId", Lazy = FetchWhen.OnInvoke)]
        public Escuela Escuela { get; set; }
        [Property]
        public int CantidadDeVotantes { get; set; }
        [Property]
        public bool Entregada { get; set; }
        [Property(Length = 255)]
        public String Fiscal { get; set; }
        [Property(Length = 255)]
        public String ContactoFiscal { get; set; }

        [HasMany(typeof(Escrutinio), ColumnKey = "MesaId", Inverse = true,Lazy = true)]
        public IList<Escrutinio> Escrutinios { get; set; }

        [HasMany(typeof(Escrutinio), ColumnKey = "MesaId", Inverse = true, Where = "Habilitado = 1")]
        public IList<Escrutinio> EscrutiniosHabilitados { get; set; }
        
        
       public Escrutinio Escrutinio(Lista lista, Categoria categoria)
       {
           return EscrutiniosHabilitados.First(esc => (esc.Lista == lista && esc.Categoria == categoria));
       }


        public IList<Categoria> CategoriasHabilitadas()
        {
            return EscrutiniosHabilitados.Select(e => e.Categoria).Distinct().ToList();
        }

        public IList<Categoria> CategoriasSimplificadas()
        {
            return EscrutiniosHabilitados.Select(e => e.Categoria).Distinct().Where(l => l.Simplificado).ToList();
        }


        public IList<Lista> ListasHabilitadas()
        {
            return EscrutiniosHabilitados.Select(e => e.Lista).Distinct().ToList();
        }

        public IList<Lista> ListasSimplicadas()
        {
            return EscrutiniosHabilitados.Select(e => e.Lista).Distinct().Where( l => l.Simplificado ).ToList();
        }
    }
}