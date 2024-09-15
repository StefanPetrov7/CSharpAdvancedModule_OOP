using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribue[] attributes = property.GetCustomAttributes<MyValidationAttribue>().ToArray();

                object propertyValue = property.GetValue(obj);

                foreach (MyValidationAttribue attribute in attributes) 
                {
                    bool IsValide = attribute.IsValid(propertyValue);

                    if (!IsValide) return false;
                }
            }

            return true;
        }
    }
}
 