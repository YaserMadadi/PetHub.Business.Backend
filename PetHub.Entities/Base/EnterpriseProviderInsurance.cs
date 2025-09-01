
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class EnterpriseProviderInsurance : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "EnterpriseProviderInsurance", "Enterprise Provider Insurance", "base/enterpriseproviderinsurance");

    #region Constructor
    public EnterpriseProviderInsurance() : this(0)
    {

    }

    public EnterpriseProviderInsurance(int id) : this(id, new byte[0])
    {

    }

    public EnterpriseProviderInsurance(int id, byte[] timeStamp) : base(id, timeStamp, EnterpriseProviderInsurance.Informer)
    {

    }

    protected EnterpriseProviderInsurance(int id, byte[] timeStamp, Info info) : base(id, timeStamp, EnterpriseProviderInsurance.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public EnterpriseProvider EnterpriseProvider { get; set; }
	
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return EnterpriseProvider.Validate() &&
				Title.Validate() &&
				IsActive.Validate();
    }
}
