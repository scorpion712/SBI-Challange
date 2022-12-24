using SBI_Challange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SBI_Challange.Services
{
    public class MockDataStore : IDataStore<User>
    {
        readonly List<User> items;
        readonly Dictionary<string, string> users;

        public MockDataStore()
        {
            items = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), Name = "First item", Email="This is an item description.", Status = 1 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Second item", Email="This is an item description.", Status = 1 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Third item", Email="This is an item description.", Status = 0 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Email="This is an item description.", Status = 1 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Email="This is an item description.", Status = 0 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Email="This is an item description.", Status = 0 }
            };

            users = new Dictionary<string, string>()
            {
                { "SBI-TEST", "testing"}
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = items.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((User arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            if (users.ContainsKey(username))
            { 
                return await Task.FromResult(users[username].Equals(password));
            }
            return false;
        }
    }
}