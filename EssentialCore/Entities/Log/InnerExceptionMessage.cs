using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Log;
public class InnerExceptionMessage
{
    public string Message { get; set; }

    public InnerExceptionMessage InnerException { get; set; }
}
