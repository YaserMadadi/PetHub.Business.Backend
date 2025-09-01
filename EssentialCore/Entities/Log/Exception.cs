using EssentialCore.Entities;
using EssentialCore.Tools.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Log
{
    public class Exception : EntityBase, IEntityBase
    {
        public Exception() : base(Exception.Informer)
        {
        }

        public static Info Informer { get; private set; } = new Info("Log", "Exception", "Exception");

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string CommandName { get; set; }

        public string CommandParameters { get; set; }

        public string ExceptionType { get; set; }

        public string ErrorMessage { get; set; }

        public int ErrorNumber { get; set; }

        public int ErrorCode { get; set; }

        public InnerExceptionMessage ExceptionMessage { get; set; }

        public string ExceptionJsonValue { get; set; }

        //public List<CommandParameter> Parameters { get; set; } = new List<CommandParameter>();

    }
}
