using System;
using System.Windows.Forms;

namespace PrimeTables
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CalculateOutput();
        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateOutput();
            }
        }

        private void CalculateOutput()
        {
            int numPrimes = 0;
            bool canCalculate = Int32.TryParse(inputText.Text, out numPrimes);
            if (canCalculate)
            {
                output.Text = GenerateOutput(numPrimes);
            }
            else
            {
                MessageBox.Show("Error, could not parse number: " + inputText.Text);
                inputText.Text = "";
            }
        }

        private string GenerateOutput(int numPrimes)
        {
            string primeResult = "Result:";
            PrimeCalculation calculation = new PrimeCalculation(numPrimes);

            for (int i = 0; i < numPrimes; ++i)
            {
                try
                {
                    primeResult += calculation.GetPrime(i) + " | ";
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error, could not get prime: " + e.Message);
                    output.Text = "";
                }
            }
            return primeResult;
        }
    }
}
