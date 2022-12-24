using SBI_Challange.Models;
using SBI_Challange.Services;
using SBIChallange.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SBIChallange.Services
{
    // This class simulates a service to call an endpoint. In this case, we used mocked data
    public class LoginService : ILoginService
    {
        public IDataStore<User> DataStore => DependencyService.Get<IDataStore<User>>();

        public async Task<bool> ValidateUser(string username, string password)
        {
            // Simulates Call to API
            Thread.Sleep(1000);
            return await DataStore.ValidateUser(username, password);
        }
    }
}
