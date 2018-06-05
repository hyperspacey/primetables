using System;
using System.Collections.Generic;
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
            string primeResult = "";
            PrimeCalculation calculation = new PrimeCalculation(numPrimes);

            int[] columnWidths;
            string[,] resultEntries = MultiplicationTableGenerator.GetMultiplicationTable(calculation.Primes, out columnWidths);

            // Fill our output
            for (int i = 0; i < numPrimes+1; ++i)
            {
                for (int j = 0; j < numPrimes+1; ++j)
                {
                    string resultEntry = resultEntries[i, j];
                    string resultString = GetEntryString(resultEntry, columnWidths[j]);
                    primeResult += resultString;
                    if (j == numPrimes)
                    {
                        // Cap row
                        primeResult += "|" + Environment.NewLine;
                    }
                }
            }
            return primeResult;
        }

        private string GetEntryString(string content, int width)
        {
            string formatString = "{0," + width + "}";
            return "|" + string.Format(formatString,content);
        }
    }
}
