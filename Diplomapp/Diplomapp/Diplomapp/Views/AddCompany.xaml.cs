using Diplomapp.Models;
using Diplomapp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diplomapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCompany : ContentPage
    {
        public AddCompany()
        {
            InitializeComponent();
        }
        async Task createCompany()
        {
            var client = new HttpClient() { };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
            var json = JsonConvert.SerializeObject(new Company() {Name = NameCompany.Text,OwnerId = "000" });
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(App.localUrl + "api/Companies", content);
            string res = await response.Content.ReadAsStringAsync();
            var newres = JsonConvert.DeserializeObject<Company>(res);
            json = JsonConvert.SerializeObject(new CompanyMember() { CompanyId = newres.Id, UserId = newres.OwnerId ,Role = "Admin" });
            content = new StringContent(json);
            content.Headers.ContentType  = new MediaTypeHeaderValue ("application/json");
            response = await client.PostAsync(App.localUrl + "api/CompanyMembers",content);
            var res1 = await response.Content.ReadAsStringAsync();
            var newres1 = JsonConvert.DeserializeObject<CompanyMember>(res1);
            Shell.Current.GoToAsync("..");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await createCompany();
        }
    }
}