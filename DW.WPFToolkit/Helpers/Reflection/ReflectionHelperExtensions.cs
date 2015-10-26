
using System;
using System.Reflection;

namespace DW.WPFToolkit.Helpers.Reflection
{
    /// <summary>
    /// Helper class for Reflection.
    /// </summary>
    public static class ReflectionHelperExtensions
    {

        /// <summary>
        /// Get the PropertyInfo through a Property Name.
        /// </summary>
        /// <param name="type">The Type of the Instance.</param>
        /// <param name="propertyName">The Name of the Property.</param>
        /// <returns>The found PropertyInfo.</returns>
        private static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            PropertyInfo propInfo = null;
            do
            {
                propInfo = type.GetProperty(propertyName,
                       BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                type = type.BaseType;
            }
            while (propInfo == null && type != null);
            return propInfo;
        }

        /// <summary>
        /// Get the Property Value through a Property Name.
        /// </summary>
        /// <param name="obj">The Instance of the Type where the Property is defined.</param>
        /// <param name="propertyName">The Name of the Property.</param>
        /// <returns>The found Value. Throws exception if not found.</returns>
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Type objType = obj.GetType();
            PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
            if (propInfo == null)
                throw new ArgumentOutOfRangeException("propertyName",
                  string.Format("Couldn't find property {0} in type {1}", propertyName, objType.FullName));
            return propInfo.GetValue(obj, null);
        }
    }
}
