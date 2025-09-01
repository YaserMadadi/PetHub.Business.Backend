
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class ResultMessage : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "ResultMessage", "Result Message", "infra/resultmessage");

    #region Constructor
    public ResultMessage() : this(0)
    {

    }

    public ResultMessage(int id) : this(id, new byte[0])
    {

    }

    public ResultMessage(int id, byte[] timeStamp) : base(id, timeStamp, ResultMessage.Informer)
    {

    }

    protected ResultMessage(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ResultMessage.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public int? Id { get; set; }
	
    public int? Code { get; set; }
	
	public string Title { get; set; }
	
	public string MessageBody { get; set; }
	
    public MessageType MessageType { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Code.Validate() &&
				Title.Validate() &&
				MessageBody.Validate() &&
				MessageType.Validate();
    }
}
