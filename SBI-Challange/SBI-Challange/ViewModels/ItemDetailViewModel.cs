using SBI_Challange.Models;
using SBIChallange.Resources;
using SBIChallange.Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBI_Challange.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private User _selectedUser;

        public ItemDetailViewModel()
        {
            Title = AppResources.Details;
        }

        private IUserService _userService = DependencyService.Get<IUserService>();

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { if (_selectedUser == value) return;  _selectedUser = value; OnPropertyChanged();}
        }

        public string ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await _userService.GetUserById(itemId);
                SelectedUser = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
