using SBI_Challange.Services;
using SBI_Challange.Views;
using SBIChallange.Services;
using SBIChallange.Services.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SBI_Challange
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ILoginService, LoginService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
