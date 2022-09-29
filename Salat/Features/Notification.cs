using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salat.Features
{
    class Notification
    {
        public void loop()
        {
            System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        public void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;

            string total = d.ToString("HH:mm");


        }
    }
}
