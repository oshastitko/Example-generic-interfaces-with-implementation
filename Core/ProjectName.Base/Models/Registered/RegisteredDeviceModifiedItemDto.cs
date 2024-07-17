using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models.Registered;

public class RegisteredDeviceModifiedItemDto : DeviceModifiedItemAbstractDto
{
    public RegisteredDeviceFieldNameDto DeviceFieldName { get; set; }
}