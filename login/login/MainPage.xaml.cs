using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace login
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        string[] nombres = { "User" };
        string[] cont = { "123" };
        public MainPage()
        {
            InitializeComponent();
        }

        public bool validarUser()
        {
            string usuarios = txtUser.Text;

            for (int i = 0; i < nombres.Length; i++)
            {
                if (usuarios == nombres[i].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool validarCont()
        {
            string contra = txtPass.Text;

            for (int i = 0; i < cont.Length; i++)
            {
                if (contra == cont[i].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (validarUser() && validarCont())
            {
                ((NavigationPage)this.Parent).PushAsync(new PagPrincipal());
                label1.Text = "";
            }
            else
            {
                label1.Text = "El usuario o la contraseña no son correctos";
            }
        }
    }
}
