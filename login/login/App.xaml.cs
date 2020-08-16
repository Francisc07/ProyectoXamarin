using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using login.Model;

namespace login
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UserRepository.Inicializador(filename);
            BitacoraRepository.Inicializador(filename);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
