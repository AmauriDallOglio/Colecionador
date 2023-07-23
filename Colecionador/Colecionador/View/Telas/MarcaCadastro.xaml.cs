using Colecionador.Entidade;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarcaCadastro : ContentPage
    {
        public MarcaCadastro(Marca marca, string NomeCategoria)
        {
            InitializeComponent();
            this.Title = "Cadastro de marca";
            BindingContext = marca;
        }

        async void BtnSalvar(object sender, EventArgs e)
        {
            Marca obj = (Marca)BindingContext;
            await App.DataBase.MarcaSalvar(obj);
            await Navigation.PopAsync();
        }

        async void BtnDeletar(object sender, EventArgs e)
        {
            Marca obj = (Marca)BindingContext;
            await App.DataBase.MarcaDeletar(obj);
            await Navigation.PopAsync();
        }

    }
}