using Diplomapp.Models;
using Diplomapp.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplomapp.ViewModels
{

[QueryProperty(nameof(Name), "name")]
[QueryProperty(nameof(Id), "Id")]
[QueryProperty(nameof(OwnerId), "OwnerId")]
[QueryProperty(nameof(Description), "Description")]
    public class ProjectPageViewModel:BaseViewModel
    {
        string name;
        int id;
        public string Name { get=>name; set=>SetProperty(ref name,value); }
        public int Id { get=>id; set=>SetProperty(ref id,value); }
        string description;
        string ownerId;
        public string OwnerId { get=> ownerId; set=>SetProperty(ref ownerId,value); }
        public string Description { get=>description; set=>SetProperty(ref description,value); }
        
        //Project project;
        //public Project Project { get=>project; set=> SetProperty(ref project,value); }
        public ProjectPageViewModel() 
        {
            invite = new AsyncCommand(inviteuser);
            getempl = new AsyncCommand(GetEmployees);
            Members = new ObservableRangeCollection<ProjectMember>(); 
            Members.Clear();
            getempl.ExecuteAsync();
            
        }
        public AsyncCommand getempl { get; set; }
        public async Task inviteuser() 
        {
            await Shell.Current.GoToAsync(nameof(CreateInvitePage)+"?name={Name}&Id={Id}");//передаем значения в форму 
        }
        public async Task GetEmployees() // Получаем всех работников этого проекта 
        {
            using (App.client = new System.Net.Http.HttpClient())
            {
                App.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);
                var json = await App.client.GetStringAsync(App.localUrl + $"GetbyId?Id={Id}");// обращаемся к контроллеру 
                var employees = JsonConvert.DeserializeObject<List<ProjectMember>>(json);
                if(employees.Count > 0) 
                {
                    Members.AddRange(employees); 
                }
                
            }
            
        }
        public ObservableRangeCollection<ProjectMember> Members { get; set; }
        public AsyncCommand invite { get; set; }
        public ContentPage infoPage { get; set; }

    }
}
