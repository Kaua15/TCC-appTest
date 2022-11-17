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
            var inserido = await viewModelOcorrencia.insertBD("problema 1", "descrição 1");
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
            longitudeThis = location.Latitude;
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void OpenMenu()
        {
            MenuDescricao.IsVisible = true;

            Action<double> callback = input => MenuDescricao.TranslationX = input;
            MenuDescricao.Animate("anim", callback, 0, 0, 16, 300, Easing.CubicInOut);
        }



        public void CloseMenu()
        {
            Action<double> callback = input => MenuDescricao.TranslationX = input;
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