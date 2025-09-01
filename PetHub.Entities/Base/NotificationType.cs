
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class NotificationType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "NotificationType", "Notification Type", "base/notificationtype");

    #region Constructor
    public NotificationType() : this(0)
    {

    }

    public NotificationType(int id) : this(id, new byte[0])
    {

    }

    public NotificationType(int id, byte[] timeStamp) : base(id, timeStamp, NotificationType.Informer)
    {

    }

    protected NotificationType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, NotificationType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ClientNotification> ListOfClientNotification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
