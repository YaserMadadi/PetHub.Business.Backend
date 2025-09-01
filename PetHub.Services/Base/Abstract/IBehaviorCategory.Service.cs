
using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using PetHub.Entities.Base;

namespace PetHub.Services.Base.Abstract;

public interface IBehaviorCategory_Service : IService<BehaviorCategory>
{
    DataResult<List<PetBehavior>> CollectionOfPetBehavior(int petBehavior_Id, PetBehavior petBehavior, UserCredit userCredit);
}
