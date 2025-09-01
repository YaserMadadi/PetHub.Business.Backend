
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class ExceptionProcedure : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "ExceptionProcedure", "Exception Procedure", "infra/exceptionprocedure");

    #region Constructor
    public ExceptionProcedure() : this(0)
    {

    }

    public ExceptionProcedure(int id) : this(id, new byte[0])
    {

    }

    public ExceptionProcedure(int id, byte[] timeStamp) : base(id, timeStamp, ExceptionProcedure.Informer)
    {

    }

    protected ExceptionProcedure(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ExceptionProcedure.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Schema { get; set; }
	
	public string ProcedureName { get; set; }
	
    public short? LineNumber { get; set; }
	
	public string Parameter { get; set; }
	
    public int? UserAccount_Id { get; set; }
	
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
    public int? ErrorNumber { get; set; }
	
	public string ErrorMessage { get; set; }
	
    public int? ErrorStatus { get; set; }
	
	public bool? IsChecked { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Schema.Validate() &&
				ProcedureName.Validate() &&
				LineNumber.Validate() &&
				Parameter.Validate() &&
				UserAccount_Id.Validate() &&
				Date.Validate() &&
				Time.Validate() &&
				ErrorNumber.Validate() &&
				ErrorMessage.Validate() &&
				ErrorStatus.Validate() &&
				IsChecked.Validate();
    }
}
