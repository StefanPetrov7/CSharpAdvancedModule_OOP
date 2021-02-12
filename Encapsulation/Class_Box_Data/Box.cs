using System;
using System.Text;

namespace Class_Box_Data
{
    public class Box
    {
        private const string INVALIDE_EXCEPTION_MSG = "{0} cannot be zero or negative.";

        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                ValidateSide(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                ValidateSide(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                ValidateSide(value, nameof(Height));
                height = value;
            }
        }

        private void ValidateSide(double value, string param)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(INVALIDE_EXCEPTION_MSG, param));
            }
        }

        // Surface Area = 2lw + 2lh + 2wh
        public double CalculateSurfaceArea() => (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);

        //  Lateral Surface Area = 2lh + 2wh
        public double CalculateLateralSurfaceArea() => (2 * Length * Height) + (2 * Width * Height);

        // Volume = lwh
        public double CalculateVolume() => Length * Width * Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
