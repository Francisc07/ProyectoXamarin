﻿using System;
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
        public static int  monto ;
        public FinPedido()
        {
            InitializeComponent();



            Random rnd = new Random();

            monto = rnd.Next(499, 100001);

            lblMonto.Text = "₡ " + monto;
            lblNom.Text = PagPrincipal.nombreCliente;
            lblFecha.Text = fecha.ToString();
        }

        private void BtnFinalizar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Factura(0));
                
        }

    }
}