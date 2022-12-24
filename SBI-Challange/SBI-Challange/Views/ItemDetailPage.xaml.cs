using SBI_Challange.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SBI_Challange.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}