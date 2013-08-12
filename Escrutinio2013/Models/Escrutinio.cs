using System.Collections.Generic;
using Castle.ActiveRecord;

namespace Escrutinio2013.Models
{
    [ActiveRecord]
    public class Escrutinio:ActiveRecordBase<Escrutinio>
    {
        [PrimaryKey(PrimaryKeyType.Identity)]
        public int Id { get; set; }
        [BelongsTo("MesaId")]
        public Mesa Mesa { get; set; }
        [BelongsTo("ListaId")]
        public Lista Lista { get; set; }
        [BelongsTo("CategoriaId")]
        public Categoria Categoria { get; set; }
        [Property]
        public int Cantidad { get; set; }
        [Property]
        public bool Habilitado { get; set; }

        public static void FastUpdate(Dictionary<int,int> valores)
        {
            var sessionFactoryHolder = ActiveRecordMediator.GetSessionFactoryHolder();
            var sess = sessionFactoryHolder.CreateSession(typeof(Escrutinio));
            var conn = sess.Connection;

            foreach (var valor in valores)
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "Update Escrutinios Set Cantidad=" + valor.Value + " Where id=" + valor.Key;
                cmd.ExecuteNonQuery();    
            }
            
            sessionFactoryHolder.ReleaseSession(sess);
        }
        
    }
}