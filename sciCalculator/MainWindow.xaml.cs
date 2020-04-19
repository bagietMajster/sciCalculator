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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSimpleCharacterClick(object sender, RoutedEventArgs e)
        {
            var buttonValue = ((Button)sender).Content;
            enterTextBox.Text += buttonValue.ToString();
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            enterTextBox.Text = String.Empty;
        }

        private void Sum(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonValue = ((Button)sender).Content;

            switch (buttonValue)
            {
                case "π":
                    enterTextBox.Text += "π";
                    return;
                case "x^y":
                    enterTextBox.Text += "(x^y)";
                    return;
                case "Factorial":
                    enterTextBox.Text += "(!x)";
                    return;
                case "log":
                    enterTextBox.Text += "log(x)(y)";
                    return;
                case "ln":
                    enterTextBox.Text += "ln(x)";
                    return;
                case "e":
                    enterTextBox.Text += "e";//????
                    return;
                default:
                    break;
            }

            enterTextBox.Text += buttonValue.ToString();
        }
    }
}
