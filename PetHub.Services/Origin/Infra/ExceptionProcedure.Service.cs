
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Infra;
using PetHub.Services.Infra.Actions;
using PetHub.Services.Infra.Abstract;

namespace PetHub.Services.Infra;

public class ExceptionProcedure_Service : Service<ExceptionProcedure>, IExceptionProcedure_Service
{
    public ExceptionProcedure_Service() : base()
    {
    }

    public override async Task<DataResult<ExceptionProcedure>> SaveAttached(ExceptionProcedure exceptionProcedure, UserCredit userCredit)
    {
        return await exceptionProcedure.SaveAttached(userCredit);
    }

    
}
