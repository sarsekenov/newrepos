using Diplomapp.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Diplomapp.ViewModels
{
    public class LoginPageViewModel:BindableObject
    {
        public LoginPageViewModel()
        {
            register = new Command(Registeraction);
            login = new Command(Login); 
        }
        string username;
        string password;
        public string Username { get { return username; } 
            set 
            {
                if(value == username)
                    return;
                username = value;
                OnPropertyChanged();
            } }
        public string Password
        {
            get { return password; }
            set
            {
                if (value == password)
                    return;
                password = value;
                OnPropertyChanged();
            }
        }
        public Command login { get; set; }
        public Command register { get; set; }
        void Registeraction() 
        {
            Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        async void Login()
        {
            var keyValues = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", Username),
                new KeyValuePair<string, string>("password", Password),
                new KeyValuePair<string, string>("grant_type", "password")
            };
            var request = new HttpRequestMessage(HttpMethod.Post, App.localUrl + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            var pairs = JsonConvert.DeserializeObject<Token>(content);

            if (pairs.AccessToken != null)
            {
                App.accessToken = pairs.AccessToken;
                await Shell.Current.GoToAsync($"/{nameof(MainPage)}");
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert("Error ", "No user with this username and password","Ok");
            }
        }

    }
    internal class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
