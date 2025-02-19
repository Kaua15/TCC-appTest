﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tcctelaTogepi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Firebase.Database;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms.Maps;
using tcctelaTogepi.Models;
using tcctelaTogepi.Services;

namespace tcctelaTogepi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        MapaViewModel viewModel;
        OcorrenciaRepository ocorrenciaRepository = new OcorrenciaRepository();
        public Mapa()
        {

            _ = this.getInfo();
            InitializeComponent();
            //var ocorrencias = await ocorrenciaRepository.GetAll();



            viewModel = new MapaViewModel();
            BindingContext = viewModel;
            MapaViewModel.mapa = map;

            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            viewModel.MoverCameraUsuarioAsync(result);
        }
        private async Task getInfo()
        {
            try
            {
                ClimaTempo ct = new ClimaTempo();
                Root Clima = await ct.GetClimaTempoAsync();
                temperaturaAtual.Text = Convert.ToString(Clima.results.temp) + "º";

                imgTempAtual.Source = ImageSource.FromFile(viewModel.getImage(Clima.results.condition_slug));
            }
            catch
            {
                throw;
            }

        }
        private void btnSend_Clicked(object sender, EventArgs e)
        {
            var page = new Ocorrencia();
            App.Current.MainPage.Navigation.PushAsync(page);
        }

        private void OpenApiClima(object sender, EventArgs e)
        {
            var page = new APIClima();
            App.Current.MainPage.Navigation.PushAsync(page);
        }

        protected override async void OnAppearing()
        {
            var ocorrencias = await ocorrenciaRepository.GetAll();
            foreach (Models.OcorrenciaModel o in ocorrencias)
            {
                Pin pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = o.tipoProblema,
                    Position = new Position(o.latitude, o.longitude),
                    Address = o.descricao
                };
                map.Pins.Add(pin);

            }

        }


        private void OpenMenu()
        {
            MenuGrid.IsVisible = true;

            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, -260, 0, 16, 300, Easing.CubicInOut);
        }
        public void CloseMenu()
        {
            Action<double> callback = input => MenuView.TranslationX = input;
            MenuView.Animate("anim", callback, 0, -260, 16, 300, Easing.CubicInOut);

            MenuGrid.IsVisible = false;
        }

        public void OpenMenuPesquisar()
        {
            Pesquisar.IsVisible = true;

            Action<double> callback = input => Pesquisar.TranslationY = input;
            Pesquisar.Animate("anim", callback, 100, 0, 1, 250, Easing.CubicIn);
        }

        private void CloseMenuPesquisar(object sender, EventArgs e)
        {

            Pesquisar.IsVisible = false;
        }

        private void btnMenu_Clicked(object sender, EventArgs e)
        {
            OpenMenu();
        }
        private void OverlayTapped(object sender, EventArgs e)
        {
            CloseMenu();
        }

        private void btnHome_Clicked(object sender, EventArgs e)
        {
            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            viewModel.MoverCameraUsuarioAsync(result);
        }

        private void btnBuscar_ClickedAsync(object sender, EventArgs e)
        {
        }

        private void btnSobre_Clicked(object sender, EventArgs e)
        {
            var pageSobre = new Sobre();
            App.Current.MainPage.Navigation.PushAsync(pageSobre);
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            var pageSobre = new Login();
            App.Current.MainPage.Navigation.PushAsync(pageSobre);
        }

        private void btnConfig_Clicked(object sender, EventArgs e)
        {
            var pageSobre = new Configuracoes();
            App.Current.MainPage.Navigation.PushAsync(pageSobre);
        }

        private void btnRelatar_Clicked(object sender, EventArgs e)
        {
            var pageSobre = new Configuracoes();
            App.Current.MainPage.Navigation.PushAsync(pageSobre);
        }

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            Pesquisar.IsVisible = true;

            Action<double> callback = input => Pesquisar.TranslationY = input;
            Pesquisar.Animate("anim", callback, 100, 0, 1, 150, Easing.CubicIn);
        }


        private async void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string address = txtPesquisar.Text;

                if (!string.IsNullOrEmpty(address))
                {
                    var locations = await Geocoding.GetLocationsAsync(address);

                    var location = locations?.FirstOrDefault();

                    if (location != null)
                    {
                        Position position = new Position(location.Latitude, location.Longitude);


                        viewModel.MoverCameraPesquisar(position);
                    }
                }
            }
            catch
            {

            }
        }
    }
}