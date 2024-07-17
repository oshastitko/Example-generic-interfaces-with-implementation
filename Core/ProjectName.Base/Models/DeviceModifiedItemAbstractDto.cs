using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models;

public abstract class DeviceModifiedItemAbstractDto
{
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
}
