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

        public async void LocalizarEscola()
        {
            try
            {
                Pin pinEtec = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Etec",
                    Address = "Rua Alcântara, 113, Vila Guilherme",
                    Position = new Position(-23.5200241d, -46.596498d)
                };
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }


    }

    
}
