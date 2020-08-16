using login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUser : ContentPage
    {
        public NewUser()
        {
            InitializeComponent();
            BtnInsert.Clicked += BtnInsert_Clicked;
            BtnAllUser.Clicked += BtnAllUser_Clicked;
        }

        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {
            var allUsers = UserRepository.Instancia.GetAllUsers();
            userList.ItemsSource = allUsers;
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
        }

        /*Se agrega el nuevo user*/
        private void BtnInsert_Clicked(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPass1.Text == "" || txtPass2.Text == "" || txtRol.Text == "")
            {
                StatusMessage.Text = "Todos los campos deben estar llenos";
            }
            else {
                if (txtRol.Text !=  "1" && txtRol.Text != "2")
                {
                    StatusMessage.Text = "Los roles deben ser 1 o 2";
                }
                else {
                    StatusMessage.Text = string.Empty;
                    UserRepository.Instancia.AddNewUser(txtUsuario.Text, txtPass1.Text, txtPass2.Text, int.Parse(txtRol.Text));
                    StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
                }
            }
                
        }
    }
}