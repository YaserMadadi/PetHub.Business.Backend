
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ServiceOrientedWorkTime : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ServiceOrientedWorkTime", "Service Oriented Work Time", "base/serviceorientedworktime");

    #region Constructor
    public ServiceOrientedWorkTime() : this(0)
    {

    }

    public ServiceOrientedWorkTime(int id) : this(id, new byte[0])
    {

    }

    public ServiceOrientedWorkTime(int id, byte[] timeStamp) : base(id, timeStamp, ServiceOrientedWorkTime.Informer)
    {

    }

    protected ServiceOrientedWorkTime(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ServiceOrientedWorkTime.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public ProviderService ProviderService { get; set; }
	
    public WeekDay WeekDay { get; set; }
	
    public TimeOnly? From { get; set; }
	
    public TimeOnly? To { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return ProviderService.Validate() &&
				WeekDay.Validate() &&
				From.Validate() &&
				To.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
