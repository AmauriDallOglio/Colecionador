using SQLite;
using System.Collections.ObjectModel;

namespace Colecionador.Entidade
{
    [Table("Categoria")]
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Nome { get; set; }

        //public Categoria()
        //{
        //}
    }
}
