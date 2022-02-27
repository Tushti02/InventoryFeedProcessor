using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryFeedProcessor.FileProcessors
{
    public class ProcessFileDispatcher : IProcessFileDispatcher
    {
        private readonly Func<string, IFileProcessor> _fileProcess;
        public ProcessFileDispatcher(Func<string, IFileProcessor> fileProcess)
        {
            _fileProcess = fileProcess;
        }
        public void Process(string filePath, string extension)
        {
            _fileProcess(extension).Process(filePath);
        }
    }
}
