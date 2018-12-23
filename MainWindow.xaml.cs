using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public char Operator { get; set; }
        public bool ResultShown { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("1");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("3");
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("0");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("8");
        }



        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            CheckIfInputIsFull("9");
        }

        private void ButtonAC_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Background = Brushes.White;
            TextBox.Text = "";
            ResultShown = false;
        }

        private void ButtonWeird_Click(object sender, RoutedEventArgs e)
        {
            PrintErrorMessage();
        }

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            RemoveOperatorFromCalculation();
            double result = 0.0;
            try
            {
                result = CalculatePercent();
                CheckIfResultIsTooLong(result.ToString());
            }
            catch
            {
                PrintErrorMessage();
            }
            ResultShown = true;
        }

        private double CalculatePercent()
        {
            var number1ToDouble = double.Parse(Number1);
            var number2ToDouble = double.Parse(Number2);
            double result = 0.0;
            switch (Operator)
            {
                case '*':
                    result = number1ToDouble * (number2ToDouble / 100);
                    break;
                case '+':
                    result = number1ToDouble + (number2ToDouble / 100) * number1ToDouble;
                    break;
                case '-':
                    result = number1ToDouble - (number2ToDouble / 100) * number1ToDouble;
                    break;
                default:
                    throw new Exception();
            }

            return result;
        }

        private void RemoveOperatorFromCalculation()
        {
            try
            {
                var previousNumbersPlusOperatorLength = Number1.Length + 3;
                Number2 = TextBox.Text.Remove(0, previousNumbersPlusOperatorLength);
            }
            catch
            {
                PrintErrorMessage();
            }
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            Number1 = TextBox.Text;
            Operator = '/';
            TextBox.Text += " / ";

        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            Number1 = TextBox.Text;
            Operator = '*';
            TextBox.Text += " * ";
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            Number1 = TextBox.Text;
            Operator = '-';
            TextBox.Text += " - ";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearIfResultShown();
            Number1 = TextBox.Text;
            Operator = '+';
            TextBox.Text += " + ";
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            RemoveOperatorFromCalculation();
            double result = 0.0;
            try
            {
                result = CalculateResult();
                CheckIfResultIsTooLong(result.ToString());
            }
            catch
            {
                PrintErrorMessage();
            }
            ResultShown = true;
        }

        private double CalculateResult()
        {
            double result = 0.0;
            switch (Operator)
            {
                case '*':
                    result = double.Parse(Number1) * double.Parse(Number2);
                    break;
                case '+':
                    result = double.Parse(Number1) + double.Parse(Number2);
                    break;
                case '-':
                    result = double.Parse(Number1) - double.Parse(Number2);
                    break;
                case '/':
                    result = double.Parse(Number1) / double.Parse(Number2);
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
        private void CheckIfInputIsFull(string input)
        {
            if (TextBox.Text.Length > 12)
            {
                PrintErrorMessage();
            }
            else
            {
                TextBox.Text += input;
            }
        }
        private void CheckIfResultIsTooLong(string result)
        {
            if (result.Length > 12)
            {
                TextBox.Text = result.Substring(0, 13);
            }
            else
            {
                TextBox.Text = result;
            }
        }
        private void ClearIfResultShown()
        {
            if (TextBox.Text.Length > 0 && ResultShown)
            {
                TextBox.Background = Brushes.White;
                TextBox.Text = "";
                ResultShown = false;
            }
        }
        private void PrintErrorMessage()
        {
            TextBox.Text = "ERROR";
            TextBox.Background = Brushes.LightPink;
            ResultShown = true;
        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBox.Text.Contains(","))
            {
                TextBox.Text += ",";
            }
        }
    }
}
