using System;
using System.Collections.Generic;
using System.Text;

namespace Colecionador.Entidade
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorDiferenca { get; set; }
        public string ValorString { get; set; }
    }
}
