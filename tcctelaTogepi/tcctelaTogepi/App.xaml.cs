using System;
using tcctelaTogepi.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tcctelaTogepi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Configuracoes());
            // MainPage = new Ocorrencia();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
