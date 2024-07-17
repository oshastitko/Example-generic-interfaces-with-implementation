using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models.Comparing;

public class CompareResultItemModifiedDto<TRemote, TLocal, TDeviceModifiedItem>
    where TRemote : RecordOfAbstractDevicesFile
    where TLocal : AbstractDeviceDto
    where TDeviceModifiedItem : DeviceModifiedItemAbstractDto
{
    public TLocal OldItem { get; set; }
    public TRemote NewItem { get; set; }
    public List<TDeviceModifiedItem> Changes { get; set; } = new();
}