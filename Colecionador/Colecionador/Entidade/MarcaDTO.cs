using System;
using System.Collections.Generic;
using System.Text;

namespace Colecionador.Entidade
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public int QuantidadeProduto { get; set; }
        public string Descricao { get; set; }
    }
}
