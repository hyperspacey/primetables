using System;
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

            int[] columnWidths;
            float[,] resultEntries = MultiplicationTableGenerator.GetMultiplicationTable(calculation.Primes, out columnWidths);


            // Fill our output
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                string tempEntryString = "";
                for (int i = 0; i < numPrimes + 1; ++i)
                {
                    for (int j = 0; j < numPrimes + 1; ++j)
                    {
                        if (i == 0 && j == 0)
                        {
                            tempEntryString = "";
                        }
                        else
                        {
                            tempEntryString = resultEntries[i, j].ToString();
                        }

                        await writer.WriteAsync("|");
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
    }
}
