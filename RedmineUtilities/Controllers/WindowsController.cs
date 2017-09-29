using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedmineUtilities.Controllers
{
    class WindowsController
    {
        private static WindowsController instance;
        public static WindowsController getInstance()
        {
            if(instance == null)
            {
                instance = new WindowsController();
            }
            return instance;
        }

        public void openWindow(Form parrentWindow, Form childWindow)
        {
            childWindow.Show();
            parrentWindow.Close();
        }
    }
}
