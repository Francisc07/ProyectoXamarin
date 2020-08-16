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
            StatusMessage.Text = string.Empty;
            UserRepository.Instancia.AddNewUser(txtUsuario.Text, txtPass1.Text, txtPass2.Text);
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
        }
    }
}