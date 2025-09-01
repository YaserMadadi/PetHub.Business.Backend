
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class CertificationType : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "CertificationType", "Certification Type", "base/certificationtype");

    #region Constructor
    public CertificationType() : this(0)
    {

    }

    public CertificationType(int id) : this(id, new byte[0])
    {

    }

    public CertificationType(int id, byte[] timeStamp) : base(id, timeStamp, CertificationType.Informer)
    {

    }

    protected CertificationType(int id, byte[] timeStamp, Info info) : base(id, timeStamp, CertificationType.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public string Note { get; set; }
	
	public bool? IsIndividual { get; set; }
	
	public bool? IsEnterprise { get; set; }

	#endregion

    #region    List Of ....

	public List<Certification> ListOfCertification { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				Note.Validate() &&
				IsIndividual.Validate() &&
				IsEnterprise.Validate();
    }
}
