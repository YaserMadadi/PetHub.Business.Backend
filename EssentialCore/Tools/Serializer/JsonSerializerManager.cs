using EssentialCore.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Serializer
{
    public enum JsonType
    {
        Single,
        Collection
    }

    public static class JsonSerializerManager
    {
        static JsonSerializerManager()
        {
            setting = new JsonSerializerSettings();

            //setting.DateFormatString = "";// DateFormatHandling.IsoDateFormat;
        }

        private static JsonSerializerSettings setting { get; set; }

        public static string Serialize(this object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }

        private const string listName = "List`1";

        public static T Deserialize<T>(this string jsonValue, JsonType jsonType)
        {

            if (jsonType == JsonType.Collection)
            {
                jsonValue = string.IsNullOrWhiteSpace(jsonValue) ? "[]" : jsonValue;
            }
            else // JsonType.Single
            {
                jsonValue = string.IsNullOrWhiteSpace(jsonValue) ? "{}" : jsonValue.Singlize();
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(jsonValue);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public static string Singlize(this string jsonValue)
        {
            return jsonValue.Trim('[', ']');
        }
    }
}
