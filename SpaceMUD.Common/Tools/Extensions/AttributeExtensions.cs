using SpaceMUD.Common.Tools.Attributes;
using System;


namespace SpaceMUD.Common.Tools.Extensions
{
    public static class AttributeExtensions
    {
        [Credit("Troy Alford", "https://stackoverflow.com/questions/19617778/how-to-get-assigned-string-values-from-enum/19621436#19621436")]
        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }

        /// <summary>
        /// Same as above, only overloaded to work with classes/objects as well
        /// </summary>
        /// <typeparam name="T">The Attribute type to return.</typeparam>
        public static T GetAttribute<T>(this Object value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
    }
}
