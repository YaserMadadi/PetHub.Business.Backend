
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Base;

public class ClientReview : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Base", "ClientReview", "Client Review", "base/clientreview");

    #region Constructor
    public ClientReview() : this(0)
    {

    }

    public ClientReview(int id) : this(id, new byte[0])
    {

    }

    public ClientReview(int id, byte[] timeStamp) : base(id, timeStamp, ClientReview.Informer)
    {

    }

    protected ClientReview(int id, byte[] timeStamp, Info info) : base(id, timeStamp, ClientReview.Informer)
    {

    }   

    #endregion

    #region Properties

		
    public Client Client { get; set; }
	
    public Provider Provider { get; set; }
	
	public DateTime? Time { get; set; }
	
	public string Note { get; set; }
	
    public decimal? Rate { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Client.Validate() &&
				Provider.Validate() &&
				Time.Validate() &&
				Note.Validate() &&
				Rate.Validate() &&
				IsActive.Validate();
    }
}
