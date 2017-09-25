using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class RegistryUtilities
    {
        public static void createValue(string key, string value)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\RedmineUtilities");
            if(registryKey == null)
            {
                registryKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\RedmineUtilities");
            }
            registryKey.SetValue(key, value);
            registryKey.Close();
        }
    }
}
