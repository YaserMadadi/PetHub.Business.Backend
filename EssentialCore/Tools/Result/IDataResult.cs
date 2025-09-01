using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Result
{
    public interface IDataResult<out T> : IResult 
    {
        public T Data { get; }


    }
}
