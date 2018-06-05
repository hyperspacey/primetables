using System.Collections.Generic;

namespace PrimeTables
{
    public class MultiplicationTableGenerator
    {
        // Return a multiplication table based on an input set
        public static float[,] GetMultiplicationTable(IList<ulong> values, out int[] columnWidths)
        {
            // Generate the values we'll use to populate the result text

            columnWidths = new int[values.Count + 1];
            float[,] results = new float[values.Count + 1, values.Count + 1];

            // Blank entry in top left
            results[0, 0] = 0;
            columnWidths[0] = 0;

            string resultString = "";
            // Fill column and row 0 with primes
            for (int i = 0; i < values.Count; ++i)
            {
                int columnRowIndex = i + 1;
                results[0, columnRowIndex] = values[i];

                resultString = values[i].ToString();
                if (resultString.Length > columnWidths[0])
                {
                    columnWidths[0] = resultString.Length;
                }

                // All other columns get their headers set
                results[columnRowIndex, 0] = values[i];
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
                    results[rowIndex, columnIndex] = resultValue;

                    resultString = resultValue.ToString();
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
