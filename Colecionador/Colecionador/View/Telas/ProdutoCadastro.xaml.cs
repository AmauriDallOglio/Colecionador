using Colecionador.Entidade;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colecionador.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProdutoCadastro : ContentPage
    {
        //private byte[] byteFoto;
        public MarcaDTO marcaDTO;
        string caminhoFoto = "";
        public ProdutoCadastro(Produto produto, MarcaDTO marcaDTO)
        {
            InitializeComponent();
            this.marcaDTO = marcaDTO;

            //Foto.Source = ImageSource.FromStream(() => new MemoryStream(produto.ByteFoto));
            caminhoFoto = produto.CaminhoFoto;
            Foto.Source = caminhoFoto;
            BindingContext = produto;
        }

        async void BtnUpload(object sender, System.EventArgs e)
        {
            var pickerOptions = new PickMediaOptions
            {
                PhotoSize = PhotoSize.Small,
                CustomPhotoSize = 25, //Resize to 90% of original
                CompressionQuality = 25, //Photo Quality
                MaxWidthHeight = 150,
                SaveMetaData = false,
            };

            MediaFile file = await CrossMedia.Current.PickPhotoAsync(pickerOptions);
            caminhoFoto = file.Path;
            Foto.Source = caminhoFoto;

            //if (file != null)
            //{
            //    Foto.Source = ImageSource.FromStream(() => file.GetStream());
            //    using (MemoryStream memory = new MemoryStream())
            //    {
            //        Stream stream1 = file.GetStream();
            //        stream1.CopyTo(memory);
            //        byteFoto = memory.ToArray();
            //    }
            //}
            file.Dispose();
        }



        async void BtnSalvar(object sender, EventArgs e)
        {
            Produto produto = (Produto)BindingContext;
            produto.IdCategoria = marcaDTO.IdCategoria;
            produto.IdMarca = marcaDTO.Id;
            produto.CaminhoFoto = caminhoFoto;
            //if (byteFoto.Length > 0)
            //    produto.ByteFoto = byteFoto;

            await App.DataBase.ProdutoSalvar(produto);
            await Navigation.PopAsync();
        }

        async void BtnDeletar(object sender, EventArgs e)
        {

            var confirma = await DisplayAlert("Deletar ítem", "Deseja mesmo deletar o item?", "sim", "não");
            if (confirma)
            {
                Produto obj = (Produto)BindingContext;
                await App.DataBase.ProdutoDeletar(obj);
                await Navigation.PopAsync();
            }
        }
    }
}
