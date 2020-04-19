using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCalc
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[2];
        public Form1()
        {
            InitializeComponent();
        }

        private void getValue()
        {
            numbers[0] = int.Parse(insertTextBox.Text);
            numbers[1] = int.Parse(secondInsertTextBox.Text);
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            getValue();
            int result = numbers[0] + numbers[1];
            resultLabel.Text = result.ToString();
        }

        private void subtractionButton_Click(object sender, EventArgs e)
        {
            getValue();
            int result = numbers[0] - numbers[1];
            resultLabel.Text = result.ToString();
        }
    }
}
