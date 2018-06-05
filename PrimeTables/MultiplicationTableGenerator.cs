using System.Collections.Generic;

namespace PrimeTables
{
    public class MultiplicationTableGenerator
    {
        // Return a multiplication table based on an input set
        public static string[,] GetMultiplicationTable(IList<ulong> values, out int[] columnWidths)
        {
            // Generate the values we'll use to populate the result text

            columnWidths = new int[values.Count + 1];
            string[,] results = new string[values.Count + 1, values.Count + 1];

            // Blank entry in top left
            results[0, 0] = "";
            columnWidths[0] = 0;

            // Fill column and row 0 with primes
            for (int i = 0; i < values.Count; ++i)
            {
                int columnRowIndex = i + 1;
                string resultString = values[i].ToString();
                results[0, columnRowIndex] = resultString;

                if (resultString.Length > columnWidths[0])
                {
                    columnWidths[0] = resultString.Length;
                }

                // All other columns get their headers set
                results[columnRowIndex, 0] = resultString;
                columnWidths[columnRowIndex] = resultString.Length;
            }

            for (int i = 0; i < values.Count; ++i)
            {
                for (int j = 0; j < values.Count; ++j)
                {
                    ulong valA = values[i];
                    ulong valB = values[j];

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
