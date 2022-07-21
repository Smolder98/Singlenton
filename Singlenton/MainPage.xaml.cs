using Singlenton.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Singlenton
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Message("Debe llenar los todos lo campos");
                return;
            }

            try
            {
                var usuario = new Usuario
                {
                    Username = username,
                    Password = password
                };

                SessionManager.Login(usuario);

                Message("Sesion Iniciada !!");

                ClearComponent();
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        private async void btnNextScreen_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.SessionPage());
        }

        private void ClearComponent()
        {
            txtPass.Text = String.Empty;
            txtUser.Text = String.Empty;
        }

        public async void Message(string message)
        {
            await DisplayAlert("Aviso", message, "ok");
        }

    }
}
