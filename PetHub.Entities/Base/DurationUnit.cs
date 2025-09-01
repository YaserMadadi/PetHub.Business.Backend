
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class DurationUnit : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "DurationUnit", "Duration Unit", "base/durationunit");

    #region Constructor
    public DurationUnit() : this(0)
    {

    }

    public DurationUnit(int id) : this(id, new byte[0])
    {

    }

    public DurationUnit(int id, byte[] timeStamp) : base(id, timeStamp, DurationUnit.Informer)
    {

    }

    protected DurationUnit(int id, byte[] timeStamp, Info info) : base(id, timeStamp, DurationUnit.Informer)
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
