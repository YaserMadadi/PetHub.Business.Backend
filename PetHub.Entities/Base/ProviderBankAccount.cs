
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ProviderBankAccount : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ProviderBankAccount", "Provider Bank Account", "base/providerbankaccount");

    #region Constructor
    public ProviderBankAccount() : this(0)
    {

    }

    public ProviderBankAccount(int id) : this(id, new byte[0])
    {

    }

    public ProviderBankAccount(int id, byte[] timeStamp) : base(id, timeStamp, ProviderBankAccount.Informer)
    {

    }

    protected ProviderBankAccount(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderBankAccount.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public Bank Bank { get; set; }
	
    public int? InstitutionNumber { get; set; }
	
    public int? AccountNumber { get; set; }
	
	public string AccountHolderName { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				Bank.Validate() &&
				InstitutionNumber.Validate() &&
				AccountNumber.Validate() &&
				AccountHolderName.Validate() &&
				IsActive.Validate();
    }
}
