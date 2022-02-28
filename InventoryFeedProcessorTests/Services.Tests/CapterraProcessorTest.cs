using AutoMapper;
using InventoryFeedProcessor.Infrastructure;
using InventoryFeedProcessor.Services;
using Moq;
using Xunit;

namespace InventoryFeedProcessorTests.Services.Tests
{
    public class CapterraProcessorTest
    {
        private readonly CapterraProcessor _capterraProcessor;
        private readonly Mock<IMapper> _automapperMock;
        private readonly Mock<IUnitOfWork> _uowMock;
        public CapterraProcessorTest()
        {
            _automapperMock = new Mock<IMapper>();
            _uowMock = new Mock<IUnitOfWork>();
            _capterraProcessor = new CapterraProcessor(_automapperMock.Object, _uowMock.Object);
        }

        [Fact]
        public void ProcessShouldCallAddRange()
        {
            //Test Code here
        }
    }
}
