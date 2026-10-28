using System;
using System.Globalization;

namespace BMI_MVP
{
    public class BmiPresenter
    {
        private readonly IBmiView view;
        private readonly IBmiModel model;

        public BmiPresenter(IBmiView view, IBmiModel model)
        {
            this.view = view;
            this.model = model;
        }

        public void Calculate()
        {
            string weightInput = view.WeightInput.Trim().Replace(',', '.');
            string heightInput = view.HeightInput.Trim().Replace(',', '.');

            bool validWeight = double.TryParse(weightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double weight);

            bool validHeight = double.TryParse(heightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double height);

            if (!validWeight || !validHeight ||
                !double.IsFinite(weight) || !double.IsFinite(height) ||
                weight <= 0 || height <= 0)
            {
                view.ShowError("Введіть коректні додатні числа!");
                return;
            }

            if (height < 50 || height > 250)
            {
                view.ShowError("Введіть зріст від 50 до 250 см!");
                return;
            }

            double bmi = model.CalculateBmi(weight, height / 100.0);

            if (!double.IsFinite(bmi))
            {
                view.ShowError("Неможливо обчислити ІМТ.");
                return;
            }

            string category;

            if (bmi < 18.5)
                category = "Недостатня маса тіла";
            else if (bmi < 25)
                category = "Нормальна маса тіла";
            else if (bmi < 30)
                category = "Надмірна маса тіла";
            else
                category = "Ожиріння";

            view.ShowResult(bmi, category);
        }
    }
}
