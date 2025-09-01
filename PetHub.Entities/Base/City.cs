
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class City : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "City", "City", "base/city");

    #region Constructor
    public City() : this(0)
    {

    }

    public City(int id) : this(id, new byte[0])
    {

    }

    public City(int id, byte[] timeStamp) : base(id, timeStamp, City.Informer)
    {

    }

    protected City(int id, byte[] timeStamp, Info info) : base(id, timeStamp, City.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
    public Province Province { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Client> ListOfClient { get; set; } = new();

	public List<LocationCoverage> ListOfLocationCoverage { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Province.Validate() &&
				IsActive.Validate();
    }
}
