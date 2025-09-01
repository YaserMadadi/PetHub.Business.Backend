
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class BookingService : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "BookingService", "Booking Service", "base/bookingservice");

    #region Constructor
    public BookingService() : this(0)
    {

    }

    public BookingService(int id) : this(id, new byte[0])
    {

    }

    public BookingService(int id, byte[] timeStamp) : base(id, timeStamp, BookingService.Informer)
    {

    }

    protected BookingService(int id, byte[] timeStamp, Info info) : base(id, timeStamp, BookingService.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Booking Booking { get; set; }
	
    public ProviderService ProviderService { get; set; }
	
    public decimal? Amount { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Booking.Validate() &&
				ProviderService.Validate() &&
				Amount.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
