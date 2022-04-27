
using Diplomapp.Views;
using System;
using System.Collections.Generic;
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
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddCompany), typeof(AddCompany));

            command = new Command(OnMenuItemClicked);
        }
        public Command command;
        private async void OnMenuItemClicked()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
