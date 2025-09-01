using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public class Result : IResult
    {
        public Result(bool isSucceeded) : this(0, string.Empty, string.Empty, isSucceeded)
        {

        }

        public Result(int id, string message) : this(id, message, string.Empty)
        {

        }

        public Result(int id, string message, string originalMessage) : this(id, message, originalMessage, id > 0)
        {

        }

        public Result(int id, string message, string originalMessage, bool isSucceeded)
        {
            this.Id = id;

            this.Message = message;

            this.OriginalMessage = originalMessage;

            this.IsSucceeded = isSucceeded;
        }


        public int Id { get; set; }

        public bool IsSucceeded { get; set; }

        public string Message { get; set; }

        public string OriginalMessage { get; set; }

        public int ErrorNumber { get; set; }
    }
}
