
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Booking : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Booking", "Booking", "base/booking");

    #region Constructor
    public Booking() : this(0)
    {

    }

    public Booking(int id) : this(id, new byte[0])
    {

    }

    public Booking(int id, byte[] timeStamp) : base(id, timeStamp, Booking.Informer)
    {

    }

    protected Booking(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Booking.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Pet Pet { get; set; }
	
    public Provider Provider { get; set; }
	
    public DateOnly? StartDate { get; set; }
	
    public TimeOnly? StartTime { get; set; }
	
    public byte? Duration { get; set; }
	
    public DurationUnit DurationUnit { get; set; }
	
    public decimal? TotalAmount { get; set; }
	
    public BookingStatus BookingStatus { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<BookingService> ListOfBookingService { get; set; } = new();

	public List<Fund.BookingTransaction> ListOfBookingTransaction { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Pet.Validate() &&
				Provider.Validate() &&
				StartDate.Validate() &&
				StartTime.Validate() &&
				Duration.Validate() &&
				DurationUnit.Validate() &&
				TotalAmount.Validate() &&
				BookingStatus.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
