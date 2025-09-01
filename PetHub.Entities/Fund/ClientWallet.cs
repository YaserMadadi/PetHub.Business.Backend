
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class ClientWallet : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "ClientWallet", "Client Wallet", "fund/clientwallet");

    #region Constructor
    public ClientWallet() : this(0)
    {

    }

    public ClientWallet(int id) : this(id, new byte[0])
    {

    }

    public ClientWallet(int id, byte[] timeStamp) : base(id, timeStamp, ClientWallet.Informer)
    {

    }

    protected ClientWallet(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ClientWallet.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Base.Client Client { get; set; }
	
    public decimal? Balance { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<BookingTransaction> ListOfBookingTransaction { get; set; } = new();

	public List<ClientWalletTransactionLog> ListOfClientWalletTransactionLog { get; set; } = new();

	public List<WalletTopUp> ListOfWalletTopUp { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Client.Validate() &&
				Balance.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
