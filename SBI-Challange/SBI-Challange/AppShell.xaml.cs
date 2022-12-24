using SBI_Challange.ViewModels;
using SBI_Challange.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SBI_Challange
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
