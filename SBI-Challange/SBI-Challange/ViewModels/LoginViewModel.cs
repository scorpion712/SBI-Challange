using SBI_Challange.Views;
using SBIChallange.Helpers.Constants;
using SBIChallange.Resources;
using SBIChallange.Services.Interfaces;
using System;
using System.Diagnostics;
using Xamarin.Essentials;
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

            FillEntries();
        }

        #region Methods
        private async void FillEntries()
        {
            try
            {
                Username = await SecureStorage.GetAsync(Constants.USERNAME);
                Password = await SecureStorage.GetAsync(Constants.PASSWORD);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something went wrong while loading user data: {ex.Message}");
            }
        }

        private async void OnLoginClicked(object obj)
        {
            var isUserValid = await loginService.ValidateUser(Username, Password);
            if (isUserValid)
            {
                try
                {
                    await SecureStorage.SetAsync(Constants.USERNAME, Username);
                    await SecureStorage.SetAsync(Constants.PASSWORD, Password);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Something went wrong while saving user data: {ex.Message}");
                }
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(WelcomePage)}?username={Username}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppResources.ErrorUser, AppResources.ErrorUserMsg, AppResources.OK);
            }
        } 
        #endregion
    }
}
