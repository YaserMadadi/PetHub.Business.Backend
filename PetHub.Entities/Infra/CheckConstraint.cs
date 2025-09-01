
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Infra;

public class CheckConstraint : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Infra", "CheckConstraint", "Check Constraint", "infra/checkconstraint");

    #region Constructor
    public CheckConstraint() : this(0)
    {

    }

    public CheckConstraint(int id) : this(id, new byte[0])
    {

    }

    public CheckConstraint(int id, byte[] timeStamp) : base(id, timeStamp, CheckConstraint.Informer)
    {

    }

    protected CheckConstraint(int id, byte[] timeStamp, Info info) : base(id, timeStamp, CheckConstraint.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Name { get; set; }
	
	public string SchemaName { get; set; }
	
	public string EntityName { get; set; }
	
	public string Definition { get; set; }
	
	public string Message { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	#endregion

    
    public override bool Validate()
    {
        return Name.Validate() &&
				SchemaName.Validate() &&
				EntityName.Validate() &&
				Definition.Validate() &&
				Message.Validate() &&
				IsActive.Validate();
    }
}
