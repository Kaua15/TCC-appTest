using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracoes : ContentPage
    {
        public Configuracoes()
        {
            _ = this.Teste();

            InitializeComponent();
        }

        private async Task Teste()
        {
            try
            {
                ClimaTempo ct = new ClimaTempo();
                await ct.GetClimaTempoAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}