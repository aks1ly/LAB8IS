using System;
using System.ComponentModel;
using System.Globalization;

namespace BMI_MVVM
{
    public class BmiViewModel : INotifyPropertyChanged
    {
        private readonly BmiModel model = new BmiModel();

        private string weight = "";
        private string height = "";
        private string result = "—";
        private string category = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                Calculate();
                OnPropertyChanged(nameof(Weight));
            }
        }

        public string Height
        {
            get => height;
            set
            {
                height = value;
                Calculate();
                OnPropertyChanged(nameof(Height));
            }
        }

        public string Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private void Calculate()
        {
            string weightInput = Weight.Trim().Replace(',', '.');
            string heightInput = Height.Trim().Replace(',', '.');

            bool validWeight = double.TryParse(weightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double w);

            bool validHeight = double.TryParse(heightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double h);

            if (!validWeight || !validHeight ||
                !double.IsFinite(w) || !double.IsFinite(h) ||
                w <= 0 || h < 50 || h > 250)
            {
                Result = "—";
                Category = "";
                return;
            }

            double bmi = model.CalculateBmi(w, h / 100.0);

            if (!double.IsFinite(bmi))
            {
                Result = "—";
                Category = "";
                return;
            }

            Result = bmi.ToString("F2", new CultureInfo("uk-UA"));

            if (bmi < 18.5)
                Category = "Недостатня маса тіла";
            else if (bmi < 25)
                Category = "Нормальна маса тіла";
            else if (bmi < 30)
                Category = "Надмірна маса тіла";
            else
                Category = "Ожиріння";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
