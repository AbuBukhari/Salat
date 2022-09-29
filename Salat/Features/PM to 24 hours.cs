using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salat.Features
{
    class PM_to_24_hours
    {
        /*  
                   Salat.Information.Salat.fajr = (string)rss["items"][0]["fajr"];
                   Salat.Information.Salat.dhuhr = (string)rss["items"][0]["dhuhr"];
                   Salat.Information.Salat.asr = (string)rss["items"][0]["asr"];
                   Salat.Information.Salat.maghrib = (string)rss["items"][0]["maghrib"];
                   Salat.Information.Salat.isha = (string)rss["items"][0]["isha"];
         */

        /* Convert PM to 24 hours system */
        public static void Converter24()
        {
            DateTime Fajr = Convert.ToDateTime(Salat.Information.Salat.fajr.ToUpper());
            Salat.Information.Salat.fajr = Fajr.ToString("HH:mm");

            DateTime Dhuhr = Convert.ToDateTime(Salat.Information.Salat.dhuhr.ToUpper());
            Salat.Information.Salat.dhuhr = Dhuhr.ToString("HH:mm");

            DateTime asr = Convert.ToDateTime(Salat.Information.Salat.asr.ToUpper());
            Salat.Information.Salat.asr = asr.ToString("HH:mm");

            DateTime maghrib = Convert.ToDateTime(Salat.Information.Salat.maghrib.ToUpper());
            Salat.Information.Salat.maghrib = maghrib.ToString("HH:mm");

            DateTime isha = Convert.ToDateTime(Salat.Information.Salat.isha.ToUpper());
            Salat.Information.Salat.isha = isha.ToString("HH:mm");
        }



    }
}
