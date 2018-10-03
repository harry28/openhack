using Newtonsoft.Json;

namespace Challenge1.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("productDescription")]
        public string ProductDescription { get; set; }
    }
}
