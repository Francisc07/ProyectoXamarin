using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using login.Model;

namespace login
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

   

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text =="")
            {
                label1.Text = "Introduzca su usuario y contraseña";

            }
            else
            {
                
                var log = UserRepository.Instancia.Login(txtUser.Text, txtPass.Text);

                if (log.Count() == 0)
                {
                    label1.Text = "no existe";
                }
                else {
                    

                    if (log.First().Rol == 1)
                    {
                        Navigation.PushAsync(new PagPrincipal("Admin"));
                    }
                    else {
                        Navigation.PushAsync(new PagPrincipal("Empleado"));
                    }
                }
                

            }
        }
    }
}
