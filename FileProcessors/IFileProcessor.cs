using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryFeedProcessor.FileProcessors
{
    public interface IFileProcessor
    {
        public void Process(string filePath);
        //public bool CanProcess(string filePath, string extension);
    }

}
