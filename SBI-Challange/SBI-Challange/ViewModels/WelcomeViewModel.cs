using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SBI_Challange.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public string LogoURL { get => "https://www.sbi-technology.com/assets/images/sitio/logo.svg";  }

        public WelcomeViewModel()
        {
            Title = "About";
        }

    }
}