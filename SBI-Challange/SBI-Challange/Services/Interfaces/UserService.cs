using Newtonsoft.Json;
using SBI_Challange.Models;
using SBIChallange.Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SBIChallange.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private IEnumerable<User> list = new List<User>();
        public UserService()
        {
            var httpClientHandler = new HttpClientHandler();
            client = new HttpClient(httpClientHandler);
        }

        public async Task<User> GetUserById(string id)
        {
            // maybe here you have call to API endpoint to get given user id data
            var user = list.Where(i => i.Id.ToLower().Equals(id.ToLower())).FirstOrDefault();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            { 
                HttpResponseMessage response = await client.GetAsync(Constants.API_URL);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<User>>(content);
                    return list;
                }
                return list = new List<User>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error has ocurred while fetching users: {ex.Message}");
                return null;
            }
        }
    }
}
