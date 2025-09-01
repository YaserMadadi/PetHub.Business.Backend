
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ConnectionType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ConnectionType", "Connection Type", "base/connectiontype");

    #region Constructor
    public ConnectionType() : this(0)
    {

    }

    public ConnectionType(int id) : this(id, new byte[0])
    {

    }

    public ConnectionType(int id, byte[] timeStamp) : base(id, timeStamp, ConnectionType.Informer)
    {

    }

    protected ConnectionType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ConnectionType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ProviderConnection> ListOfProviderConnection { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
