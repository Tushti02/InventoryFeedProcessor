namespace InventoryFeedProcessor.FileProcessors
{
    public interface IProcessFileDispatcher
    {
        public void Process(string filePath, string extension);
    }
}