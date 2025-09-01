
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class EnterpriseProvider : Provider, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "EnterpriseProvider", "Enterprise Provider", "base/enterpriseprovider");

    #region Constructor
    public EnterpriseProvider() : this(0)
    {

    }

    public EnterpriseProvider(int id) : this(id, new byte[0])
    {

    }

    public EnterpriseProvider(int id, byte[] timeStamp) : base(id, timeStamp, EnterpriseProvider.Informer)
    {

    }

    protected EnterpriseProvider(int id, byte[] timeStamp, Info info) : base(id, timeStamp, EnterpriseProvider.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Id { get; set; }
	
	public string Title { get; set; }
	
	public string BusinessNumber { get; set; }

	#endregion

    #region    List Of ....

	public List<EnterpriseProviderInsurance> ListOfEnterpriseProviderInsurance { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return base.Validate() &&
				Title.Validate() &&
				BusinessNumber.Validate();
    }
}
