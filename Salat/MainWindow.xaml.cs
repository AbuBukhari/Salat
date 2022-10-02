using System;
using System.Collections.Generic;
using System.Globalization;
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

        System.Windows.Threading.DispatcherTimer refresh_timer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            Settings.Reader();
            Console.Out.WriteLine(DateTime.Now.ToString("dd/MMM/yyyy", new CultureInfo("ar")));
            Salat.API.Request.api();
            InitializeComponent();
            if (Information.App.app)
            {
                start.IsChecked = true; 
            }else
            {
                start.IsChecked = false;
            }

            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            DateTime timeValue = Convert.ToDateTime(Salat.Information.Salat.fajr.ToUpper());
            Fajr.Text = $"Fajr: {Salat.Information.Salat.fajr.ToUpper()}";
            Dhuhr.Text = $"Dhuhr: {Salat.Information.Salat.dhuhr.ToUpper()}";
            Maghrib.Text = $"Maghrib: {Salat.Information.Salat.maghrib.ToUpper()}";
            Asr.Text = $"Asr: {Salat.Information.Salat.asr.ToUpper()}";
            Isha.Text = $"Isha: {Salat.Information.Salat.isha.ToUpper()}";
            hijri.Text = $"{DateTime.Now.ToString("MMM", new CultureInfo("ar"))}";
            Country.Text = Information.Internet_protocol.Country;
            refresh_timer.Tick += new EventHandler(refresh);
            refresh_timer.Interval = new TimeSpan(1, 0, 0);
            refresh_timer.Start();
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
            hijri.Text = $"{DateTime.Now.ToString("MMM", new CultureInfo("ar"))}";
            Country.Text = Information.Internet_protocol.Country;
        }



        private void CheckboxFalse(object sender, RoutedEventArgs e)
        {
            Information.App.app = false;
            Features.Settings.Writer(Information.Salat.Azan, Information.App.app);
            if (!AutoStart.StartUpManager.IsUserAdministrator())
            {
                MessageBox.Show("This program doesn't have Admin rights please reopen with admin rights");
            }
            AutoStart.StartUpManager.RemoveApplicationFromCurrentUserStartup();
        }


        private void CheckboxTrue(object sender, RoutedEventArgs e)
        {
            Information.App.app = true;
            Features.Settings.Writer(Information.Salat.Azan, Information.App.app);
            AutoStart.StartUpManager.AddApplicationToCurrentUserStartup(); 
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
