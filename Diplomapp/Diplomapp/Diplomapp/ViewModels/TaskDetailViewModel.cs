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
using Xamarin.Forms;


namespace Diplomapp.ViewModels
{
    /*[QueryProperty(nameof(Name), "name")]
    [QueryProperty(nameof(Id), "Id")]*/
    public class TaskDetailViewModel : BaseViewModel
    {
        
        public TaskDetailViewModel()
        {
            Problem = new Problem();
            command = new AsyncCommand(saveChanges);
        }
        public async Task saveChanges()
        {
            using (App.client = new HttpClient())
            {
                App.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.accessToken);
                
            }
            

        }
        public AsyncCommand command { get; set; }
        public Problem Problem { get; set; }
        //public ObservableRangeCollection<ProblemChecklist>Checklists { get; set; }
        //public ObservableRangeCollection<ProblemComment> Comments{ get; set; }
    }
}
