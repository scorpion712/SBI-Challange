using SBI_Challange.Models;
using SBI_Challange.Views;
using SBIChallange.Resources;
using SBIChallange.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBI_Challange.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private User _selectedItem;
        public IUserService userService;

        public ObservableCollection<User> Items { get; }
        public Command LoadItemsCommand { get; } 
        public Command<User> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "List";
            Items = new ObservableCollection<User>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<User>(OnItemSelected);

            userService = DependencyService.Get<IUserService>();
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await userService.GetUsers();
                if (items == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Algo salió mal al intentar cargar los usuarios. Por favor, reintente más tarde.", "Ok");
                }
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        } 

        async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}