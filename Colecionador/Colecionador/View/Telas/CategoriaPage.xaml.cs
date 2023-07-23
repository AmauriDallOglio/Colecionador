using Colecionador.Entidade;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Colecionador.View
{
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();
   
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Categoria> categoria = await App.DataBase.CategoriaTodas();
            listViewCategoria.ItemsSource = categoria;
        }

        async void Adicionar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriaCadastro
            {
                BindingContext = new Categoria()
            });
        }

        async void SelecionaCategoria(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                await Navigation.PushAsync(new CategoriaCadastro
                {
                    BindingContext = e.SelectedItem as Categoria
                });
            }
        }
    }
}