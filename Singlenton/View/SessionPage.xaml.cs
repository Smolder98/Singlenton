using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Singlenton.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionPage : ContentPage
    {
        public SessionPage()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var usuario = Model.SessionManager.GetInstance.Usuario;

                txtMessage.Text = "La Sesion a sido iniciada !!!";
                txtMessage.TextColor = Color.Green;


                txtUser.Text = $"Usuario: {usuario.Username}";
                txtPass.Text = $"Contraseña: {usuario.Password}";
                txtDate.Text = $"DateTime: {Model.SessionManager.GetInstance.FechaInicio}";
            }
            catch (Exception ex)
            {

                txtMessage.Text = ex.Message;
                txtMessage.TextColor = Color.Red;
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.SessionManager.Logout();
                Message("Sesion cerrada correctamente");
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
        }

        private async void Message(string message)
        {
            await DisplayAlert("Aviso", message, "ok");
        }

        private async void btnSaveLog_Clicked(object sender, EventArgs e)
        {
            try
            {
                var usuario = Model.SessionManager.GetInstance.Usuario;
                var date = Model.SessionManager.GetInstance.FechaInicio;

                var log = new Model.Log
                {
                    Id=0,
                    Username = usuario.Username,
                    Date = date
                };

               var resp = await Services.DataBase.GetInstance.insertUpdateLog(log);

                if (resp == 1) Message("El log se guardo correctamente !!!");
                else Message("No se pudo guardar el log");                
            }
            catch (Exception ex)
            {

                Message(ex.Message);
            }
        }

        private async void btnListLog_Clicked(object sender, EventArgs e)
        {
            var listLogs = await Services.DataBase.GetInstance.getListLog();

            if (listLogs.Count == 0)
            {
                Message("No hay logs guardados");
                return;
            }

            await Navigation.PushAsync(new View.ListPage(listLogs));
        }
    }
}