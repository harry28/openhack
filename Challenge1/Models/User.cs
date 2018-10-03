using Newtonsoft.Json;

namespace Challenge1.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
