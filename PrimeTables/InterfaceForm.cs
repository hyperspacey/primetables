using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeTables
{
    public partial class InterfaceForm : Form
    {
        private static string outputPath = "output.txt";

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

        private async void CalculateOutput()
        {
            int numPrimes = 0;
            bool canCalculate = Int32.TryParse(inputText.Text, out numPrimes);
            if (canCalculate)
            {
                output.Text = "Working...";
                try
                {
                    string result = await Task.Run(async () => { return await SaveOutput(numPrimes); });
                    output.Text = result;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception, failed to generate because: " + exception.Message);
                    output.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Error, could not parse number: " + inputText.Text);
                inputText.Text = "";
            }
        }

        private async Task<string> SaveOutput(int numPrimes)
        {
            PrimeCalculation calculation = new PrimeCalculation(numPrimes);

            int[] columnWidths = GetColumnWidths(calculation.Primes);

            // Fill our output
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                string tempEntryString = "";

                for (int i = 0; i < numPrimes + 1; ++i)
                {
                    for (int j = 0; j < numPrimes + 1; ++j)
                    {
                        await writer.WriteAsync("|");

                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                tempEntryString = "";
                            }
                            else
                            {
                                tempEntryString = calculation.GetPrime(j - 1).ToString ();
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                tempEntryString = calculation.GetPrime(i - 1).ToString();
                            }
                            else
                            {
                                tempEntryString = (calculation.GetPrime(i - 1) * calculation.GetPrime(j - 1)).ToString();
                            }
                        }

                        await writer.WriteAsync(tempEntryString);
                        for (int k = tempEntryString.Length; k < columnWidths[j]; ++k)
                        {
                            await writer.WriteAsync(" ");
                        }

                        if (j == numPrimes)
                        {
                            // Cap row
                            await writer.WriteAsync("|");
                            await writer.WriteAsync(Environment.NewLine);
                        }
                    }
                }

                System.Diagnostics.Process.Start(outputPath);
                return "Success";
            }
        }

        private static int[] GetColumnWidths(IList<ulong> values)
        {
            int[] columnWidths = new int[values.Count + 1];
            columnWidths[0] = 0;

            string resultString = "";
            // Fill column and row 0 with primes
            for (int i = 0; i < values.Count; ++i)
            {
                int columnRowIndex = i + 1;

                resultString = values[i].ToString();
                if (resultString.Length > columnWidths[0])
                {
                    columnWidths[0] = resultString.Length;
                }

                // All other columns get their headers set
                columnWidths[columnRowIndex] = resultString.Length;
            }

            for (int i = 0; i < values.Count; ++i)
            {
                for (int j = 0; j < values.Count; ++j)
                {
                    ulong valA = values[i];
                    ulong valB = values[j];

                    // Possible loss of information here
                    float resultValue = valA * valB;

                    // Result indexes are off by one vs prime indexes
                    int rowIndex = i + 1;
                    int columnIndex = j + 1;

                    resultString = resultValue.ToString();
                    // Adjust our column width if need be
                    if (resultString.Length > columnWidths[columnIndex])
                    {
                        columnWidths[columnIndex] = resultString.Length;
                    }
                }
            }

            return columnWidths;
        }
    }
}
