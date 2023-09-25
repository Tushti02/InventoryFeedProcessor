using AutoMapper;
using InventoryFeedProcessor.Domain;
using InventoryFeedProcessor.Infrastructure;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;

namespace InventoryFeedProcessor.Services
{
    public class CapterraProcessor : IFileProcessor
    {
        public IMapper _mapper { get; set; }
        public IUnitOfWork _uow { get; set; }
        public CapterraProcessor(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Process(string filePath)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
     .WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            List<CapterraProduct> capterra = deserializer.Deserialize<List<CapterraProduct>>(File.ReadAllText(filePath));

            var products = _mapper.Map<List<Product>>(capterra);

            //call to repositories

            _uow.Products.AddRange(products);
            _uow.Complete();

        }
    }
}
