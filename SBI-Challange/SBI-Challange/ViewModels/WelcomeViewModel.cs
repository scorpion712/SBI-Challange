using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SBI_Challange.ViewModels
{
    [QueryProperty(nameof(Username), "username")]
    public class WelcomeViewModel : BaseViewModel
    {
        private string _username;
        public string Username { 
            get { return _username; } 
            set { if (_username == value) return; _username = value; OnPropertyChanged(); Title = value; } }

        public WelcomeViewModel()
        {
            Title = Username;
        }

    }
}