
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class Certification : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "Certification", "Certification", "base/certification");

    #region Constructor
    public Certification() : this(0)
    {

    }

    public Certification(int id) : this(id, new byte[0])
    {

    }

    public Certification(int id, byte[] timeStamp) : base(id, timeStamp, Certification.Informer)
    {

    }

    protected Certification(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Certification.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public CertificationType CertificationType { get; set; }
	
    public CertIssuingOrganization CertIssuingOrganization { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<ProviderCertification> ListOfProviderCertification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return CertificationType.Validate() &&
				CertIssuingOrganization.Validate() &&
				IsActive.Validate();
    }
}
