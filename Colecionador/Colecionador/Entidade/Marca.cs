using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Colecionador.Entidade
{
    [Table("Marca")]
    public class Marca
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
    }
}
