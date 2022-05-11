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
    [QueryProperty(nameof(Name), "Name")]
    [QueryProperty(nameof(Id), "Id")]
    [QueryProperty(nameof(ProblemId),"ProblemId")]
    public class TaskDetailViewModel : BaseViewModel
    {
        string name;
        int problemid;
        public int ProblemId { get => problemid; set => SetProperty(ref problemid, value); }
        public string Name { get => name; set => SetProperty(ref name, value); }
        string id;
        public string Id { get => id; set => SetProperty(ref id, value); }

        public TaskDetailViewModel()
        {
            Problem = new Problem();
            command = new AsyncCommand(saveChanges);
            Checklists = new ObservableRangeCollection<ProblemChecklist>();
            Comments = new ObservableRangeCollection<ProblemComment>();
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
        public ProblemChecklist ProblemChecklist{ get; set; }
        public ProblemComment ProblemComment{ get; set; }
        public ObservableRangeCollection<ProblemChecklist> Checklists { get; set; }
        public ObservableRangeCollection<ProblemComment> Comments{ get; set; }
    }
}
