using System;
namespace ValidationAttributes.Attributes
{
    public class MyRequieredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            string value = obj.ToString();

            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            return true;
        }
    }
}