using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models.Revoked;

public class RevokedDeviceModifiedItemDto : DeviceModifiedItemAbstractDto
{
    public RevokedDeviceFieldNameDto DeviceFieldName { get; set; }
}
