
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Province : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Province", "Province", "base/province");

    #region Constructor
    public Province() : this(0)
    {

    }

    public Province(int id) : this(id, new byte[0])
    {

    }

    public Province(int id, byte[] timeStamp) : base(id, timeStamp, Province.Informer)
    {

    }

    protected Province(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Province.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
    public Country Country { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<City> ListOfCity { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Country.Validate() &&
				IsActive.Validate();
    }
}
