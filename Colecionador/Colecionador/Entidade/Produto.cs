using SQLite;
using System;

namespace Colecionador.Entidade
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        [MaxLength(20)]
        public string NomeProduto { get; set; }
        [MaxLength(4)]
        public string AnoFabricacao { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
        //public Byte[] ByteFoto { get; set; }
        [MaxLength(350)]
        public string CaminhoFoto { get; set; }


    }
}
