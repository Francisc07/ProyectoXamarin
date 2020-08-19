using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagPrincipal : ContentPage
    {
        public static string nombreCliente,telefono,direccion;
        public static string mail;
        string[] datosCliente;
        public PagPrincipal(string rol)
        {
            InitializeComponent();
            if (rol == "Admin")
            {
                btnToNewUser.IsVisible = true;
                btnBitacora.IsVisible = true;
            }
            else {
                btnFactura.IsVisible = true;
                btnToSinQR.IsVisible = true;
                btnQr.IsVisible = true;
                btnBitacora.IsVisible = true;

            }
            btnToNewUser.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new NewUser());
            };
            btnToSinQR.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new EntregaSinQR());
            };
            btnFactura.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Factura(1));
            };
            btnBitacora.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new Bitacora());
            };

        }

        private async void Scanner()
        {
            var scannerPage = new ZXingScannerPage();

            scannerPage.Title = "Lector de QR";
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    Navigation.PopAsync();
                    char[] delimiterChars = {'\n' };

                    string text = result.Text;

                    string[] words = text.Split(delimiterChars);

                    foreach (var word in words)
                    {
                        datosCliente = words;
                    }
                    nombreCliente = datosCliente[0];
                    telefono = datosCliente[1];
                    mail = datosCliente[2];
                    direccion = datosCliente[3];

                    await DisplayAlert("Datos del cliente","Nombre: "+ nombreCliente + "\nTélefono: " + telefono + "\nMail: " + mail, "Ir a ubicacion");
                    await Browser.OpenAsync(new Uri(direccion), BrowserLaunchMode.SystemPreferred);

                    await Navigation.PushAsync(new FinPedido());

                });
                
            };
            await Navigation.PushAsync(scannerPage);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Scanner();
        }
    }
}