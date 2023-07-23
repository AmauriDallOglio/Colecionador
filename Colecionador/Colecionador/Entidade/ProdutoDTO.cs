using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Colecionador.Entidade
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string CategoriaNome { get; set; }
        public int IdMarca { get; set; }
        public string MarcaNome { get; set; }
        public string NomeProduto { get; set; }
        public string AnoFabricacao { get; set; }
        //public DateTime DataCompra { get; set; }
        //public decimal ValorCompra { get; set; }
        //public DateTime DataVenda { get; set; }
        //public decimal ValorVenda { get; set; }

        //public List<Marca> TodasMarcas { get; set; }
        //public int IdMarcaSelecionada { get; set; }

        //public Byte[] ByteFoto { get; set; }
        //public ImageSource MinhaFotoImageSource { get; set; }

        //public string ImageUrl { get; set; }
 
        public string CaminhoFoto { get; set; }
        //internal class ListaTodasMarcas
        //{
        //    public List<Marca> TodasMarcas { get; set; }
        //}
    }
}
