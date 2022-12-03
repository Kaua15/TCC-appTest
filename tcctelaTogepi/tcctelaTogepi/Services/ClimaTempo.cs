using tcctelaTogepi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Collections.ObjectModel;

namespace tcctelaTogepi.Services
{
    public class ClimaTempo : Request
    {
        private readonly Request _request;
        string token = "";
        string ApiUrlBase = "";
        public double latituteThis;
        public double longitudeThis;

        public async void getLocationAsync()
        {
            var result = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
            var location = await result;

            latituteThis = location.Latitude;
            longitudeThis = location.Longitude;
        }

        public ClimaTempo()
        {
            _request = new Request();

            token = "e2aede19";
            ApiUrlBase = $"https://api.hgbrasil.com/weather?{token}19&lat={latituteThis}&lon={longitudeThis}&user_ip=remote";
        }

        public async Task<Root> GetClimaTempoAsync()
        {

            Models.Root listaPrevisao = await _request.GetAsync<Models.Root>(ApiUrlBase);
            return listaPrevisao;
        }




    }
}
