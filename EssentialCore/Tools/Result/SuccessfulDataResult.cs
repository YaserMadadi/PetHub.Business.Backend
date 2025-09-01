using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.Tools.Serializer;

namespace EssentialCore.Tools.Result
{
    public class SuccessfulDataResult<T> : DataResult<T>
    {
        public SuccessfulDataResult() : base(1, "Successfully Done!", string.Empty, default)
        {

        }

        public SuccessfulDataResult(T data) : base(data)
        {

        }

        public SuccessfulDataResult(T data, string message) : base(1, message, string.Empty, data)
        {

        }


    }
}
