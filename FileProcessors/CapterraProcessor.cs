using AutoMapper;
using InventoryFeedProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;
namespace InventoryFeedProcessor.FileProcessors
{
    public class CapterraProcessor : IFileProcessor
    {
        public IMapper _mapper { get; set; }
        public CapterraProcessor(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Process(string filePath)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
     .WithNamingConvention(CamelCaseNamingConvention.Instance)
     .Build();
            List<CapterraProduct> capterra = deserializer.Deserialize<List<CapterraProduct>>(File.ReadAllText(filePath));

            var products = _mapper.Map<List<Product>>(capterra);

            //call to repositories
        }
    }
}
