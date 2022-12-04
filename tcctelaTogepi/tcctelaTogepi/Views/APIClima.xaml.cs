using System;
using System.Collections.Generic;
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
	public partial class APIClima : ContentPage
	{
        Root Clima;
        List<Forecast> listDay;
        public APIClima ()
		{

			_ = this.getInfo();

			InitializeComponent();
		}

        private async Task getInfo()
        {
            try
            {
                ClimaTempo ct = new ClimaTempo();
                Clima = await ct.GetClimaTempoAsync();
                listDay = Clima.results.forecast;
                temperatureTxt.Text = Convert.ToString(Clima.results.temp);
                todayCondition.Text = Clima.results.condition_slug;
                
                // Situação do Clima
                if(Clima.results.condition_slug == "cloudly_night" || Clima.results.condition_slug == "cloud" || Clima.results.condition_slug == "cloudly_day")
                {
                    todayCondition.Text = "Nublado";
                }
                else if(Clima.results.condition_slug == "hail" || Clima.results.condition_slug == "rain" || Clima.results.condition_slug == "storm")
                {
                    todayCondition.Text = "Chuva";
                }
                else if(Clima.results.condition_slug == "clear_day" || Clima.results.condition_slug == "clear_night")
                {
                    todayCondition.Text = "Limpo";
                }

                cityTxt.Text = Clima.results.city_name;
                dateTxt.Text = listDay[0].weekday + ", " + Clima.results.date;
                humidade.Text = Convert.ToString(Clima.results.humidity) + "%";
                ventos.Text = Clima.results.wind_speedy;
                
                max.Text = Convert.ToString(listDay[0].max) + "º";
                min.Text = Convert.ToString(listDay[0].min) + "º";

                dia2Nome.Text = listDay[1].weekday;
                dia3Nome.Text = listDay[2].weekday;
                dia4Nome.Text = listDay[3].weekday;
                dia5Nome.Text = listDay[4].weekday;

                datadia2.Text = listDay[1].date;
                datadia3.Text = listDay[2].date;
                datadia4.Text = listDay[3].date;
                datadia5.Text = listDay[4].date;

                tempdia2.Text = Convert.ToString(((listDay[1].max + listDay[1].min) / 2)) + "º";
                tempdia3.Text = Convert.ToString(((listDay[2].max + listDay[2].min) / 2)) + "º";
                tempdia4.Text = Convert.ToString(((listDay[3].max + listDay[3].min) / 2)) + "º";
                tempdia5.Text = Convert.ToString(((listDay[4].max + listDay[4].min) / 2)) + "º";

            }
            catch
            {

                throw;
            }

        }
        string getImage(string condition)
        {
            if(condition == "rain")
            {
                return "";
            }
            return "";
        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}