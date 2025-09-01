using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Validator
{
    public static class ValidatorExtension
    {
        public static bool Validate(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool Validate(this DateTime? value)
        {
            return value.HasValue;
        }

        public static bool Validate(this DateOnly? value)
        {
            return value.HasValue; // && value.Value != default;
        }

        public static bool Validate(this TimeOnly? value)
        {
            return value.HasValue; // && value.Value != default;
        }

        public static bool Validate(this IEntityBase entityBase)
        {
            return entityBase.Validate();
        }

        public static bool Validate(this bool boolValue)
        {
            return boolValue == true || boolValue == false;
        }

        public static bool Validate(this bool? boolValue)
        {
            return boolValue.HasValue;
        }


        public static bool Validate(this byte[]? value)
        {
            return value != null && value.Length > 0;
        }



        public static bool Validate(this short? shortValue, short minValue = 0, short maxValue = short.MaxValue)
        {
            return shortValue.HasValue && shortValue >= minValue && shortValue <= maxValue;
        }

        public static bool Validate(this int? intValue, int minValue = 0, int maxValue = int.MaxValue)
        {
            return intValue.HasValue && intValue >= minValue && intValue <= maxValue;
        }

        public static bool Validate(this byte? shortValue, byte minValue = 0, byte maxValue = byte.MaxValue)
        {
            return shortValue.HasValue && shortValue >= minValue && shortValue <= maxValue;
        }

        public static bool Validate(this long? shortValue, long minValue = 0, long maxValue = long.MaxValue)
        {
            return shortValue.HasValue && shortValue >= minValue && shortValue <= maxValue;
        }

        public static bool Validate(this float? floatValue)
        {
            return floatValue.HasValue;
        }

        public static bool Validate(this decimal value, decimal minValue = 0, decimal maxValue = decimal.MaxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        public static bool Validate(this decimal? value, decimal minValue = 0, decimal maxValue= decimal.MaxValue)
        {
            return value.HasValue && value >= minValue && value <= maxValue;
        }


    }
}
