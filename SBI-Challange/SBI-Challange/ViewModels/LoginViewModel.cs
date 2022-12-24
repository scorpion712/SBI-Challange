using SBI_Challange.Views;
using SBIChallange.Services.Interfaces;
using System; 
using Xamarin.Forms;

namespace SBI_Challange.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _username;
        private string _password; 
        #endregion

        #region Properties
        public string Username
        {
            get { return _username; }
            set { if (_username == value) return; _username = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsButtonEnabled)); }
        }

        public string Password
        {
            get { return _password; }
            set { if (_password == value) return; _password = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsButtonEnabled)); }
        }

        public bool IsButtonEnabled { get => !String.IsNullOrEmpty(Username) || !String.IsNullOrEmpty(Password); } 
        #endregion

        public Command LoginCommand { get; }

        public ILoginService loginService;

        public LoginViewModel()
        {
            loginService = DependencyService.Get<ILoginService>();
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var isUserValid = await loginService.ValidateUser(Username, Password);
            if (isUserValid)
            {
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("User Error", "Invalid user. Please double check your details or be aware of capitalization", "OK");
            }
        }
    }
}
