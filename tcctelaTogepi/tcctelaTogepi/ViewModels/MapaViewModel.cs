using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace tcctelaTogepi.ViewModels
{

    public class MapaViewModel
    {
        public static Map mapa;
        public MapaViewModel()
        {
            mapa = new Map();


        }

        public string getImage(string condition)
        {
            if (condition == "storm")
            {
                return "ic_tempestade";
            }
            else if (condition == "snow")
            {
                return "ic_snow";
            }
            else if (condition == "hail")
            {
                return "ic_hailstorm";
            }
            else if (condition == "rain")
            {
                return "ic_rainy";
            }
            else if (condition == "clear_day")
            {
                return "ic_sunshine";
            }
            else if (condition == "clear_night")
            {
                return "ic_noiteLimpa";
            }
            else if (condition == "cloud")
            {
                return "ic_cloud";
            }
            else if (condition == "cloudly_day")
            {
                return "ic_cloudDia";
            }
            else if (condition == "cloudly_night")
            {
                return "ic_cloudNoite";
            }
            return "";
        }

        public async void MoverCameraUsuarioAsync(Task<Xamarin.Essentials.Location> userPosition)
        {
            try
            {
                var resultuserPosition = await userPosition;
                Position position = new Position(resultuserPosition.Latitude, resultuserPosition.Longitude);
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(position, Xamarin.Forms.Maps.Distance.FromKilometers(1)));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public void MoverCameraPesquisar(Position posiPesquisa)
        {
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(posiPesquisa, Xamarin.Forms.Maps.Distance.FromKilometers(1)));
        }
    }


}
