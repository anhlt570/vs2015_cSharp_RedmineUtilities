using RedmineUtilities.Models.user_model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class NetworkUtils
    {
        static HttpClient client = new HttpClient();
        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<User> GetUserAsync(string username, string password)
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
                client.DefaultRequestHeaders.Add("X-Redmine-API-Key", user.api_key);
                basicClient.CancelPendingRequests();
            }
            return user;
        }
    }
}
