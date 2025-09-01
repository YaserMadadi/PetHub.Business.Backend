
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class CertIssuingOrganization : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "CertIssuingOrganization", "Cert Issuing Organization", "base/certissuingorganization");

    #region Constructor
    public CertIssuingOrganization() : this(0)
    {

    }

    public CertIssuingOrganization(int id) : this(id, new byte[0])
    {

    }

    public CertIssuingOrganization(int id, byte[] timeStamp) : base(id, timeStamp, CertIssuingOrganization.Informer)
    {

    }

    protected CertIssuingOrganization(int id, byte[] timeStamp, Info info) : base(id, timeStamp, CertIssuingOrganization.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<Certification> ListOfCertification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Note.Validate() &&
				IsActive.Validate();
    }
}
