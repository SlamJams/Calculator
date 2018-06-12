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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        OpterationSelected selectedOperation;

        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperation)
                {
                    case OpterationSelected.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case OpterationSelected.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case OpterationSelected.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case OpterationSelected.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = result.ToString();
            }
            
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButton_Click(Object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == multiButton)
                selectedOperation = OpterationSelected.Multiplication;
            if (sender == divideButton)
                selectedOperation = OpterationSelected.Division;
            if (sender == subButton)
                selectedOperation = OpterationSelected.Subtraction;
            if (sender == addButton)
                selectedOperation = OpterationSelected.Addition;


        }

        private void decButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
            
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == _0Button)
                selectedValue = 0;
            if (sender == _1Button)
                selectedValue = 1;
            if (sender == _2Button)
                selectedValue = 2;
            if (sender == _3Button)
                selectedValue = 3;
            if (sender == _4Button)
                selectedValue = 4;
            if (sender == _5Button)
                selectedValue = 5;
            if (sender == _6Button)
                selectedValue = 6;
            if (sender == _7Button)
                selectedValue = 7;
            if (sender == _8Button)
                selectedValue = 8;
            if (sender == _9Button)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum OpterationSelected
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double Division(double number1, double number2)
        {
            return number1 / number2;
        }
    }
}
