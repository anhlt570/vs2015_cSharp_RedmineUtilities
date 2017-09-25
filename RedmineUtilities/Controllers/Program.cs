using RedmineUtilities.Models;
using RedmineUtilities.Models.user_model;
using RedmineUtilities.Views;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedmineUtilities.Controllers
{
    static class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            NetworkUtils.RunAsync();
        }

     
    }
}
