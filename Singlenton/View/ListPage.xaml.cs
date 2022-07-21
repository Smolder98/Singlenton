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
    public partial class ListPage : ContentPage
    {
 

        public ListPage(List<Model.Log> logs)
        {
           InitializeComponent();

            listLogs.ItemsSource = logs;
        }

        private void listLogs_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var log = e.Item as Model.Log;

            DeleteLog(log);
        }

        private async void DeleteLog(Model.Log log)
        {
            try
            {
                if (await DisplayAlert("Aviso", "¿ QUIERE ELIMINAR ESTE LOG ?", "SI", "NO"))
                {
    
                    if (await Services.DataBase.GetInstance.deleteLog(log) > 0)
                    {
                        await DisplayAlert("Aviso","Log eliminado correctamente", "OK");

                        listLogs.ItemsSource = await Services.DataBase.GetInstance.getListLog();
                    }
                    else
                       await DisplayAlert("Aviso", "No se a podido eliminar el log", "OK");
    
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Aviso", ex.Message, "OK");
            }

        }
    }
}