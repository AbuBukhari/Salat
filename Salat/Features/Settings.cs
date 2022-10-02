using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Windows.Media;
using System.IO;

namespace Salat.Features
{
    class Settings
    {
        public static void Writer(bool azan, bool autostart)
        {
            JObject rss =
                new JObject(
                    new JProperty("Config",
                        new JObject(
                            new JProperty("Azan", azan),
                            new JProperty("Autostart", autostart))));

            Console.Out.WriteLine(rss.ToString());
            File.Create("Config.json").Close();
            File.AppendAllText("Config.json", rss.ToString());
        }



        public static void Reader()
        {
            if (File.Exists("Config.json"))
            {
                string JSON = File.ReadAllText("Config.json");
                JObject rss = JObject.Parse(JSON);
                Information.Salat.Azan = (bool)rss["Config"]["Azan"];
                Information.App.app = (bool)rss["Config"]["Autostart"];
            }
            else
            {
                Writer(Information.Salat.Azan, Information.App.app);
            }
        }

    }
}
