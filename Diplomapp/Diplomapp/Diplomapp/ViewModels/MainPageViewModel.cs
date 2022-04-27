using Diplomapp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace Diplomapp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            GetCompanies = new AsyncCommand(getCompanies);
            companies = new ObservableRangeCollection<Company>() { new Company() { Id = 0,Name = "Diplom",OwnerId = "Diplomuser"} };
            Projects = new ObservableRangeCollection<Project>{ new Project() { Name = "backend", Id = 0, CompanyId = 0}, new Project() { Name = "frontend",Id = 1,CompanyId = 0} };
            ProjectGroups = new ObservableRangeCollection<Grouping<string, Project>>() { new Grouping<string, Project>(companies[0].Name, Projects.Where(c => c.CompanyId == companies[0].Id))};
        }

        public ObservableRangeCollection<Company> companies { get; set; }
        public AsyncCommand GetCompanies { get; set; }
        public AsyncCommand GetAllUsers { get; set; }
        public AsyncCommand GetProjectMembers { get; set; }

        public ObservableRangeCollection<Project> Projects { get; set; }
        public ObservableRangeCollection<Grouping<string, Project>> ProjectGroups { get; set; }
        public async Task getCompanies() // получить все компании пользователя 
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
            var response = await client.GetStringAsync(App.localUrl + "api/Companies");
            var companyMembers = JsonConvert.DeserializeObject<List<CompanyMember>>(response);
            //json = JsonConvert.SerializeObject(new CompanyMember() { CompanyId = newres.Id, UserId = newres.OwnerId, Role = "Admin" });
            foreach (CompanyMember i in companyMembers)
            {
                var response2 = await client.GetStringAsync(App.localUrl + $"api/Companies/{i.CompanyId}");
                var company = JsonConvert.DeserializeObject<Company>(response2);
                companies.Add(company);
            }
        }
        internal  class user
        {
            [JsonProperty("Email")]
            public string Email { get; set; }
            [JsonProperty("Id")]
            public string Id { get; set; }
            [JsonProperty("UserName")]
            public string UserName { get; set; }
            [JsonProperty("PhoneNumber")]
            public long PhoneNumber { get; set; }
        }//класс юзеров
        public async Task getAllUsers(string accessToken) // команда получения всех юзеров 
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(App.localUrl + "api/Account/GetUsers");

            var users = JsonConvert.DeserializeObject<List<user>>(json);
        }
        public async Task getProjectMembers()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);

            var json = await client.GetStringAsync(App.localUrl + "api/ProjectMembers");

            var members = JsonConvert.DeserializeObject<List<ProjectMember>>(json);
            json = null;
            json = await client.GetStringAsync(App.localUrl + "api/Projects");
            var projects = JsonConvert.DeserializeObject<List<Project>>(json);
            //Projects.AddRange(projects.Where(c => c.Id == members));
            foreach (var i in projects) 
            {
                foreach (var j in members) 
                {
                    if (i.Id == j.ProjectId) 
                    { 
                        Projects.Add(i);
                    }
                }
            }
            foreach (var i in companies) 
            {
                foreach (var j in Projects)
                {
                    if (i.Id == j.CompanyId) 
                    {
                        ProjectGroups.Add(new Grouping<string, Project>(i.Name,(IEnumerable<Project>)j));
                    }
                }
            }
        }

        
    }
}
