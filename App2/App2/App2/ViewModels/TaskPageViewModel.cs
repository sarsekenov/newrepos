using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class TaskPageViewModel : BindableObject
    {
        public Expander[] expanders;
        public TaskPageViewModel()
        {
            expanders = new Expander[4];
            command = new Command(OnCommand);
            command1 = new Command(OnCommand1);
            
        }
        
        
        private StackLayout stack;
        public StackLayout Stack { get =>stack;
            set 
            {
                if (stack == value)
                    return;
                stack = value;
                OnPropertyChanged();
            } 
        }
        void Exp_Init() 
        { 
            foreach(Expander i in expanders)
            {
                i.Content = new Label { Text = Caption };
                i.Header = new Label { Text = Name };
                Stack.Children.Add(i);
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
