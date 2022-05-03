
using Diplomapp.Views;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Diplomapp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
            //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddCompany), typeof(AddCompany));
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            Logout = new AsyncCommand(logout);
            command = new Command(OnMenuItemClicked);
        }
        public Command command;
        private async void OnMenuItemClicked()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        public AsyncCommand Logout;
        public async Task logout()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
            var request = new HttpRequestMessage(HttpMethod.Post,App.localUrl+"api/Account/Logout");

            var res = await client.SendAsync(request);
            if (res.StatusCode == HttpStatusCode.OK) 
            {
                Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Logout.ExecuteAsync();

        }
    }
}
