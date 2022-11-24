using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.Models;
using tcctelaTogepi.ViewModels;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ocorrencia : ContentPage
    {
        OcorrenciaViewModel viewModelOcorrencia;

        public double latituteThis;
        public double longitudeThis;
        public string tipoProblema;
        public string descricaoProblema;
        public Ocorrencia()
        {
            InitializeComponent();
            viewModelOcorrencia = new OcorrenciaViewModel();
            BindingContext = viewModelOcorrencia;
            getLocationAsync();
        }


        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            var inserido = await viewModelOcorrencia.insertBD(this.tipoProblema, descricaoProblema, latituteThis, longitudeThis);
            if (inserido)
            {
                await Navigation.PopAsync();
            }
        }

        public async void getLocationAsync()
        {
            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            var location = await result;

            latituteThis = location.Latitude;
            longitudeThis = location.Longitude;
        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OpenMenu()
        {
            MenuDescricao.IsVisible = true;

            Action<double> callback = input => MenuDescricao.TranslationY = input;
            MenuDescricao.Animate("anim", callback, 100, 0, 1, 250, Easing.CubicIn);
        }



        public void CloseMenu()
        {
            Action<double> callback = input => MenuDescricao.TranslationY = input;
            MenuDescricao.Animate("anim", callback, 0, 100, 16, 300, Easing.CubicInOut);
            MenuDescricao.IsVisible = false;
        }

        private void DescricaoAbaOpen(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void DescricaoAbaClose(object sender, EventArgs e)
        {
            CloseMenu();
        }

        private void btnDescConcluido_Clicked(object sender, EventArgs e)
        {
            this.descricaoProblema = txtDescricao.Text;

            CloseMenu();
        }

        private void btnProblema1_Clicked(object sender, EventArgs e)
        {
            this.tipoProblema = "Queda de Arvore";

            MenuTipoProblema.IsVisible = false;
        }

        private void btnProblema2_Clicked(object sender, EventArgs e)
        {
            this.tipoProblema = "Enchente";

            MenuTipoProblema.IsVisible = false;
        }

        private void btnProblema3_Clicked(object sender, EventArgs e)
        {
            this.tipoProblema = "Queimada";

            MenuTipoProblema.IsVisible = false;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            MenuTipoProblema.IsVisible = true;

            Action<double> callback = input => MenuTipoProblema.TranslationY = input;
            MenuTipoProblema.Animate("anim", callback, 100, 0, 1, 250, Easing.CubicIn);
        }
    }
}