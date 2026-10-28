using System;
using System.Globalization;
using System.Windows.Forms;

namespace BMI_MVP
{
    public partial class Form1 : Form, IBmiView
    {
        private readonly BmiPresenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new BmiPresenter(this, new BmiModel());

            button1.Click -= button1_Click;
            button1.Click += button1_Click;

            textBox1.TextChanged -= textBox1_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;

            textBox2.TextChanged -= textBox2_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        public string WeightInput => textBox1.Text;
        public string HeightInput => textBox2.Text;

        public void ShowResult(double bmi, string category)
        {
            label5.Text = bmi.ToString("F2", new CultureInfo("uk-UA"));
            label6.Text = category;
        }

        public void ShowError(string message)
        {
            label5.Text = "—";
            label6.Text = "";

            MessageBox.Show(message, "Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            presenter.Calculate();
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            ClearResult();
        }

        private void textBox2_TextChanged(object? sender, EventArgs e)
        {
            ClearResult();
        }

        private void ClearResult()
        {
            label5.Text = "—";
            label6.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
