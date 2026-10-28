using System;

namespace BMI_MVVM
{
    public class BmiModel
    {
        public double CalculateBmi(double weight, double height)
        {
            if (weight <= 0 || height <= 0)
            {
                throw new ArgumentException("Маса та зріст повинні бути більшими за нуль.");
            }

            return weight / (height * height);
        }
    }
}
