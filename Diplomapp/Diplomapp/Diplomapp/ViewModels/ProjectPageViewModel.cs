using Diplomapp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Diplomapp.ViewModels
{
    [QueryProperty(nameof(Project), "proj")]
    public class ProjectPageViewModel:BaseViewModel
    {
        public Project Project { get; set; }
        public ProjectPageViewModel() 
        {

        }
        public ContentPage infoPage { get; set; }

    }
}
