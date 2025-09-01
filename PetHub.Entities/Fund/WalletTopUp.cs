
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class WalletTopUp : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "WalletTopUp", "Wallet Top Up", "fund/wallettopup");

    #region Constructor
    public WalletTopUp() : this(0)
    {

    }

    public WalletTopUp(int id) : this(id, new byte[0])
    {

    }

    public WalletTopUp(int id, byte[] timeStamp) : base(id, timeStamp, WalletTopUp.Informer)
    {

    }

    protected WalletTopUp(int id, byte[] timeStamp, Info info) : base(id, timeStamp, WalletTopUp.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public ClientWallet ClientWallet { get; set; }
	
    public decimal? Amount { get; set; }
	
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
    public PaymentMethod PaymentMethod { get; set; }
	
	public string TransactionID { get; set; }
	
    public TransactionStatus TransactionStatus { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return ClientWallet.Validate() &&
				Amount.Validate() &&
				Date.Validate() &&
				Time.Validate() &&
				PaymentMethod.Validate() &&
				TransactionID.Validate() &&
				TransactionStatus.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
