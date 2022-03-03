using AutoMapper;
using InventoryFeedProcessor.Domain;
using InventoryFeedProcessor.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryFeedProcessor.Services
{
    public class SoftwareAdviceProcessor : IFileProcessor
    {
        public IMapper _mapper { get; set; }
        public IUnitOfWork _uow { get; set; }
        public SoftwareAdviceProcessor(IMapper mapper,IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public void Process(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            //SoftwareAdviceProducts myDeserializedClass = JsonConverter.DeserializeObject<SoftwareAdviceProducts>(jsonString);
            SoftwareAdviceProducts myDeserializedClass = JsonSerializer.Deserialize<SoftwareAdviceProducts>(jsonString);
            var products = _mapper.Map<List<Product>>(myDeserializedClass);

            _uow.Products.AddRange(products);
            _uow.Complete();
            
        }
    }

}
