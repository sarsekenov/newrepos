using Diplomapp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Diplomapp.ViewModels
{
    [QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(Id), "Id")]
    public class CreateInviteViewModel: BaseViewModel
    {
        public CreateInviteViewModel() 
        {
            getemail = new AsyncCommand(getlistofUsers);
            Selecteditem = new AsyncCommand<user>(selected);
            Users = new ObservableRangeCollection<user>();
        }
        string name;
        int id;
        public string Name { get => name; set => SetProperty(ref name, value); }
        public int Id { get => id; set => SetProperty(ref id, value); }

        string email;
        Invite invite;
        public Invite Invite { get=>invite; set=>SetProperty(ref invite,value); }

        public async Task getlistofUsers() 
        {
            using (App.client = new System.Net.Http.HttpClient())
            {
                Users.Clear();
                App.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);
                //HttpContent content = new StringContent(Email);
                if(Email != null)
                {
                    var res = App.client.GetStringAsync(App.localUrl + $"api/Account/GetUsers?Name={Email}");
                    var userlist = JsonConvert.DeserializeObject<List<user>>(res.Result);
                    Users.AddRange(userlist); 
                }
                
            }
        }
        public ObservableRangeCollection<user> Users { get; set; }
        
        public AsyncCommand getemail { get; set; }
        public string Email { get=>email; set=>SetProperty(ref email,value); }
        async Task selected(user user) 
        {
            if (user == null)
                return;
            Email = user.Email;
            Users.Clear();
        }
        
        public AsyncCommand<user> Selecteditem { get; set; }
    }
    public class user
    {
            [JsonProperty("Email")]
            public string Email { get; set; }
            [JsonProperty("Id")]
            public string Id { get; set; }
            [JsonProperty("UserName")]
            public string UserName { get; set; }
            /*[JsonProperty("PhoneNumber")]
            public long PhoneNumber { get; set; }*/
    }
}
