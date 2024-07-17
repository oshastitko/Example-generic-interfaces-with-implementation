using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Base.Models;

public abstract class RecordOfAbstractDevicesFile
{
    public string DeviceName { get; set; }
    public string ModelNumber { get; set; }
    public string SoftwareVersion { get; set; }
    public string EldIdentifier { get; set; }
    public string CompanyName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? MailingAddress { get; set; }
    public string? CityStateZip { get; set; }
    public string? DataTransferOptions { get; set; }
    public int Position { get; set; }

}
