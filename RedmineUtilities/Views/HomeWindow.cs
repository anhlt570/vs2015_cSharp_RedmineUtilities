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
            List<Project> projects = new List<Project>();
            projects = await NetworkUtils.getInstance().GetProjectsAsync();
            if (projects == null || projects.Capacity == 0) {
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
                return;
            }
            foreach(Project project in projects)
            {
                Invoke((MethodInvoker)(() => listProjects.Items.Add(project.name)));
                
            }
            ResourcesManager.getInstance().currentProjects = projects;
        }

        private async void listProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleanIssues();
            List<Project> projects = ResourcesManager.getInstance().currentProjects;
            List<Issue> issues= await NetworkUtils.getInstance().GetIssuesAsync(0,projects[listProjects.SelectedIndex].id);
            if (issues == null || issues.Count == 0)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show(this);
                return;
            }
            foreach (Issue issue in issues)
            {
                Invoke((MethodInvoker)(() => {
                    string[] row = { issue.status.name, issue.subject};
                    ListViewItem item = new ListViewItem(row);
                    lvIssues.Items.Add(item);
                }));
            }
        }

        private void cleanIssues()
        {
            foreach(ListViewItem item in lvIssues.Items)
            {
                lvIssues.Items.Remove(item);
            }
        }

        private void btnRmAll_Click(object sender, EventArgs e)
        {
            cleanIssues();
        }
    }
}
