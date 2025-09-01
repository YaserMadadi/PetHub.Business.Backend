
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class MessageType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "MessageType", "Message Type", "infra/messagetype");

    #region Constructor
    public MessageType() : this(0)
    {

    }

    public MessageType(int id) : this(id, new byte[0])
    {

    }

    public MessageType(int id, byte[] timeStamp) : base(id, timeStamp, MessageType.Informer)
    {

    }

    protected MessageType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, MessageType.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public int? Id { get; set; }
	
	public string Title { get; set; }

	#endregion

    #region    List Of ....

	public List<ResultMessage> ListOfResultMessage { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate();
    }
}
