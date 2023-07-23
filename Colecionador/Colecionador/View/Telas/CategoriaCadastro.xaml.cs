using Colecionador.Entidade;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaCadastro : ContentPage
    {
        public CategoriaCadastro()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var categoria = (Categoria)BindingContext;
            //categoria.Date = DateTime.Now.Date;
            await App.DataBase.CategoriaSalvar(categoria);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var categoria = (Categoria)BindingContext;
            await App.DataBase.CategoriaDeletar(categoria);
            await Navigation.PopAsync();
        }
    }
}