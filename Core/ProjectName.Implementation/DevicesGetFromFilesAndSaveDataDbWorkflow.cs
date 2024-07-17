using ProjectName.Abstraction.Interfaces;
using ProjectName.Base.Models;

namespace ProjectName.Implementation;

public class DevicesGetFromFilesAndSaveDataDbWorkflow<TRemote, TLocal, TDeviceModifiedItem> : ILog,
    IDevicesGetFromFilesAndSaveDataDbWorkflow<TRemote, TLocal, TDeviceModifiedItem>
    where TRemote : RecordOfAbstractDevicesFile
    where TLocal : AbstractDeviceDto
    where TDeviceModifiedItem : DeviceModifiedItemAbstractDto
{
    private readonly IProcessingFilesService<TRemote, TLocal, TDeviceModifiedItem> _processingFilesService;
    public Action<string>? Log { get; set; }

    public DevicesGetFromFilesAndSaveDataDbWorkflow(IProcessingFilesService<TRemote, TLocal, TDeviceModifiedItem> processingFilesService)
    {
        _processingFilesService = processingFilesService;
    }

    /// <summary>
    /// This workflow is more complex in real project.
    /// This version gets unprocessed list of appropriate type of files (registered or revoked) sorted by date, get one oldest file and process this file with saving to DB
    /// </summary>
    /// <returns></returns>
    public async Task<string?> WorkflowAsync()
    {
        var list = await _processingFilesService.GetUnprocessedFilesAsync();
        if (list != null && list.Count > 0)
        {
            var item = list.First();
            Log?.Invoke($"File: {item.Key} before processing");
            try
            {
                await GetRecordsFromFileAndUploadLocallyToDbAsync(item);
                return item.Key;
            }
            catch 
            {
                // different catch clauses here for different exceptions, which can be thrown called methods
            }
        }
        else
            Log?.Invoke("No unprocessed files");

        return null;
    }

    /// <summary>
    /// Get records from passed file, parse this file and call another service, which saves data to DB (depends on passed service instance, registered or revoked)
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    async Task GetRecordsFromFileAndUploadLocallyToDbAsync(KeyValuePair<string, DateTime> file)
    {
        var records = await _processingFilesService.GetRecordsOfFileAsync(file.Key);
        if (records != null)
        {
            Log?.Invoke($"File: {file.Key} parsed successfully, got count records: {records?.Count}");

            var result = await _processingFilesService.UpdateLocalDataAsync(records!, file);
            if (result != null)
            {
                if (result.ProcessedFileResult.FileHasChanges)
                    Log?.Invoke($"File: {file.Key}, count records: {records!.Count}; Added: {result.DeviceAdded.Count}, deleted: {result.DeviceRemoved.Count}, changed: {result.DeviceModified.Count}");
                else
                    Log?.Invoke( $"File: {file.Key} has no changes, deleting this file result: {result.ProcessedFileResult.RemovingFileResult}");
            }
            else
            {
                Log?.Invoke($"File: {file.Key}; Init data, added: {records!.Count} records");
            }
        }
        else
        {
            Log?.Invoke($"File: {file.Key}, returned 'null' result after parsing");
        }

    }
}
