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
        DateTime fecha = DateTime.Now;
        public FinPedido()
        {
            InitializeComponent();








            lblNom.Text = PagPrincipal.nombreCliente;
            lblFecha.Text = fecha.ToString();
        }

        private void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            if (Monto.Text == "")
            {
                StatusMessage.Text = "Por favor introduzaca el monto";
            }
            else
            {
                StatusMessage.Text = string.Empty;
                BitacoraRepository.Instancia.AddBit(PagPrincipal.nombreCliente, fecha.ToString(), float.Parse(Monto.Text));
                StatusMessage.Text = BitacoraRepository.Instancia.EstadoMensaje;
            }
        }

    }
}