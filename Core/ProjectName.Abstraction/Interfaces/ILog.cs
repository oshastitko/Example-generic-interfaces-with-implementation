using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectName.Abstraction.Interfaces;

public interface ILog
{
    Action<string>? Log { get; set; }
}
