using RedmineUtilities.Controllers;
using RedmineUtilities.Models.issue_models;
using RedmineUtilities.Models.project_models;
using System;
using System.Collections.Generic;
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
            projects = await NetworkUtils.getInstance().GetProjectsAsync();
            if (projects == null || projects.Length == 0) {
                MessageBox.Show("There are something wrong");
                return;
            }
            foreach(Project project in projects)
            {
                this.Invoke((MethodInvoker)(() => listProjects.Items.Add(project.name)));
            }
        }

        private async void listProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Issue> issues= await NetworkUtils.getInstance().GetIssuesAsync();
            if (issues == null || issues.Count == 0)
            {
                MessageBox.Show("There are something wrong");
                return;
            }
            foreach (Issue issue in issues)
            {
                Invoke((MethodInvoker)(() => lvIssues.Items.Add(issue.status.name).SubItems.Add(issue.subject)));
            }
        }
    }
}
