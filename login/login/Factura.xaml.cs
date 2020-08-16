using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using login.Model;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Factura : ContentPage
    {
        public Factura()
        {
            InitializeComponent();


            lblNombre.Text = PagPrincipal.nombreCliente;
            lblCorreo.Text = PagPrincipal.mail;
            lblTelefono.Text = PagPrincipal.telefono;
            lblfecha.Text = FinPedido.fecha.ToString();
            lblMonto.Text = "₡ " + FinPedido.monto;
        }

        private async void BtnFactura_Clicked(object sender, EventArgs e)
        {
            BitacoraRepository.Instancia.AddBit(lblNombre.Text, lblfecha.Text, lblMonto.Text);

            List<string> toAddress = new List<string>();
            toAddress.Add("" + lblCorreo.Text);
            await SendEmail("Factura de entrega Transremont", "Factura del Cliente \n Nombre Cliente: " + PagPrincipal.nombreCliente + "\n Correo: " + PagPrincipal.mail + "\n Telefono: " + PagPrincipal.telefono + "\n Fecha de entrega: " + FinPedido.fecha + "\n Monto Pagado: " + lblMonto.Text + "", toAddress);

            
        }
        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device  
            }
            catch (Exception ex)
            {
                // Some other exception occurred  
            }

            await Navigation.PushAsync(new PagPrincipal("Empleado"));
        }

        
    }
}