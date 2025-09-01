
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class TransactionType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "TransactionType", "Transaction Type", "fund/transactiontype");

    #region Constructor
    public TransactionType() : this(0)
    {

    }

    public TransactionType(int id) : this(id, new byte[0])
    {

    }

    public TransactionType(int id, byte[] timeStamp) : base(id, timeStamp, TransactionType.Informer)
    {

    }

    protected TransactionType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, TransactionType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ClientWalletTransactionLog> ListOfClientWalletTransactionLog { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
