namespace BMI_MVC
{
    public class BmiController
    {
        public double Calculate(double weight, double height)
        {
            BmiModel model = new BmiModel(weight, height);
            return model.CalculateBmi();
        }
    }
}
