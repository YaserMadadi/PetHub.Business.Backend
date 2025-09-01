
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class PriceScope : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "PriceScope", "Price Scope", "base/pricescope");

    #region Constructor
    public PriceScope() : this(0)
    {

    }

    public PriceScope(int id) : this(id, new byte[0])
    {

    }

    public PriceScope(int id, byte[] timeStamp) : base(id, timeStamp, PriceScope.Informer)
    {

    }

    protected PriceScope(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PriceScope.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ServicePrice> ListOfServicePrice { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
