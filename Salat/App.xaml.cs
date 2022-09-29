using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Threading;

namespace Salat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        private const string MutexName = "##||Salat||##";
        private readonly Mutex _mutex;
        bool createdNew;


        public App()
        {
            // overloaded mutex constructor which outs a boolean
            // telling if the mutex is new or not.
            // see http://msdn.microsoft.com/en-us/library/System.Threading.Mutex.aspx
            _mutex = new Mutex(true, MutexName, out createdNew);
            if (!createdNew)
            {
                // if the mutex already exists, notify and quit
                MessageBox.Show("This program is already running");
                Application.Current.Shutdown(0);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!createdNew) return;
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;
            
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Click += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = Salat.Properties.Resources.MyIcon;
            _notifyIcon.Visible = true;

            CreateContextMenu();


            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Salat app")
            .AddText("Running in background..")
            .Show();

        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open.").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
            }
        }
    }
}