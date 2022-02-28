using InventoryFeedProcessor.FileProcessors;
using InventoryFeedProcessor.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InventoryFeedProcessorTests
{
    public class ProcessFileDispatcherTest
    {
        private readonly ProcessFileDispatcher _processFileDispatcher;
        private readonly Mock<IFileProcessor> _fileProcessorMock;
        public ProcessFileDispatcherTest()
        {
            _fileProcessorMock = new Mock<IFileProcessor>();
            Func<string, IFileProcessor> fileProcess = str => _fileProcessorMock.Object;
            _processFileDispatcher = new ProcessFileDispatcher(fileProcess);
        }

        [Fact]
        public void ProcessShouldDispachCallToIFileProcessorProcess()
        {
            //Arrange
            _fileProcessorMock.Setup(x => x.Process(It.IsAny<string>()));
            //Act
            _processFileDispatcher.Process(It.IsAny<string>(), It.IsAny<string>());
            //Assert
            _fileProcessorMock.Verify(x => x.Process(It.IsAny<string>()), Times.Once());
        }
    }
}
