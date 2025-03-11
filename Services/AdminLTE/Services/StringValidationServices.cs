using System.Reflection;

namespace AdminLTE.Services
{
    public static class StringUtility
    {
        /// <summary>
        /// Converts all string properties of an object to lowercase.
        /// </summary>
        /// <param name="obj">The object whose string properties will be converted to lowercase.</param>
        public static void ConvertStringsToLowercase(object obj)
        {
            if (obj == null)
                return;

            // Get all properties of the object
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Check if the property is a string
                if (property.PropertyType == typeof(string))
                {
                    // Get the current value of the property
                    var value = (string)property.GetValue(obj);

                    // Convert the value to lowercase and set it back
                    if (value != null)
                    {
                        property.SetValue(obj, value.ToLower());
                    }
                }
                // If the property is a complex object, recursively process it
                else if (property.PropertyType.IsClass && property.PropertyType != typeof(object))
                {
                    var nestedObject = property.GetValue(obj);
                    ConvertStringsToLowercase(nestedObject);
                }
            }
        }
    }
}
