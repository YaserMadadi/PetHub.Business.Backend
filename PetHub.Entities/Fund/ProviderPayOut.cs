
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class ProviderPayOut : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "ProviderPayOut", "Provider Pay Out", "fund/providerpayout");

    #region Constructor
    public ProviderPayOut() : this(0)
    {

    }

    public ProviderPayOut(int id) : this(id, new byte[0])
    {

    }

    public ProviderPayOut(int id, byte[] timeStamp) : base(id, timeStamp, ProviderPayOut.Informer)
    {

    }

    protected ProviderPayOut(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderPayOut.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Base.Provider Provider { get; set; }
	
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
    public decimal? Amount { get; set; }
	
	public string TransactionID { get; set; }
	
    public TransactionStatus TransactionStatus { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				Date.Validate() &&
				Time.Validate() &&
				Amount.Validate() &&
				TransactionID.Validate() &&
				TransactionStatus.Validate() &&
				Note.Validate();
    }
}
