
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

public class NotificationType_Service : Service<NotificationType>, INotificationType_Service
{
    public NotificationType_Service() : base()
    {
    }

    public override async Task<DataResult<NotificationType>> SaveAttached(NotificationType notificationType, UserCredit userCredit)
    {
        return await notificationType.SaveAttached(userCredit);
    }

    public DataResult<List<ClientNotification>> CollectionOfClientNotification(int notificationType_Id, ClientNotification clientNotification, UserCredit userCredit)
    {
        var procedureName = "[Base].[NotificationType.CollectionOfClientNotification]";

        return this.CollectionOf<ClientNotification>(procedureName, 
                                                        new SqlParameter("@Id", notificationType_Id), 
                                                        new SqlParameter("@jsonValue", clientNotification.ToJson()), 
                                                        new SqlParameter("@CurrentUser_Id", userCredit.UserAccount_Id));
    }
}
