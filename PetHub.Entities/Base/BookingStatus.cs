
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class BookingStatus : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "BookingStatus", "Booking Status", "base/bookingstatus");

    #region Constructor
    public BookingStatus() : this(0)
    {

    }

    public BookingStatus(int id) : this(id, new byte[0])
    {

    }

    public BookingStatus(int id, byte[] timeStamp) : base(id, timeStamp, BookingStatus.Informer)
    {

    }

    protected BookingStatus(int id, byte[] timeStamp, Info info) : base(id, timeStamp, BookingStatus.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Booking> ListOfBooking { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
