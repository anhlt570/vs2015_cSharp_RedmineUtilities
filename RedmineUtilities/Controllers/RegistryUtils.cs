using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class RegistryUtils
    {
        public static void createValue(string name, string value)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RedmineUtilities",true);
            if(registryKey == null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\RedmineUtilities");
            }
            registryKey.SetValue(name, value);
            registryKey.Close();
        }

        public static string getStringValue(string name)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RedmineUtilities");
            if (registryKey == null)
            {
                return "";
            }
            return (string)registryKey.GetValue(name);
        }

        public static void removeValue(string name)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RedmineUtilities",true);
            if (registryKey == null)
            {
                return;
            }
            if (registryKey.GetValue(name) != null)
            {
                registryKey.SetValue(name, "");
            }
            registryKey.Close();
        }

    }
}
