using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Salat.Information;
using System.Threading;
using System.Windows.Controls;
using System.Globalization;
using Salat.Features;

namespace Salat.API
{
    class Request
    {
        public static void api()
        {
            Internet_protocol.ip();
            Thread.Sleep(3000);
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("http://muslimsalat.com/daily/" + Salat.Information.Internet_protocol.City + "/false.json");
            JObject rss = JObject.Parse(downloadString);
            Information.Salat.fajr = (string)rss["items"][0]["fajr"];
            Information.Salat.dhuhr = (string)rss["items"][0]["dhuhr"];
            Information.Salat.asr = (string)rss["items"][0]["asr"];
            Information.Salat.maghrib = (string)rss["items"][0]["maghrib"];
            Information.Salat.isha = (string)rss["items"][0]["isha"];
            Weather.Temperature = (int)rss["today_weather"]["temperature"];
            Console.Out.WriteLine(Weather.Temperature);

            if (!(DateTimeFormatInfo.CurrentInfo.AMDesignator == ""))
            {
                PM_to_24_hours.Converter24();
            }
        }
    }
}
