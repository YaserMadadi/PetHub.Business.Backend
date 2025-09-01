
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ServicePrice : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ServicePrice", "Service Price", "base/serviceprice");

    #region Constructor
    public ServicePrice() : this(0)
    {

    }

    public ServicePrice(int id) : this(id, new byte[0])
    {

    }

    public ServicePrice(int id, byte[] timeStamp) : base(id, timeStamp, ServicePrice.Informer)
    {

    }

    protected ServicePrice(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ServicePrice.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public ProviderService ProviderService { get; set; }
	
    public PriceScope PriceScope { get; set; }
	
	public string Note { get; set; }
	
    public decimal? Amount { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return ProviderService.Validate() &&
				PriceScope.Validate() &&
				Note.Validate() &&
				Amount.Validate() &&
				IsActive.Validate();
    }
}
