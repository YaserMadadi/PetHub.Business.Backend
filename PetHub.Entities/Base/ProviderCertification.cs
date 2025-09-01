
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ProviderCertification : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ProviderCertification", "Provider Certification", "base/providercertification");

    #region Constructor
    public ProviderCertification() : this(0)
    {

    }

    public ProviderCertification(int id) : this(id, new byte[0])
    {

    }

    public ProviderCertification(int id, byte[] timeStamp) : base(id, timeStamp, ProviderCertification.Informer)
    {

    }

    protected ProviderCertification(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ProviderCertification.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Provider Provider { get; set; }
	
    public Certification Certification { get; set; }
	
    public DateOnly? DateIssued { get; set; }
	
    public DateOnly? ExpiryDate { get; set; }
	
	public string DocumentUrl { get; set; }
	
	public bool? IsApproved { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Provider.Validate() &&
				Certification.Validate() &&
				DateIssued.Validate() &&
				ExpiryDate.Validate() &&
				DocumentUrl.Validate() &&
				IsApproved.Validate() &&
				IsActive.Validate();
    }
}
