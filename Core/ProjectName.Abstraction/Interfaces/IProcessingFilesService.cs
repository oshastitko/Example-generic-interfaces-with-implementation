using ProjectName.Base.Models;
using ProjectName.Base.Models.Comparing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Abstraction.Interfaces;

public interface IProcessingFilesService<TRemote, TLocal, TDeviceModifiedItem>
    where TRemote : RecordOfAbstractDevicesFile
    where TLocal : AbstractDeviceDto
    where TDeviceModifiedItem : DeviceModifiedItemAbstractDto
{
    Task<List<TRemote>?> GetRecordsOfFileAsync(string filename);

    Task<IDictionary<string, DateTime>> GetUnprocessedFilesAsync();

    Task<bool?> RemoveFileAsync(string filename);

    Task<CompareAbstractDevicesResultDto<TRemote, TLocal, TDeviceModifiedItem>?> UpdateLocalDataAsync(List<TRemote> remoteDevices, KeyValuePair<string, DateTime> item);
}
