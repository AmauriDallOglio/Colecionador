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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarcaPage : ContentPage
    {
        public Categoria categoria;
        public MarcaPage(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.DataBase.TodasMarcasPorCategoria(categoria);
        }

        async void AdicionarMarca(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.IdCategoria = categoria.Id;
            await Navigation.PushAsync(new MarcaCadastro(marca, categoria.Nome));
        }

        async void Selecionar(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Marca itemSelecionado = e.SelectedItem as Marca;
                //Produto marcaRetorno = App.DataBase.MarcaPorId(itemSelecionado.Id);
                await Navigation.PushAsync(new MarcaCadastro(itemSelecionado, categoria.Nome));
            }
        }

    }
}