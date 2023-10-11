using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] propertyInfos = type
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in propertyInfos)
            {
                IEnumerable<MyValidationAttribute> attributes = property.GetCustomAttributes(true)
                    .Where(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj))) return false;
                }
            }
            return true;
        }
    }
}
