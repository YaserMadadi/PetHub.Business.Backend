
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class LocationCoverage : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "LocationCoverage", "Location Coverage", "base/locationcoverage");

    #region Constructor
    public LocationCoverage() : this(0)
    {

    }

    public LocationCoverage(int id) : this(id, new byte[0])
    {

    }

    public LocationCoverage(int id, byte[] timeStamp) : base(id, timeStamp, LocationCoverage.Informer)
    {

    }

    protected LocationCoverage(int id, byte[] timeStamp, Info info) : base(id, timeStamp, LocationCoverage.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public City City { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				City.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
