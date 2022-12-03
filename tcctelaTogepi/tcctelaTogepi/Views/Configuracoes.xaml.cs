using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.Models;
using tcctelaTogepi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracoes : ContentPage
    {
        Root Clima;

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
                Clima = await ct.GetClimaTempoAsync();

                txtTeste.Text = Clima.results.img_id;
            }
            catch
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