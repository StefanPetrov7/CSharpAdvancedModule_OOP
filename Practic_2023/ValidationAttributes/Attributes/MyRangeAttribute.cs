using System;
namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int min, int max)
        {
            this.MinValue = min;
            this.MaxValue = max;
        }

        public int MinValue { get; private set; }

        public int MaxValue { get; private set; }

        public override bool IsValid(object obj)
        {
            if (obj is Int32 == false)
            {
                return false;
            }

            int value = (int)obj;

            if (value >= this.MinValue && value <= this.MaxValue)
            {
                return true;
            }

            return false;
        }
    }
}