using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sobre : ContentPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private async void btnVoltarPagina_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}