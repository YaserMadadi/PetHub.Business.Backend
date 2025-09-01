using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult() : this(-1, "An Error occured in this proccess!", string.Empty)
        {

        }

        public ErrorResult(int id, string message) : this(id, message, string.Empty)
        {

        }

        public ErrorResult(int id, string message, string originalMessage) : base(-Math.Abs(id), message, originalMessage, false)
        {

        }

    }

}
