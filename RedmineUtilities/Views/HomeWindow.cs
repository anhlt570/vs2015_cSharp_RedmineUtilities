using RedmineUtilities.Controllers;
using RedmineUtilities.Models.user_model;
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
    public partial class HomeWindow : Form
    {
        public HomeWindow(string userID)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(userID))
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog(this);
            }
            else
            {
                NetworkUtils.getInstance().addHeaderKey("X-Redmine-API-Key", userID);
            }
            loadProjects();
        }

        private void mLogout_Click(object sender, EventArgs e)
        {
            RegistryUtils.removeValue(Constants.REGISTRY_CURRENT_USER);
            listProjects.ResetText();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(this);
        }

        private async void loadProjects()
        {
            Project[] projects;
            projects = await NetworkUtils.getInstance().getProjectsAsync();
            if (projects == null || projects.Length == 0) {
                MessageBox.Show("There are something wrong");
                return;
            }
            foreach(Project project in projects)
            {
                this.Invoke((MethodInvoker)(() => listProjects.Items.Add(project.name)));
            }
        }
    }
}
