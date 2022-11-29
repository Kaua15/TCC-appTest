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
    public partial class RelatarProblema : ContentPage
    {
        public RelatarProblema()
        {
            InitializeComponent();
        }


        private async void btnVoltarTela_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}