
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

public class ResultMessage_Service : Service<ResultMessage>, IResultMessage_Service
{
    public ResultMessage_Service() : base()
    {
    }

    public override async Task<DataResult<ResultMessage>> SaveAttached(ResultMessage resultMessage, UserCredit userCredit)
    {
        return await resultMessage.SaveAttached(userCredit);
    }

    
}
