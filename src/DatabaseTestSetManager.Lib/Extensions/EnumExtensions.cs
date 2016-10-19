using System;
using System.ComponentModel;
using System.Linq;

namespace DatabaseTestSetManager
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            var enumType = @enum.GetType();
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(enumType.GetMember(Enum.GetName(enumType, @enum)).First(), typeof(DescriptionAttribute));
            return attr != null ? attr.Description : @enum.ToString();
        }
    }
}
