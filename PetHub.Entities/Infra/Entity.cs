
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class Entity : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "Entity", "Entity", "infra/entity");

    #region Constructor
    public Entity() : this(0)
    {

    }

    public Entity(int id) : this(id, new byte[0])
    {

    }

    public Entity(int id, byte[] timeStamp) : base(id, timeStamp, Entity.Informer)
    {

    }

    protected Entity(int id, byte[] timeStamp, Info info) : base(id, timeStamp, Entity.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Schema { get; set; }
	
	public string Name { get; set; }
	
	public string Synonym { get; set; }
	
	public string GuideTitle { get; set; }
	
	public string IndexUrl { get; set; }
	
    public byte? RecordPerPage { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Schema.Validate() &&
				Name.Validate() &&
				Synonym.Validate() &&
				GuideTitle.Validate() &&
				IndexUrl.Validate() &&
				RecordPerPage.Validate() &&
				IsActive.Validate();
    }
}
