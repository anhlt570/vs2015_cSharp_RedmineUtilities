using RedmineUtilities.Models.issue_models;
using RedmineUtilities.Models.project_models;
using RedmineUtilities.Models.user_models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class NetworkUtils
    {
        public HttpClient client = new HttpClient();
        private static NetworkUtils instance = null;
        public static NetworkUtils getInstance()
        {
            if (instance == null)
            {
                instance = new NetworkUtils();
            }
            return instance;
        }

        public async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://redmine.ntq.solutions");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void addHeaderKey(string key, string value)
        {
            client.DefaultRequestHeaders.Remove(key);
            client.DefaultRequestHeaders.Add(key, value);
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            HttpClient basicClient = new HttpClient();
            var authorizationStr = username + ":" + password;
            var byteArray = Encoding.ASCII.GetBytes(authorizationStr);
            basicClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var url = "https://redmine.ntq.solutions/users/current.json";
            User user = null;
            HttpResponseMessage response = await basicClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                UserResponse userResponse = await response.Content.ReadAsAsync<UserResponse>();
                user = userResponse.user;
                Console.WriteLine(user.api_key);
                addHeaderKey("X-Redmine-API-Key", user.api_key);
                basicClient.CancelPendingRequests();
            }
            return user;
        }

        public async Task<User> GetUserAsync()
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync("/users/current.json");
            if (response.IsSuccessStatusCode)
            {
                UserResponse userResponse = await response.Content.ReadAsAsync<UserResponse>();
                user = userResponse.user;
            }
            return user;
        }

        public async Task<Project[]> GetProjectsAsync()
        {
            Project[] projects = null;
            HttpResponseMessage response = await client.GetAsync("/projects.json");
            if (response.IsSuccessStatusCode)
            {
                ProjectsResponse projectResponse = await response.Content.ReadAsAsync<ProjectsResponse>();
                projects = projectResponse.projects;
            }
            return projects;
        }

        public async Task<Project> GetProjectsAsync(int projectID)
        {
            Project project = null;
            HttpResponseMessage response = await client.GetAsync("/projects.json?project_id= "+ projectID);
            if (response.IsSuccessStatusCode)
            {
                ProjectResponse projectResponse = await response.Content.ReadAsAsync<ProjectResponse>();
                project = projectResponse.project;
            }
            return project;
        }

        public async Task<List<Issue>> GetIssuesAsync()
        {
            List<Issue> issues = null;
            HttpResponseMessage response = await client.GetAsync("/issues.json");
            if (response.IsSuccessStatusCode)
            {
                IssuesResponse issuesResponse =  await response.Content.ReadAsAsync<IssuesResponse>();
                issues = issuesResponse.issues;
                string s = await response.Content.ReadAsStringAsync();
                Console.WriteLine(s);
            }
            return issues;
        }
    }
}
