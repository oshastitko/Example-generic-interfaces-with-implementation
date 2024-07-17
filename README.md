# Example-generic-interfaces-with-implementation
This is an example to work with generic interface and its implementation

**This example demonstrates working with generic interface and its implementation, emphasizing abstraction over concrete real types of entities. It abstracts specific entity details and passes concrete classes to another service responsible for interacting with actual entities and saving them to a database. The example encapsulates common logic for retrieving files, processing, parsing, and subsequently passing them to the save service.**

*There is a part of the real large-scale project. which processing 2 types of files from an external source. Initially, the files are saved to Azure storage (this part is not shown here). Subsequently, the files undergo parsing, processing and potentially saving to a local DB depending on subsequent actions (this part is not shown here)*

-	There are 2 types of files with similar structure, but slight differences. An abstract class named `AbstractDeviceDto` contains all common fields, shared between them. Classes `RegisteredDeviceDto` and `RevokedDeviceDto` are descendances of this abstract class.

-	We need to monitor new records that have arrived since the last update, identify modifications, deletions, and potential duplicates (this part is not shown here). For this purpose, we have classes `CompareAbstractDevicesResultDto` and `CompareResultItemModifiedDto`.
  
-	The `IDevicesGetFromFilesAndSaveDataDbWorkflow` interface is generic because its implementation is identical for both registered and revoked devices. It includes a single method, `Workflow`, which incapsulates the logic for retrieving data, parsing, processing and saving to the DB. This method is designed to be executed as an atomic operation, ensuring that client code calls only this method to complete the operation.

-	The implementation of the ‘Workflow` method retrieves all unprocessed files (regardless of device type, as it operates on abstractions), then selects the oldest file (n the real project, additional actions are performed here, so initially, a list is retrieved instead of just the oldest file), parses it and passes to another service for saving to the DB. 

