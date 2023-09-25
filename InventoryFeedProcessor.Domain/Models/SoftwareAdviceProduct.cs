using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InventoryFeedProcessor.Domain
{
    public class SoftwareAdviceProduct
    {
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("twitter")]
        public string TwitterHandle { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class SoftwareAdviceProducts
    {
        [JsonPropertyName("products")]
        public List<SoftwareAdviceProduct> Products { get; set; }
    }
  
}
