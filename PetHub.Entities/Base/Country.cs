
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Country : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Country", "Country", "base/country");

    #region Constructor
    public Country() : this(0)
    {

    }

    public Country(int id) : this(id, new byte[0])
    {

    }

    public Country(int id, byte[] timeStamp) : base(id, timeStamp, Country.Informer)
    {

    }

    protected Country(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Country.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Province> ListOfProvince { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
