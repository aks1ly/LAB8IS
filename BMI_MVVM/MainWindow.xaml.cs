using System.Windows;

namespace BMI_MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BmiViewModel();
        }
    }
}
