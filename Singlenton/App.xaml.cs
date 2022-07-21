using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Singlenton
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());

            //Para crear la base de datos al instalar la aplicacion
            _= Services.DataBase.GetInstance;

            
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
