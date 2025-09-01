using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public class SuccessfulResult : Result
    {
        public SuccessfulResult() : this(1, "SuccessFully Done!")
        {

        }


        public SuccessfulResult(int id, string message) : base(id, message)
        {

        }

    }
}
