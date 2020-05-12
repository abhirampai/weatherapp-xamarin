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
	public partial class landingpage1 : ContentPage
	{
		public landingpage1 (string name)
		{
			InitializeComponent ();
            FFImageLoading.Svg.Forms.SvgCachedImage.Init();
            initAsync(name);
		}
        async void initAsync(string name)
        {
           
            var result = await App.RestService.GetWeather(name);
            if (result != null)
            {
                Place_Name.Text = result.Name.ToUpper()+","+result.Sys.Country;
                Console.WriteLine(result.WeatherElement[0].Icon);
                image.IsVisible = true;
                image.Source = string.Format(Constants.Imgurl, result.WeatherElement[0].Icon);
                Main.Source = result.WeatherElement[0].Main + ".gif";
                Temperature.Text = result.Main.Temp.ToString();
                Description.Text = result.WeatherElement[0].Description;
                Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                humidityLabel.Text = result.Main.Humidity.ToString();
                wind.Text = result.Wind.Speed.ToString() + " m/s";
                pressure.Text = result.Main.Pressure.ToString() + " hpa";
                Cloud.Text = result.Clouds.All.ToString() + "%";


            }
        }
	}
}