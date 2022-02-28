namespace InventoryFeedProcessor.Utility
{
    public static class ExtensionMethods
    {
        public static string[] SplitBySring(this string value, string spliter)
        {
            return value.Split(spliter);
        }
    }
}
