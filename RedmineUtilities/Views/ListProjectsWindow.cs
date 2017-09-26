using RedmineUtilities.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedmineUtilities.Views
{
    public partial class ListProjectsWindow : Form
    {
        private string currentUser;
        public ListProjectsWindow(string currentUser)
        {
            this.currentUser = currentUser;
            InitializeComponent();
        }



        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbProjects.SelectedItem != null)
            {
                MessageBox.Show(lbProjects.SelectedItem.ToString());
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryUtilities.removeValue(Constants.REGISTRY_CURRENT_USER);
            Close();
            Application.Run(new LoginForm());
        }
    }
}
