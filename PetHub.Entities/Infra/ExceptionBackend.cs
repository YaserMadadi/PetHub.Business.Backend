
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class ExceptionBackend : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "ExceptionBackend", "Exception Backend", "infra/exceptionbackend");

    #region Constructor
    public ExceptionBackend() : this(0)
    {

    }

    public ExceptionBackend(int id) : this(id, new byte[0])
    {

    }

    public ExceptionBackend(int id, byte[] timeStamp) : base(id, timeStamp, ExceptionBackend.Informer)
    {

    }

    protected ExceptionBackend(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ExceptionBackend.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
	public string CommandName { get; set; }
	
	public string CommandParameters { get; set; }
	
	public string ExceptionType { get; set; }
	
	public string ErrorMessage { get; set; }
	
    public int? ErrorNumber { get; set; }
	
    public int? ErrorCode { get; set; }
	
	public string ExceptionJsonValue { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Date.Validate() &&
				Time.Validate() &&
				CommandName.Validate() &&
				CommandParameters.Validate() &&
				ExceptionType.Validate() &&
				ErrorMessage.Validate() &&
				ErrorNumber.Validate() &&
				ErrorCode.Validate() &&
				ExceptionJsonValue.Validate();
    }
}
