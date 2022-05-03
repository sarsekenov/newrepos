using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Diplomapp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using Xamarin.Forms; 
namespace Diplomapp.ViewModels
{
    [QueryProperty(nameof(ProjName), "name")]
    public class TaskPageViewModel : BaseViewModel
    {
        public TaskPageViewModel()
        {
            Problems = new ObservableRangeCollection<Problem>{ };
            getProblems = new AsyncCommand(getproblems);
        }
        public ObservableRangeCollection<Problem> Problems { get; }
        
        public List<Problem> list;
        public AsyncCommand getProblems;
        
        private string name = String.Empty;
        public string ProjName
        {
            get => name;
            set
            {
                if (value == name)
                    return;
                name = value;
                OnPropertyChanged();
            }
        }
        public async Task getproblems() 
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);

            var response = await client.GetStringAsync(App.localUrl + "api/ProblemMembers");
            var companyMembers = JsonConvert.DeserializeObject<List<ProblemMember>>(response);
            if (companyMembers.Count != 0)
            {
                foreach (ProblemMember i in companyMembers)
                {
                    //var response2 = await client.GetStringAsync(App.localUrl + $"api/Companies/{i.TaskId}");
                    //var company = JsonConvert.DeserializeObject<Problem>(response2);
                    //Problems.Add(company);
                }
            }

        }
        

    }
}
