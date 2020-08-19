using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregaSinQR : ContentPage
    {
        public EntregaSinQR()
        {
            InitializeComponent();
        }

        private async void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtCorreo.Text);

            if (txtNombre.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "")
            {
              await DisplayAlert("Error", "Todo los campos debe estar llenos","Ok");

            }
            else {
                if (match.Success)
                {
                    if (!double.TryParse(txtLat.Text, out double lat)) { return; }
                    if (!double.TryParse(txtLong.Text, out double lng)) { return; }
                    PagPrincipal.nombreCliente = txtNombre.Text;
                    PagPrincipal.mail = txtCorreo.Text;
                    PagPrincipal.telefono = txtTelefono.Text;
                    await Map.OpenAsync(lat, lng, new MapLaunchOptions { Name = "", NavigationMode = NavigationMode.None });
                    await Navigation.PushAsync(new FinPedido());
                }
                else
                {
                    await DisplayAlert("Error", "Correo no valido", "Ok");
                   
                }
            }
            
           

            
        }
    }
}