using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salat.Features
{
    class Clock
    {
        public static string time()
        {
            var list = new List<DateTime>();
            list.Add(DateTime.Parse(Salat.Information.Salat.fajr.ToUpper()));
            list.Add(DateTime.Parse(Salat.Information.Salat.dhuhr.ToUpper()));
            list.Add(DateTime.Parse(Salat.Information.Salat.asr.ToUpper()));
            list.Add(DateTime.Parse(Salat.Information.Salat.maghrib.ToUpper()));
            list.Add(DateTime.Parse(Salat.Information.Salat.isha.ToUpper()));

            var searchTime = DateTime.Now;


            string y = null;
            var times = y;
            var times2 = list.FirstOrDefault(t => t > searchTime);
            if (times2.ToString().Contains("01/01/0001"))
            {
                var times1 = list.FirstOrDefault(t => t < searchTime);
                return times1.ToString();
            }else
            {
                var times1 = list.FirstOrDefault(t => t > searchTime);
                return times1.ToString();
            }



        }
    }
}
