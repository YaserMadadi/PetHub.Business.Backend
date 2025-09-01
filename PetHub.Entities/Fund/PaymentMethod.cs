
using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace PetHub.Entities.Fund;

public class PaymentMethod : EntityBase, IEntityBase
{
    public static Info Informer { get; } = new Info("Fund", "PaymentMethod", "Payment Method", "fund/paymentmethod");

    #region Constructor
    public PaymentMethod() : this(0)
    {

    }

    public PaymentMethod(int id) : this(id, new byte[0])
    {

    }

    public PaymentMethod(int id, byte[] timeStamp) : base(id, timeStamp, PaymentMethod.Informer)
    {

    }

    protected PaymentMethod(int id, byte[] timeStamp, Info info) : base(id, timeStamp, PaymentMethod.Informer)
    {

    }   

    #endregion

    #region Properties

		
	public string Title { get; set; }
	
	public bool? IsActive { get; set; }

	#endregion

    #region    List Of ....

	public List<WalletTopUp> ListOfWalletTopUp { get; set; } = new();

	#endregion

    
    public override bool Validate()
    {
        return Title.Validate() &&
				IsActive.Validate();
    }
}
