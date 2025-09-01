using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public class DataResult<T> : Result, IDataResult<T> /*where T : IEntityBase*/
    {
        public DataResult(int id, string message, string originalMessgae, T data) : base(id, message, originalMessgae, id > 0)
        {
            this.Data = data;
        }

        public DataResult(T data) : this(1, string.Empty, string.Empty, data)
        {

        }

        public T Data { get; private set; }
    }
}
