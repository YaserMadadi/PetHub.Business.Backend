using EssentialCore.BusinessLogic;
using EssentialCore.Entities.Core;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.DataAccess;
using EssentialCore.Entities;

namespace EssentialCore.Tools.Logging
{
    public class ExceptionLogService : Service<Entities.Log.Exception>
    {
        public async Task<DataResult<Entities.Log.Exception>> SaveAttached(Entities.Log.Exception exceptionLog)
        {
            var transaction = new CoreTransaction();

            var userCredit = new Security.Entities.UserCredit() { UserAccount_Id = 1 };

            var result = await this.Save(exceptionLog, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult(exceptionLog);

            //Result.Result childResult = null;

            //if (exceptionLog.Parameters.CheckList())
            //{
            //    exceptionLog.Parameters.ForEach(i => i.Log.Id = result.Id);

            //    var commandParameterService = new Service<Entities.Log.CommandParameter>();

            //    foreach (var commandParameter in exceptionLog.Parameters)
            //    {
            //        childResult = await commandParameterService.Save(commandParameter, userCredit, transaction);

            //        if(!childResult.IsSucceeded)
            //        {
            //            return new ErrorDataResult<Entities.Log.Exception>(-1, "Error On Saveing");
            //        }
            //    }
            //}

            transaction.Commit();

            return result;
        }
    }
}
