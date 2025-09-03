
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

public class MessageType_Service : Service<MessageType>, IMessageType_Service
{
    public MessageType_Service() : base()
    {
    }

    public override async Task<DataResult<MessageType>> SaveAttached(MessageType messageType, UserCredit userCredit)
    {
        return await messageType.SaveAttached(userCredit);
    }

    public DataResult<List<ResultMessage>> CollectionOfResultMessage(int messageType_Id, ResultMessage resultMessage, UserCredit userCredit)
    {
        var procedureName = "[Infra].[MessageType.CollectionOfResultMessage]";

        return this.CollectionOf<ResultMessage>(procedureName, 
                                                        new SqlParameter("@Id", messageType_Id), 
                                                        new SqlParameter("@jsonValue", resultMessage.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
