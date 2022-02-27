using AutoMapper;
using InventoryFeedProcessor.Models;
using InventoryFeedProcessor.Repositories.Core.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace InventoryFeedProcessor.FileProcessors
{
    public class SoftwareAdviceProcessor : IFileProcessor
    {
        public IMapper _mapper { get; set; }
        public SoftwareAdviceProcessor(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Process(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);

            SoftwareAdviceProducts myDeserializedClass = JsonConvert.DeserializeObject<SoftwareAdviceProducts>(jsonString);
            var products = _mapper.Map<List<Product>>(myDeserializedClass);
        }
    }

}
