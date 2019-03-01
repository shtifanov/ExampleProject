using System;

namespace ExampleProject.Common.Helpers
{
    public static class EnumHelpers
    {
        public static string GetName<TEnum>(this TEnum value) where TEnum : struct
        {
            CheckIfTypeIsEnum<TEnum>();
            return Enum.GetName(typeof(TEnum), value);
        }

        public static TEnum GetValue<TEnum>(this string name) where TEnum : struct
        {
            CheckIfTypeIsEnum<TEnum>();
            return Enum.Parse<TEnum>(name, true);
        }

        public static bool TryGetValue<TEnum>(this string name, out TEnum value) where TEnum: struct
        {
            CheckIfTypeIsEnum<TEnum>();
            return Enum.TryParse(name, true, out value);
        }

        private static void CheckIfTypeIsEnum<TEnum>()
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("Only Enums are supported");
        }
    }
}