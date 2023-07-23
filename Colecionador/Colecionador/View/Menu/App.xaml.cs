using Colecionador.DataBase;
using Colecionador.View;
using System;
using System.IO;
using Xamarin.Forms;

namespace Colecionador
{
    public partial class App : Application
    {
        static BancoDados bancoDados;
        public static BancoDados DataBase
        {
            get
            {
                //var basePath = "/storage/emulated/0/Android/data/com.companyname.colecionador/files/";
                //var databasePath = Path.Combine(basePath, "Colecionador.db3");
                //File.Delete(databasePath);


                if (bancoDados == null)
                {
                    string sourcefolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);                                    //"/data/user/0/com.companyname.colecionador/files"
                    string libraryfolder = Path.Combine(sourcefolder, "..", "Library");                                                        //"/data/user/0/com.companyname.colecionador/files/../Library"
                    string filesfolder = Path.Combine(libraryfolder, "files");                                                                 //"/data/user/0/com.companyname.colecionador/files/../Library/files"
                    string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Colecionador");   //"/data/user/0/com.companyname.colecionador/files/.local/share/Colecionador"
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);                                  //"/data/user/0/com.companyname.colecionador/files/.local/share"
                    var databasePath = Path.Combine(basePath, "Colecionador.db3");                                                             //"/data/user/0/com.companyname.colecionador/files/.local/share/Colecionador.db3"
           
                    //File.Delete(basePath);
                    //File.Delete(databasePath);
                    //File.Delete(folder);
                    bancoDados = new BancoDados(databasePath);
                }
                return bancoDados;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Principal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
