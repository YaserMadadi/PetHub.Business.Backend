
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class ClientWalletTransactionLog : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "ClientWalletTransactionLog", "Client Wallet Transaction Log", "fund/clientwallettransactionlog");

    #region Constructor
    public ClientWalletTransactionLog() : this(0)
    {

    }

    public ClientWalletTransactionLog(int id) : this(id, new byte[0])
    {

    }

    public ClientWalletTransactionLog(int id, byte[] timeStamp) : base(id, timeStamp, ClientWalletTransactionLog.Informer)
    {

    }

    protected ClientWalletTransactionLog(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ClientWalletTransactionLog.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public ClientWallet ClientWallet { get; set; }
	
    public TransactionType TransactionType { get; set; }
	
    public decimal? Amount { get; set; }
	
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
    public TransactionStatus TransactionStatus { get; set; }
	
    public decimal? Balance { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return ClientWallet.Validate() &&
				TransactionType.Validate() &&
				Amount.Validate() &&
				Date.Validate() &&
				Time.Validate() &&
				TransactionStatus.Validate() &&
				Balance.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
