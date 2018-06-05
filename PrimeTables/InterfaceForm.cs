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
            string[,] resultEntries = GetResultEntries(calculation, out columnWidths);

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

        private string[,] GetResultEntries(PrimeCalculation calculation, out int[] columnWidths)
        {
            // Generate the values we'll use to populate the result text

            columnWidths = new int[calculation.PrimeCount+1];
            string[,] results = new string[calculation.PrimeCount + 1, calculation.PrimeCount + 1];

            // Blank entry in top left
            results[0, 0] = "";
            columnWidths[0] = 0;

            // Fill column and row 0 with primes
            for (int i = 0; i < calculation.PrimeCount; ++i)
            {
                int columnRowIndex = i + 1;
                string resultString = calculation.GetPrime(i).ToString();
                results[0, columnRowIndex] = resultString;

                if (resultString.Length > columnWidths[0])
                {
                    columnWidths[0] = resultString.Length;
                }

                // All other columns get their headers set
                results[columnRowIndex, 0] = resultString;
                columnWidths[columnRowIndex] = resultString.Length;
            }

            for (int i = 0; i < calculation.PrimeCount; ++i)
            {
                for (int j = 0; j < calculation.PrimeCount; ++j)
                {
                    ulong valA = calculation.GetPrime(i);
                    ulong valB = calculation.GetPrime(j);

                    // Check if we can represent this as a ulong or not...
                    double resultValue = valA * valB;
                    string resultString = "";

                    resultString = resultValue.ToString();

                    // Result indexes are off by one vs prime indexes
                    int rowIndex = i + 1;
                    int columnIndex = j + 1;
                    results[rowIndex, columnIndex] = resultString;

                    // Adjust our column width if need be
                    if (resultString.Length > columnWidths[columnIndex])
                    {
                        columnWidths[columnIndex] = resultString.Length;
                    }
                }
            }
            return results;
        }
    }
}
