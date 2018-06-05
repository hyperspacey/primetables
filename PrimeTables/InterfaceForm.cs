using System;
using System.IO;
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
                output.Text = SaveOutput(numPrimes);
            }
            else
            {
                MessageBox.Show("Error, could not parse number: " + inputText.Text);
                inputText.Text = "";
            }
        }

        private string SaveOutput(int numPrimes)
        {
            PrimeCalculation calculation = new PrimeCalculation(numPrimes);

            int[] columnWidths;
            float[,] resultEntries = MultiplicationTableGenerator.GetMultiplicationTable(calculation.Primes, out columnWidths);


            // Fill our output
            using (StreamWriter writer = new StreamWriter("output.txt"))
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

                        writer.Write("|");
                        writer.Write (tempEntryString);
                        for (int k = tempEntryString.Length; k < columnWidths[j]; ++k)
                        {
                            writer.Write(" ");
                        }

                        if (j == numPrimes)
                        {
                            // Cap row
                            writer.Write("|");
                            writer.Write(Environment.NewLine);
                        }
                    }
                }
                return "Success";
            }
        }
    }
}
