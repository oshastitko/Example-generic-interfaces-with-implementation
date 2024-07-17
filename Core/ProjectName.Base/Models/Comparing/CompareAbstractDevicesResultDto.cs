using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models.Comparing;

public class CompareAbstractDevicesResultDto<TRemote, TLocal, TDeviceModifiedItem>
    where TRemote : RecordOfAbstractDevicesFile
    where TLocal : AbstractDeviceDto
    where TDeviceModifiedItem : DeviceModifiedItemAbstractDto
{
    public List<TLocal> DeviceRemoved { get; set; } = new();
    public List<TRemote> DeviceAdded { get; set; } = new();
    public List<TRemote> DeviceDuplicate { get; set; } = new();
    public List<CompareResultItemModifiedDto<TRemote, TLocal, TDeviceModifiedItem>> DeviceModified { get; set; } = new();
    public (bool FileHasChanges, bool? RemovingFileResult) ProcessedFileResult { get; set; }
}

