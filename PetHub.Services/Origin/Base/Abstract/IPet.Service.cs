
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IPet_Service : IService<Pet>
{
    DataResult<List<Booking>> CollectionOfBooking(int booking_Id, Booking booking, UserCredit userCredit);

	DataResult<List<PetBehavior>> CollectionOfPetBehavior(int petBehavior_Id, PetBehavior petBehavior, UserCredit userCredit);

	DataResult<List<PetMedicalCondition>> CollectionOfPetMedicalCondition(int petMedicalCondition_Id, PetMedicalCondition petMedicalCondition, UserCredit userCredit);
}
