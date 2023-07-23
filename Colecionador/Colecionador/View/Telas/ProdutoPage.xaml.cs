using Colecionador.Entidade;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoPage : ContentPage
    {
        public MarcaDTO marcaDTO;
        public ProdutoPage(MarcaDTO marcaDTO)
        {
            InitializeComponent();
            this.Title = marcaDTO.Nome;
            this.marcaDTO = marcaDTO;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var listaProdutos = await App.DataBase.ProdutoTodosPorMarca(marcaDTO.IdCategoria, marcaDTO.Id);
            List<ProdutoDTO> MeusItems = new List<ProdutoDTO>();
            foreach (var produto in listaProdutos)
            {
                MeusItems.Add(new ProdutoDTO
                {
                    Id = produto.Id,
                    IdCategoria = produto.IdCategoria,
                    CategoriaNome = marcaDTO.NomeCategoria,
                    IdMarca = produto.IdMarca,
                    MarcaNome = marcaDTO.Nome,
                    NomeProduto = produto.NomeProduto,
                    AnoFabricacao = produto.AnoFabricacao,
                    //ByteFoto = produto.ByteFoto,
                    CaminhoFoto = produto.CaminhoFoto,

                });
            }

            //quando usado array
            //List<ProdutoDTO> MeusItemsGrid = new List<ProdutoDTO>();
            //foreach (var produtoDtoGrid in MeusItems)
            //{
            //    ImageSource foto = ImageSource.FromStream(() => new MemoryStream(produtoDtoGrid.ByteFoto));
            //    produtoDtoGrid.MinhaFotoImageSource = foto;
            //    MeusItemsGrid.Add(produtoDtoGrid);
            //}
            //ItemsListView.ItemsSource = MeusItemsGrid;

            ItemsListView.ItemsSource = MeusItems;
        }


        async void ListaProdutos(object sender, EventArgs e)
        {

            await DisplayAlert("Ops!", "Tela em desenvolvimento", "OK");
            //await Navigation.PushAsync(new ProdutosListagem { });
        }

        async void AdicionarProduto(object sender, EventArgs e)
        {
            Produto produto = new Produto
            {
                IdCategoria = marcaDTO.IdCategoria,
                //CategoriaNome = marcaDTO.NomeCategoria,
                IdMarca = marcaDTO.Id,
                //MarcaNome = marcaDTO.Nome,
                DataCompra = DateTime.Now.Date,
                DataVenda = DateTime.Now.Date
            };
            await Navigation.PushAsync(new ProdutoCadastro(produto, marcaDTO));
        }

        async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ProdutoDTO itemSelecionado = e.SelectedItem as ProdutoDTO;
                Produto produtoRetorno = App.DataBase.ProdutoPorId(itemSelecionado.Id);
                await Navigation.PushAsync(new ProdutoCadastro(produtoRetorno, marcaDTO));
            }
        }


        async void OnChartTapGestureTap(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var myObject = args.Parameter;
            int id = Convert.ToInt16(myObject);

            Produto produtoRetorno = App.DataBase.ProdutoPorId(id);
            if (produtoRetorno != null)
                await Navigation.PushAsync(new FotoPage(produtoRetorno));
            else
                await DisplayAlert("Mensagem de aviso", "Selecione um registro para cadastrar uma imagem!", "OK");
        }

    }
}