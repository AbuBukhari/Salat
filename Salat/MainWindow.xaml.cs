using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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
namespace Salat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            Salat.API.Request.api();
            InitializeComponent();
            DateTime timeValue = Convert.ToDateTime(Salat.Information.Salat.fajr.ToUpper());
            Fajr.Text = $"Fajr: {Salat.Information.Salat.fajr.ToUpper()}";
            Dhuhr.Text = $"Dhuhr: {Salat.Information.Salat.dhuhr.ToUpper()}";
            Maghrib.Text = $"Maghrib: {Salat.Information.Salat.maghrib.ToUpper()}";
            Asr.Text = $"Asr: {Salat.Information.Salat.asr.ToUpper()}";
            Isha.Text = $"Isha: {Salat.Information.Salat.isha.ToUpper()}";
            List<string> list = new List<string>();
            list.Add(Salat.Information.Salat.fajr.ToUpper());
            list.Add(Salat.Information.Salat.dhuhr.ToUpper());
            list.Add(Salat.Information.Salat.maghrib.ToUpper());
            list.Add(Salat.Information.Salat.asr.ToUpper());
            list.Add(Salat.Information.Salat.isha.ToUpper());

            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;
            d = DateTime.Now;
            string total = d.ToString("HH:mm");

            if (total.Contains(Information.Salat.fajr))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Fajr Salah")
                .AddText("Its Time to pray Fajr..")
                .Show();
            }

            if (total.Contains(Information.Salat.dhuhr))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Dhuhr Salah")
                .AddText("Its Time to pray Dhuhr..")
                .Show();
            }

            if (total.Contains(Information.Salat.maghrib))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Maghrib Salah")
                .AddText("Its Time to pray Maghrib..")
                .Show();
            }

            if (total.Contains(Information.Salat.asr))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Asr Salah")
                .AddText("Its Time to pray Asr..")
                .Show();
            }

            if (total.Contains(Information.Salat.isha))
            {
                new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                .AddText("Isha Salah")
                .AddText("Its Time to pray Isha..")
                .Show();
            }

            time.Text = d.ToString("HH:mm:ss"); ;

        }
    }
}
