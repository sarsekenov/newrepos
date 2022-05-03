using Diplomapp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Diplomapp.ViewModels
{
    public  class InviteViewModel:BaseViewModel
    {
        public InviteViewModel() 
        { 
            Invites = new ObservableRangeCollection<Invite>();
            command = new AsyncCommand(getinv);
        }
        public ObservableRangeCollection<Invite> Invites { get; set; }
        public AsyncCommand command { get; set; }
        public async Task getinv() 
        {
            using (App.client = new HttpClient()) 
            {
                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",App.accessToken);
                var json = await App.client.GetStringAsync(App.localUrl + "api/Invites");
                var invites = JsonConvert.DeserializeObject<List<Invite>>(json);
                Invites.AddRange(invites);
            }
        }
    }
    

}
