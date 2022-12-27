using Newtonsoft.Json;
using System;

namespace SBI_Challange.Models
{
    public class User
    {
        // Note: I use this id because the API response doesn't contains an id, so use Guid to generate random id
        private string _id="";
        [JsonProperty("Id")]
        public string Id
        {
            get => String.IsNullOrEmpty(_id) ? _id = Guid.NewGuid().ToString() : _id;
            set
            {
                if (_id.Equals(value)) return; _id = value;
            }
        }
        private string _name;
        [JsonProperty("Name")]
        public string Name { get => _name + LastName; set { if (_name == value) return; _name = value; } }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Status")]
        public int Status { get; set; }
    }
}