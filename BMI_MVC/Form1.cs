using System;
using System.Globalization;
using System.Windows.Forms;

namespace BMI_MVC
{
    public partial class Form1 : Form
    {
        private readonly BmiController controller = new BmiController();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string weightInput = textBox1.Text.Replace(',', '.');
            string heightInput = textBox2.Text.Replace(',', '.');

            bool validWeight = double.TryParse(weightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double weight);

            bool validHeight = double.TryParse(heightInput,
                NumberStyles.Float, CultureInfo.InvariantCulture, out double height);

            if (!validWeight || !validHeight ||
                !double.IsFinite(weight) || !double.IsFinite(height) ||
                weight <= 0 || height <= 0)
            {
                MessageBox.Show("Введіть коректні додатні числа!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (height < 50 || height > 250)
            {
                MessageBox.Show("Введіть зріст від 50 до 250 см!",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double bmi = controller.Calculate(weight, height / 100.0);

            if (!double.IsFinite(bmi))
            {
                MessageBox.Show("Неможливо обчислити ІМТ.",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            label5.Text = bmi.ToString("F2", new CultureInfo("uk-UA"));

            if (bmi < 18.5)
                label6.Text = "Недостатня маса тіла";
            else if (bmi < 25)
                label6.Text = "Нормальна маса тіла";
            else if (bmi < 30)
                label6.Text = "Надмірна маса тіла";
            else
                label6.Text = "Ожиріння";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "—";
            label6.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = "—";
            label6.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
