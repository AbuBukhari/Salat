using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Toolkit.Uwp.Notifications;
using Salat.API;
using Salat.Features;
using Salat.Information;

namespace Salat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        System.Windows.Threading.DispatcherTimer Timer2 = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            Salat.API.Request.api();
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            DateTime timeValue = Convert.ToDateTime(Salat.Information.Salat.fajr.ToUpper());
            Fajr.Text = $"Fajr: {Salat.Information.Salat.fajr.ToUpper()}";
            Dhuhr.Text = $"Dhuhr: {Salat.Information.Salat.dhuhr.ToUpper()}";
            Maghrib.Text = $"Maghrib: {Salat.Information.Salat.maghrib.ToUpper()}";
            Asr.Text = $"Asr: {Salat.Information.Salat.asr.ToUpper()}";
            Isha.Text = $"Isha: {Salat.Information.Salat.isha.ToUpper()}";
            temperature.Text = $"{Weather.Temperature} ℃";
            Country.Text = Information.Internet_protocol.Country;
            Timer2.Tick += new EventHandler(refresh);
            Timer2.Interval = new TimeSpan(1, 0, 0);
            Timer2.Start();
        }

        private void refresh(object sender, EventArgs e)
        {
            Console.Out.WriteLine("out");
            Salat.API.Request.api();
            Fajr.Text = $"Fajr: {Salat.Information.Salat.fajr.ToUpper()}";
            Dhuhr.Text = $"Dhuhr: {Salat.Information.Salat.dhuhr.ToUpper()}";
            Maghrib.Text = $"Maghrib: {Salat.Information.Salat.maghrib.ToUpper()}";
            Asr.Text = $"Asr: {Salat.Information.Salat.asr.ToUpper()}";
            Isha.Text = $"Isha: {Salat.Information.Salat.isha.ToUpper()}";
            temperature.Text = $"{Weather.Temperature} ℃";
            Country.Text = Information.Internet_protocol.Country;
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            if (DateTime.Parse(Clock.time()) > DateTime.Now)
            {
                var z = DateTime.Parse(Clock.time()) - DateTime.Now;
                var x = DateTime.Parse(z.ToString());
                time.Text = x.ToString("HH:mm:ss"); ;
            }else
            {
                Console.Out.WriteLine(Clock.time());
                var z = DateTime.Now  - DateTime.Parse(Clock.time());
                var x = DateTime.Parse(z.ToString());
                time.Text = x.ToString("HH:mm:ss");
            }

            string total = d.ToString("HH:mm");


            if (total.Contains(Information.Salat.fajr))
            {

                new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Fajr Salah")
                .AddText("Its Time to pray Fajr..")
                .Show();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "1.mp3";
                player.Play();
                Thread.Sleep(60000);
            }

            if (total.Contains(Information.Salat.dhuhr))
            {
                new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Dhuhr Salah")
                .AddText("Its Time to pray Dhuhr..")
                .Show();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "1.wav";
                player.Play();
                Thread.Sleep(60000);
            }

            if (total.Contains(Information.Salat.maghrib))
            {
                new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Maghrib Salah")
                .AddText("Its Time to pray Maghrib..")
                .Show();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "1.wav";
                player.Play();
                Thread.Sleep(60000);
            }

            if (total.Contains(Information.Salat.asr))
            {

                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Asr Salah")
                .AddText("Its Time to pray Asr..")
                .Show();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "1.wav";
                player.Play();
                Thread.Sleep(60000);
            }

            if (total.Contains(Information.Salat.isha))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Isha Salah")
                .AddText("Its Time to pray Isha..")
                .Show();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "1.wav";
                player.Play();
                Thread.Sleep(60000);
            }


        }
    }
}
