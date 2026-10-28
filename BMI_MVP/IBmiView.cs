namespace BMI_MVP
{
    public interface IBmiView
    {
        string WeightInput { get; }
        string HeightInput { get; }

        void ShowResult(double bmi, string category);
        void ShowError(string message);
    }
}
