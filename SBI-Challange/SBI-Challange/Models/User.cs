using Newtonsoft.Json;
using System;

namespace SBI_Challange.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Status")]
        public int Status { get; set; }
    }
}