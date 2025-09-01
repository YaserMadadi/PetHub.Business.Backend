
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Bank : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Bank", "Bank", "base/bank");

    #region Constructor
    public Bank() : this(0)
    {

    }

    public Bank(int id) : this(id, new byte[0])
    {

    }

    public Bank(int id, byte[] timeStamp) : base(id, timeStamp, Bank.Informer)
    {

    }

    protected Bank(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Bank.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ProviderBankAccount> ListOfProviderBankAccount { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
