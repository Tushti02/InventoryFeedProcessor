using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryFeedProcessor.Repositories.Core.Domain
{
    public class Product
    {
        public string TwitterHandle { get; set; }
        public string Title { get; set; }
        public List<string> Categories { get; set; }
    }
}
