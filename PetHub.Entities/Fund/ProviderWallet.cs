
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class ProviderWallet : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "ProviderWallet", "Provider Wallet", "fund/providerwallet");

    #region Constructor
    public ProviderWallet() : this(0)
    {

    }

    public ProviderWallet(int id) : this(id, new byte[0])
    {

    }

    public ProviderWallet(int id, byte[] timeStamp) : base(id, timeStamp, ProviderWallet.Informer)
    {

    }

    protected ProviderWallet(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderWallet.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Base.Provider Provider { get; set; }
	
    public decimal? Balance { get; set; }
	
	public string Note { get; set; }

	#endregion

    #region    List Of ....

	public List<BookingTransaction> ListOfBookingTransaction { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				Balance.Validate() &&
				Note.Validate();
    }
}
