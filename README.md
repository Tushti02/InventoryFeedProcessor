# InventoryFeedProcessor
*Inventory Feed Processor

A worker service which looks for available files in *../feed-products* path configurable in *appsettings.json*

# Framework and libraries

1. dotnet core 3.1
2. Moq for creating mocks for unit tests
3. XUnit for writing unit tests
4. System.Text.Json to parse json files
5. YamlDotNet to parse yaml files
6. Automapper to map DTO objects

# Run Project

To run this project run "dotnet run" on command line in *InventoryFeedProcessor* directory


# Test Project

To run unit tests run "dotnet test" on command line in *InventoryFeedProcessor* directory
