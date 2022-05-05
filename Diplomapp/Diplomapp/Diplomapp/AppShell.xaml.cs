﻿
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
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
            Routing.RegisterRoute(nameof(ProjectPage), typeof(ProjectPage));
            Routing.RegisterRoute(nameof(AddCompany), typeof(AddCompany));
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            Routing.RegisterRoute(nameof(CreateInvitePage), typeof(CreateInvitePage));
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
               await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Logout.ExecuteAsync();

        }
    }
}
