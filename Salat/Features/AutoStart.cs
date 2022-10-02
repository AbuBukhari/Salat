using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Salat.Features
{
    class AutoStart
    {
        public class StartUpManager
        {
            public static void AddApplicationToCurrentUserStartup()
            {
                string keyName = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                string valueName = "Salat";
                Console.Out.WriteLine(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true));
                if (Registry.GetValue(keyName, valueName, null) == null)
                { 
                    if (!AutoStart.StartUpManager.IsUserAdministrator())
                    {
                        MessageBox.Show("This program doesn't have Admin rights please reopen with admin rights");
                    }
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.SetValue("Salat", "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                    }
                }
                else
                {
                    //code if key Exist
                }



            }


            public static void RemoveApplicationFromCurrentUserStartup()
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("Salat", false);
                }
            }


            public static bool IsUserAdministrator()
            {
                //bool value to hold our return value
                bool isAdmin;
                try
                {
                    //get the currently logged in user
                    WindowsIdentity user = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(user);
                    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch (UnauthorizedAccessException ex)
                {
                    isAdmin = false;
                }
                catch (Exception ex)
                {
                    isAdmin = false;
                }
                return isAdmin;
            }
        }
    }
}
