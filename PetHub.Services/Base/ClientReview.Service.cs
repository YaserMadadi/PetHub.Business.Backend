
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using PetHub.Entities.Base;
using PetHub.Services.Base.Actions;
using PetHub.Services.Base.Abstract;

namespace PetHub.Services.Base;

public class ClientReview_Service : Service<ClientReview>, IClientReview_Service
{
    public ClientReview_Service() : base()
    {
    }

    public override async Task<DataResult<ClientReview>> SaveAttached(ClientReview clientReview, UserCredit userCredit)
    {
        return await clientReview.SaveAttached(userCredit);
    }

    
}
