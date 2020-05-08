using Calculator;
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

namespace sciCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string history = String.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            enterTextBox.Text = String.Empty;
        }

        private void Sum(object sender, RoutedEventArgs e)
        {
            try
            {
                history = enterTextBox.Text;
                enterTextBox.Text = RPNCalculator.Calculate(enterTextBox.Text).ToString();
            }
            catch (Exception)
            {
                enterTextBox.Text = "Wrong input";
            }
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonValue = ((Button)sender).Content;

            switch (buttonValue)
            {
                case "π":
                    enterTextBox.Text += "π";
                    break;
                case "γ":
                    enterTextBox.Text += "γ";
                    break;
                case "x^y":
                    enterTextBox.Text += "(x^y)";
                    break;
                case "Factorial":
                    enterTextBox.Text += "(!x)";
                    break;
                case "log":
                    enterTextBox.Text += "log(x)(y)";
                    break;
                case "ln":
                    enterTextBox.Text += "ln(x)";
                    break;
                case "sqrt":
                    enterTextBox.Text += "sqrt(x)";
                    break;
                case "|x|":
                    enterTextBox.Text += "abs(x)";
                    break;
                case "mod":
                    enterTextBox.Text += "%";
                    break;
                case "sinα=a/c":
                    enterTextBox.Text += "sin(a)(c)";
                    break;
                case "cosα=b/c":
                    enterTextBox.Text += "cos(b)(c)";
                    break;
                case "tgα=a/b":
                    enterTextBox.Text += "tg(a)(b)";
                    break;
                case "ctgα=b/a":
                    enterTextBox.Text += "ctg(b)(a)";
                    break;
                default:
                    enterTextBox.Text += buttonValue.ToString();
                    break;
            }
        }

        private void Revert(object sender, RoutedEventArgs e)
        {
            enterTextBox.Text = history;
        }
    }
}
