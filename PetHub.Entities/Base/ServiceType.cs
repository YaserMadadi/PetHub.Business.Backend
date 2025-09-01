
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ServiceType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ServiceType", "Service Type", "base/servicetype");

    #region Constructor
    public ServiceType() : this(0)
    {

    }

    public ServiceType(int id) : this(id, new byte[0])
    {

    }

    public ServiceType(int id, byte[] timeStamp) : base(id, timeStamp, ServiceType.Informer)
    {

    }

    protected ServiceType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ServiceType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ProviderService> ListOfProviderService { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
