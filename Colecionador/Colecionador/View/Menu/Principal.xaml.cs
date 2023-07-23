using Colecionador.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Colecionador.View
{
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //listView.ItemsSource = await App.DataBase.CategoriaTodas();

            var listaCategoria = await App.DataBase.CategoriaTodas();
            List<CategoriaDTO> categoriaDTO = new List<CategoriaDTO>();
            foreach (var categoria in listaCategoria)
            {
                List<Produto> listaTodosProdutosCategoria = await App.DataBase.ListaTodosProdutosCategoria(categoria);
                int quantidadeProdutos = listaTodosProdutosCategoria.Count;
                decimal valorCompra = listaTodosProdutosCategoria.Select(a => a.ValorCompra).Sum();
                decimal valorVenda = listaTodosProdutosCategoria.Select(a => a.ValorVenda).Sum();
                decimal valorDiferenca = valorVenda - valorCompra;
                categoriaDTO.Add(new CategoriaDTO
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    QuantidadeProduto = quantidadeProdutos,
                    ValorCompra = valorCompra,
                    ValorVenda = valorVenda,
                    //ValorDiferenca = valorDiferenca,
                    ValorString = "Compra (" + valorCompra.ToString() + ") Venda (" + valorVenda.ToString() + ")  Ganho (" + valorDiferenca.ToString() + ")"  

                });
            }
            listView.ItemsSource = categoriaDTO;
        }

        async void OnClickCategoria(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaPage
            {
                BindingContext = new Categoria()
            });
        }

        async void SelecionaCategoria(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ColecaoPage(e.SelectedItem as CategoriaDTO));
            }
        }

        async void Sair(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Alerta", "Deseja realmente sair?", "Sim", "Não");
            if (result)
            {
                System.Environment.Exit(0);
            }
        }

        async void Sobre(object sender, EventArgs e)
        {
            await DisplayAlert("Ops!", "Tela em desenvolvimento", "OK");
        }
    }
}