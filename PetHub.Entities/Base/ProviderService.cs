
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ProviderService : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ProviderService", "Provider Service", "base/providerservice");

    #region Constructor
    public ProviderService() : this(0)
    {

    }

    public ProviderService(int id) : this(id, new byte[0])
    {

    }

    public ProviderService(int id, byte[] timeStamp) : base(id, timeStamp, ProviderService.Informer)
    {

    }

    protected ProviderService(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderService.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public ServiceType ServiceType { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<BookingService> ListOfBookingService { get; set; } = new();

	public List<ServiceOrientedWorkTime> ListOfServiceOrientedWorkTime { get; set; } = new();

	public List<ServicePrice> ListOfServicePrice { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				ServiceType.Validate() &&
				IsActive.Validate();
    }
}
