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
    public class TaskDetailViewModel : BaseViewModel
    {
        public TaskDetailViewModel()
        {
            Problem = new Problem();
            //Checklists = new ObservableRangeCollection<ProblemChecklist>();
            //Comments = new ObservableRangeCollection<ProblemComment>();
            command = new AsyncCommand(saveChanges);
        }
        public async Task saveChanges()
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Problem);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(json);
            
            

        }
        public AsyncCommand command { get; set; }
        public Problem Problem { get; set; }
        //public ObservableRangeCollection<ProblemChecklist>Checklists { get; set; }
        //public ObservableRangeCollection<ProblemComment> Comments{ get; set; }
    }
}
