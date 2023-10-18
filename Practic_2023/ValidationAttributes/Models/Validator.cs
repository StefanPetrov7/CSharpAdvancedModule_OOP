using System;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var prop in properties)
            {
                var atributes = prop.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in atributes)
                {
                    if (attribute.IsValid(prop.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}

