
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface INotificationType_Service : IService<NotificationType>
{
    DataResult<List<ClientNotification>> CollectionOfClientNotification(int clientNotification_Id, ClientNotification clientNotification, UserCredit userCredit);
}
