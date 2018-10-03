using System;
using Newtonsoft.Json;

namespace Challenge1.Models
{
    public class RatingModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("userNotes")]
        public string UserNotes { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
