
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ProviderType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ProviderType", "Provider Type", "base/providertype");

    #region Constructor
    public ProviderType() : this(0)
    {

    }

    public ProviderType(int id) : this(id, new byte[0])
    {

    }

    public ProviderType(int id, byte[] timeStamp) : base(id, timeStamp, ProviderType.Informer)
    {

    }

    protected ProviderType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Provider> ListOfProvider { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
