using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Diplomapp.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms; 
namespace Diplomapp.ViewModels
{
    public class TaskPageViewModel : BindableObject
    {
        public Expander[] expanders;
        public TaskPageViewModel()
        {
            expanders = new Expander[4];
            //Problems.AddRange(list);
        }
        public ObservableRangeCollection<Problem> Problems { get; }
        private StackLayout stack = new StackLayout();
        public StackLayout Stack { get =>stack;
            set 
            {
                if (stack == value)
                    return;
                stack = value;
                OnPropertyChanged();
            } 
        }
        public List<Problem> list;
        void Exp_Init() 
        {
            
            list = new List<Problem>();
            for(int i =0;i<expanders.Length;i++)
            {
                expanders[i] = new Expander { Header = new Label { Text = Name}, Content = new Label { Text = Caption} };
                Stack.Children.Add(expanders[i]);
            }
        }
        
        void OnCommand()
        {
            Name = "rexxton";
        }
        void OnCommand1() 
        {
            Caption = "SsanYong";
        }
        public ICommand command { get; }
        private string name = String.Empty;
        public string Name
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
        private string caption= String.Empty;
        public string Caption
        {
            get => caption;
            set
            {
                if (value == caption)
                    return;
                caption = value;
                OnPropertyChanged();
            }
        }
        public ICommand command1 { get; }

    }
}
