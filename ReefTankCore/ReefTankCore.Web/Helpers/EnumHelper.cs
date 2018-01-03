using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReefTankCore.Web.Helpers
{
    public class EnumHelper<T>
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static IList<T> GetValues(Enum value)
        //{
        //    var enumValues = new List<T>();

        //    foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
        //    {
        //        enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
        //    }
        //    return enumValues;
        //}

        //public static T Parse(string value)
        //{
        //    return (T)Enum.Parse(typeof(T), value, true);
        //}

        ///// <summary>
        ///// Gets the list of names of each value of the given enum.
        ///// </summary>
        ///// <param name="value">Enum</param>
        ///// <returns></returns>
        //public static IList<string> GetNames(Enum value)
        //{
        //    return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        //}

        ///// <summary>
        ///// Gets a list of display values of the given enum.
        ///// </summary>
        ///// <param name="value">Enum</param>
        ///// <returns></returns>
        //public static IList<string> GetDisplayValues(Enum value)
        //{
        //    return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        //}

        /// <summary>
        /// No idea what this does.
        /// </summary>
        /// <param name="resourceManagerProvider"></param>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        private static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
                {
                    System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
                    return resourceManager.GetString(resourceKey);
                }
            }

            return resourceKey; // Fallback with the key name
        }

        /// <summary>
        /// Gets the display value of the give enum value.
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns></returns>
        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes[0].ResourceType != null)
                return LookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
