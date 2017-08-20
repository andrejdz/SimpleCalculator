using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
	public partial class MainWindow : Window
    {
        private StringBuilder containerForNumbers = new StringBuilder();
        private StringBuilder containerForNumbers2 = new StringBuilder();
        private StringBuilder containerForOperators = new StringBuilder();

        public int Flag { get; set; }
        public int Counter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                containerForNumbers.Append(((Button)sender).Content.ToString());
                tbField1.Text = containerForNumbers.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnOperators_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Counter == 0)
                {
                    ++Counter;
                    containerForNumbers2.Clear();

                    if(containerForNumbers.Length == 0)
                    {
                        containerForNumbers.Append(tbField1.Text);
                    }

                    containerForNumbers2.Append(containerForNumbers.ToString());
                    containerForNumbers.Clear();
                    containerForOperators.Clear();
                }
                else
                {
                    containerForOperators.Clear();
                }
                switch(((Button)sender).Content.ToString())
                {
                    case "+":
                        containerForOperators.Append(((Button)sender).Content.ToString());
                        tbField1.Text = ((Button)sender).Content.ToString();
                        break;
                    case "-":
                        containerForOperators.Append(((Button)sender).Content.ToString());
                        tbField1.Text = ((Button)sender).Content.ToString();
                        break;
                    case "/":
                        containerForOperators.Append(((Button)sender).Content.ToString());
                        tbField1.Text = ((Button)sender).Content.ToString();
                        break;
                    case "*":
                        containerForOperators.Append(((Button)sender).Content.ToString());
                        tbField1.Text = ((Button)sender).Content.ToString();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            containerForNumbers.Clear();
            containerForNumbers2.Clear();
            Counter = 0;
            tbField1.Text = "";
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double y = 0;
            try
            {
                x = double.Parse(containerForNumbers2.ToString());
                y = double.Parse(containerForNumbers.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            containerForNumbers.Clear();
            containerForNumbers2.Clear();
            Counter = 0;
            switch(containerForOperators.ToString())
            {
                case "+":
                    tbField1.Text = $"{x + y}";
                    break;
                case "-":
                    tbField1.Text = $"{x - y}";
                    break;
                case "/":
                    tbField1.Text = $"{x / y}";
                    break;
                case "*":
                    tbField1.Text = $"{x * y}";
                    break;
            }
        }

        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbField1.Text);
            tbField1.Text = (Math.Sin(Converter(x, Flag))).ToString();
        }

        private void rbDeg_Checked(object sender, RoutedEventArgs e)
        {
            Flag = 0;
        }

        private void rbRad_Checked(object sender, RoutedEventArgs e)
        {
            Flag = 1;
        }

        private void rbGRad_Checked(object sender, RoutedEventArgs e)
        {
            Flag = 2;
        }

        private double Converter(double n, int flag)
        {
            double result = 0;
            switch(flag)
            {
                case 0:
                    result = Math.PI * n / 180.0;
                    break;
                case 1:
                    result = n;
                    break;
                case 2:
                    result = Math.PI * n / 200.0;
                    break;
            }
            return result;
        }

        private void btnCos_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbField1.Text);
            tbField1.Text = (Math.Cos(Converter(x, Flag))).ToString();
        }

        private void btnTg_Click(object sender, RoutedEventArgs e)
        {
            double x = double.Parse(tbField1.Text);
            tbField1.Text = (Math.Tan(Converter(x, Flag))).ToString();
        }
    }
}
