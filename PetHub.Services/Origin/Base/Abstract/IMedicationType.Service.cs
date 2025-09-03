
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IMedicationType_Service : IService<MedicationType>
{
    DataResult<List<PetMedicalCondition>> CollectionOfPetMedicalCondition(int petMedicalCondition_Id, PetMedicalCondition petMedicalCondition, UserCredit userCredit);
}
