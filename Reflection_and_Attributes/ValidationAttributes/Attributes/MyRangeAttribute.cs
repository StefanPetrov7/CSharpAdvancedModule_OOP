using System;
namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int)obj;

                if (value < this.minValue || value > this.maxValue)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot validate data type");
            }
        }

        private void ValidateRange(int minVal, int maxVal)
        {
            if (minVal > maxVal)
            {
                throw new ArgumentException("Invalide range!");
            }
        }
    }
}
