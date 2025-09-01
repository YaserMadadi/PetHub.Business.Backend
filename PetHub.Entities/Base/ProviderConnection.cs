
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ProviderConnection : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ProviderConnection", "Provider Connection", "base/providerconnection");

    #region Constructor
    public ProviderConnection() : this(0)
    {

    }

    public ProviderConnection(int id) : this(id, new byte[0])
    {

    }

    public ProviderConnection(int id, byte[] timeStamp) : base(id, timeStamp, ProviderConnection.Informer)
    {

    }

    protected ProviderConnection(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderConnection.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public ConnectionType ConnectionType { get; set; }
	
	public string Value { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				ConnectionType.Validate() &&
				Value.Validate() &&
				IsActive.Validate();
    }
}
