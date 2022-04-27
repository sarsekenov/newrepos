using Diplomapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Diplomapp.Services
{
    public class WebApiService
    {

        static HttpClient client;
        static WebApiService()
        {
            try
            {
                client = new HttpClient
                {
                    BaseAddress = new Uri(App.localUrl)
                };
            }
            catch
            {

            }
        }
        public async Task<List<Project>> GetProjectsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(App.localUrl+ "api/Projects");

            var Projects = JsonConvert.DeserializeObject<List<Project>>(json);

            return Projects;
        }

        public async Task PostProjectAsync(Project Project, string accessToken)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(Project);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(App.localUrl + "api/Projects", content);
        }

        public async Task PutProjectAsync(Project Project, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(Project);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                App.localUrl + "api/Projects/" + Project.Id, content);
        }

        public async Task DeleteProjectAsync(int ProjectId, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.DeleteAsync(
                App.localUrl + "api/Projects/" + ProjectId);
        }

        public async Task<List<Project>> SearchProjectsAsync(string keyword, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(
                App.localUrl + "api/Projects/Search/" + keyword);

            var Projects = JsonConvert.DeserializeObject<List<Project>>(json);

            return Projects;
        }

    }
}
