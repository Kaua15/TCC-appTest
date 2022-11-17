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

        public Ocorrencia()
        {
            InitializeComponent();
            viewModelOcorrencia = new OcorrenciaViewModel();
            BindingContext = viewModelOcorrencia;
            getLocationAsync();
        }


        private async void btnEnviar_Clicked(object sender, EventArgs e)
        {
            var inserido = await viewModelOcorrencia.insertBD("problema 1", "descrição 1", latituteThis, longitudeThis);
            if (inserido)
            {
                await this.DisplayAlert("Opeação Concluida", "", "Ok");
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
            await this.DisplayAlert("Latitude", $"{Convert.ToString(latituteThis)} e {Convert.ToString(longitudeThis)}", "Ok");
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
            MenuDescricao.Animate("anim", callback, 0, -260, 16, 300, Easing.CubicInOut);

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
            CloseMenu();
        }
    }
}