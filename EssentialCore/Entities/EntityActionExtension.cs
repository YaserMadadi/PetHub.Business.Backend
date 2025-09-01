using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.Entities;
using EssentialCore.Tools.Security.Entities;

namespace EssentialCore.Entities
{
    public static class EntityActionExtension
    {
        public async static Task<ActionResult<string>> SaveCollection<T>(this T[] entityCollection, Info info, UserCredit userCredit) where T : IEntityBase
        {
            return await entityCollection.ToList<T>().SaveCollection<T>(info, userCredit);
        }

        public async static Task<ActionResult<string>> SaveCollection<T>(this List<T> entityCollection, Info info, UserCredit userCredit) where T : IEntityBase
        {
            //TODO: Check Permission in SaveCollection Method

            if (entityCollection.Count == 0)

                return new BadRequestObjectResult(new ErrorResult(-1, "Collection is Empty", string.Empty));

            var result = await UserClass.CreateCommand($"[{info.Schema}].[{info.Name}.SaveCollection]",
                                                        new SqlParameter("@JsonValue", entityCollection.ToJson()))
                                                                .ExecuteResult();

            if (result.IsSucceeded)

                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }

        public static bool CheckList<T>(this List<T> list) where T : IEntityBase
        {
            return list != null && list.Count > 0;
        }
    }
}
