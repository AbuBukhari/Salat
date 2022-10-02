using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        public static string download = "";
        static void Main(string[] args)
        {
            Console.Title = "Updater";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Checking if process is running..");
            if (Process.GetProcessesByName($"Salat.exe").Length > 0)
            {
                Console.WriteLine("Program is running! Please close it");
                Console.ReadLine();
            }
            var web = new WebClient();
            string version = web.DownloadString("https://raw.githubusercontent.com/Vanix-k3rnel/Salat/1.0.1/version.txt");
            if (File.Exists("Salat.exe"))
            {
                string file = Directory.GetCurrentDirectory() + "/" + Path.GetFileName(download);
                string current_version = AssemblyName.GetAssemblyName("Salat.exe").Version.ToString();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Newer version is {version}");
                Console.WriteLine($"Current version is {current_version}");
                if (current_version != version)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No update!");
                    Console.Title = "No update available!!";
                    Console.WriteLine("You can exit this tool now! - Updater");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Diagnostics.Process.Start("https://github.com/Vanix-k3rnel/Salat");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cant find the file! going to github again.");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Diagnostics.Process.Start("https://github.com/Vanix-k3rnel/Salat");
            }
            Console.Clear();
            Console.Title = "Updating - Done";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You can exit this tool now! - Updater");
            Console.ReadLine();
        }
    }
}