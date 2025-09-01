
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class BookingTransaction : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "BookingTransaction", "Booking Transaction", "fund/bookingtransaction");

    #region Constructor
    public BookingTransaction() : this(0)
    {

    }

    public BookingTransaction(int id) : this(id, new byte[0])
    {

    }

    public BookingTransaction(int id, byte[] timeStamp) : base(id, timeStamp, BookingTransaction.Informer)
    {

    }

    protected BookingTransaction(int id, byte[] timeStamp, Info info) : base(id, timeStamp, BookingTransaction.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Base.Booking Booking { get; set; }
	
    public ClientWallet ClientWallet { get; set; }
	
    public ProviderWallet ProviderWallet { get; set; }
	
    public decimal? Amount { get; set; }
	
    public DateOnly? Date { get; set; }
	
    public TimeOnly? Time { get; set; }
	
	public string PaymentNote { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Booking.Validate() &&
				ClientWallet.Validate() &&
				ProviderWallet.Validate() &&
				Amount.Validate() &&
				Date.Validate() &&
				Time.Validate() &&
				PaymentNote.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
