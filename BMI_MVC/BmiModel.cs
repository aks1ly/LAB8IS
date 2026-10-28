using System;

namespace BMI_MVC
{
    public class BmiModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }

        public BmiModel(double weight, double height)
        {
            Weight = weight;
            Height = height;
        }

        public double CalculateBmi()
        {
            if (Weight <= 0 || Height <= 0)
            {
                throw new ArgumentException("Маса та зріст повинні бути більшими за нуль.");
            }

            return Weight / (Height * Height);
        }
    }
}
