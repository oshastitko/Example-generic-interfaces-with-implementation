using ProjectName.Base.Models;
using ProjectName.Base.Models.Revoked;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Abstraction.Interfaces;

public interface IDevicesGetFromFilesAndSaveDataDbWorkflow<TRemote, TLocal, TDeviceModifiedItem>
    where TRemote : RecordOfAbstractDevicesFile
    where TLocal : AbstractDeviceDto
    where TDeviceModifiedItem : DeviceModifiedItemAbstractDto
{
    Task<string?> WorkflowAsync();
}
