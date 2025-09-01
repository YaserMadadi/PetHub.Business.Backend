using EssentialCore.Entities;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public static class EntityExtesion
    {
        public static string ToJson(this IEntityBase entity)
        {
            if (entity == null)
                return "{}";

            return entity.Serialize();
        }

        public static string ToJson(this Paginate paginate)
        {
            return paginate.Serialize();
        }

        public static string ToJson(this IList entityCollection)
        {
            return entityCollection.Serialize();
        }

        //public static T Deserialize<T>(this string jsonValue)
        //{
        //    if (typeof(T) is IList)

        //        return jsonValue.Deserialize<T>();

        //    return jsonValue.Trim('[', ']').Deserialize<T>();


        //}
    }
}
