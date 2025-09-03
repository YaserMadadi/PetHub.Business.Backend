
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Infra;

namespace PetHub.Services.Infra.Abstract;

public interface IMessageType_Service : IService<MessageType>
{
    DataResult<List<ResultMessage>> CollectionOfResultMessage(int resultMessage_Id, ResultMessage resultMessage, UserCredit userCredit);
}
