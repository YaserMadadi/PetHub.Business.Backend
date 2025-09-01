
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ClientNotification : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ClientNotification", "Client Notification", "base/clientnotification");

    #region Constructor
    public ClientNotification() : this(0)
    {

    }

    public ClientNotification(int id) : this(id, new byte[0])
    {

    }

    public ClientNotification(int id, byte[] timeStamp) : base(id, timeStamp, ClientNotification.Informer)
    {

    }

    protected ClientNotification(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ClientNotification.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Client Client { get; set; }
	
	public DateTime? SentTime { get; set; }
	
	public string Title { get; set; }
	
	public string Message { get; set; }
	
    public NotificationType NotificationType { get; set; }
	
	public bool? IsRead { get; set; }
	
	public DateTime? ReadTime { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Client.Validate() &&
				SentTime.Validate() &&
				Title.Validate() &&
				Message.Validate() &&
				NotificationType.Validate() &&
				IsRead.Validate() &&
				ReadTime.Validate() &&
				IsActive.Validate();
    }
}
