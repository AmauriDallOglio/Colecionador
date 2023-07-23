using Colecionador.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColecaoPage : ContentPage
    {
        public Categoria categoria = new Categoria();
        public ColecaoPage(CategoriaDTO categoriaParametroDTO)
        {
 
            this.Title = categoriaParametroDTO.Nome;
            InitializeComponent();
            categoria.Id = categoriaParametroDTO.Id;
            categoria.Nome = categoriaParametroDTO.Nome;
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Marca> listaMarca = await App.DataBase.TodasMarcasPorCategoria(categoria);
            List<int> tipoDeMarca = listaMarca.Select(a => a.Id).Distinct().ToList();
            List<MarcaDTO> dto = new List<MarcaDTO>();

            foreach (var marca in listaMarca)
            {
                List<Produto> produtos = await App.DataBase.ProdutoTodosPorMarca(marca.IdCategoria, marca.Id);
                int quantidade = produtos.Count;
                dto.Add(new MarcaDTO
                {
                    Id = marca.Id,
                    Nome = marca.Nome,
                    IdCategoria = marca.IdCategoria,
                    NomeCategoria = categoria.Nome,
                    QuantidadeProduto = quantidade,
                    Descricao = categoria.Nome + " - " + marca.Nome,
                }); ;
            }

            listView.ItemsSource = dto;

        }

        async void AdicionarMarca(object sender, EventArgs e)
        {
            //Marca marca = new Marca();
            //marca.IdCategoria = categoria.Id;
            //marca.NomeCategoria = categoria.Nome;

            await Navigation.PushAsync(new MarcaPage(categoria));
        }



        async void SelecionaMarca(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ProdutoPage(e.SelectedItem as MarcaDTO));
            }
        }
    }
}