using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models.Revoked;

public class RecordOfRevokedDevicesFile : RecordOfAbstractDevicesFile
{
    public string DateRevoked { get; set; }
    public string Status { get; set; }
}
