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
        /// Same as above, only overloaded to work with types directly.
        /// </summary>
        /// <typeparam name="T">The attribute type to return</typeparam>
        public static T GetAttribute<T>(this Type type) where T: Attribute
        {
            var attributes = type.GetCustomAttributes(inherit:true);
            foreach(var attribute in attributes)
            {
                if(attribute.GetType() == typeof(T))
                {
                    return attribute as T;
                }
            }

            return null;
        }
        /// <summary>
        /// Same as above, only overloaded to work with classes/objects as well
        /// </summary>
        /// <typeparam name="T">The Attribute type to return.</typeparam>
        public static T GetAttribute<T>(this Object value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.IsFixedSize == null || memberInfo.Length == 0)
            {
                throw new MissingMemberException($"Member info of class type {type.Name} : {type.Namespace} has no values.");
            }
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
    }
}
