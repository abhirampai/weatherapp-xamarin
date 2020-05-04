using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace weatherapp.Models
{
    public class Constants
    {
        public static bool isDev = true;
        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MainTextColor = Color.White;
        public static string Weatherurl = "https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid=apiKey";//replace with your api key
        public static string Imgurl = "http://openweathermap.org/img/wn/{0}@2x.png";
    }
}
