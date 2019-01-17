using System;
using WeatherAppExample.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherAppExample
{
    public partial class App : Application
    {
        // yhYbLiMkceMbawRZiFm1Qmq5egGbbubH

        public App()
        {
            InitializeComponent();

            MainPage = new WeatherForcastPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
