using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.ExtenssionMethod
{
    public static class SqlParameterExtensionMethods
    {
        public static string ToJson(this Microsoft.Data.SqlClient.SqlParameterCollection parameters)
        {
            StringBuilder result = new();

            Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();


            for (int i = 0; i < parameters.Count; i++)
            {
                parameterDictionary.Add(parameters[i].ParameterName, parameters[i].Value.ToString());
            }

            return Tools.Serializer.JsonSerializerManager.Serialize(parameterDictionary);
        }
    }
}
