using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public interface IResult
    {
        public int Id { get; }

        public bool IsSucceeded { get; }

        public string Message { get; }

        public string OriginalMessage { get; }

        public int ErrorNumber { get; }
    }
}
