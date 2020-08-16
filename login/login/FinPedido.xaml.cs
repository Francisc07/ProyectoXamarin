using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using login.Model;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinPedido : ContentPage
    {
        public static DateTime fecha = DateTime.Now;
        public FinPedido()
        {
            InitializeComponent();








            lblNom.Text = PagPrincipal.nombreCliente;
            lblFecha.Text = fecha.ToString();
        }

        private void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Factura());
                
        }

    }
}