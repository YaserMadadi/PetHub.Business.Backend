using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserCredit userCredit);
    }
}
