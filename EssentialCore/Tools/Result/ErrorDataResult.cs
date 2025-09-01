using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T> //where T : IEntityBase
    {
        public ErrorDataResult(T data) : this(data == null ? -1 : 1, "data is Empty")
        {

        }

        public ErrorDataResult(int id, string message, string originalMessage, T data) : base((id < 0 ? id : -id), message, originalMessage, data)
        {
        }

        public ErrorDataResult(int id, string message, T data) : this(id, message, string.Empty, data)
        {
        }

        public ErrorDataResult(int id, string message) : this(id, message, default)
        {

        }

    }
}
