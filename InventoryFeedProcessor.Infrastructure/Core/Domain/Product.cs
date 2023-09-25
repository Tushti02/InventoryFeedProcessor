using System.Collections.Generic;

namespace InventoryFeedProcessor.Infrastructure
{
    public class Product
    {
        public int Id { get; set; }
        public string TwitterHandle { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
    }
}
