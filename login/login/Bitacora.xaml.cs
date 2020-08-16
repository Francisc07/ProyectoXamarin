using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bitacora : ContentPage
    {
        public Bitacora()
        {
            InitializeComponent();
            var allBit = BitacoraRepository.Instancia.GetBit();
            bitList.ItemsSource = allBit;
        }
    }
}