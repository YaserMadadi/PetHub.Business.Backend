
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class TransactionStatus : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "TransactionStatus", "Transaction Status", "fund/transactionstatus");

    #region Constructor
    public TransactionStatus() : this(0)
    {

    }

    public TransactionStatus(int id) : this(id, new byte[0])
    {

    }

    public TransactionStatus(int id, byte[] timeStamp) : base(id, timeStamp, TransactionStatus.Informer)
    {

    }

    protected TransactionStatus(int id, byte[] timeStamp, Info info) : base(id, timeStamp, TransactionStatus.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ClientWalletTransactionLog> ListOfClientWalletTransactionLog { get; set; } = new();

	public List<ProviderPayOut> ListOfProviderPayOut { get; set; } = new();

	public List<WalletTopUp> ListOfWalletTopUp { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
