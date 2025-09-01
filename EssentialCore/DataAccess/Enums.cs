using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public enum CommandType
    {
        Save,
        Retrieve,
        RetrieveById,
        Seek,
        SeekByValue,
        Delete
    }
}
