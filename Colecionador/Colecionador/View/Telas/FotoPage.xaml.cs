using Colecionador.Entidade;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotoPage : ContentPage
    {
        public FotoPage(Produto produto)
        {
            InitializeComponent();
 
            //Foto.Source = ImageSource.FromStream(() => new MemoryStream(produto.ByteFoto));
            String caminho = produto.CaminhoFoto;
            Foto.Source = caminho;

        }
    }
}