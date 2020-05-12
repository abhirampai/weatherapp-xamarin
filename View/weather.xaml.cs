using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weatherapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace weatherapp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class weather : ContentPage
	{
		public weather ()
		{
			InitializeComponent ();
            Init();
		}
        void Init()
        {
           // BackgroundColor = Constants.BackgroundColor;
           // label_Location.TextColor = Constants.MainTextColor;
            entry_Name.Completed += (s, e) => GetWeather_Clicked(s, e);
        }

        async void GetWeather_Clicked(object sender, EventArgs e)
        {
            var location = entry_Name.Text;
            var result = await App.RestService.GetWeather(location);
            if (result != null)
            {
                Console.WriteLine(result.WeatherElement[0].Icon);
             //   await DisplayAlert("Weather", "Temperature" + ":" + result.Main.Temp + "°C" + "\n" + "humidity" + ":" + result.Main.Humidity+"%", "Ok");
                await Navigation.PushAsync(new NavigationPage( new landingpage1(location)));
            }
            else {
                await DisplayAlert("Weather", "Location Not Available", "Ok");
            }
        }

       
    }
}