using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LPR381_CPLEX.DataLayer;
using System.Data;

namespace LPR381_CPLEX.BusinessLogic
{
    class Knapsack
    {
        public void SolveKnapsackProblem(string[] lines, string outputFilePath)
        {
            // Parse the objective function (item values)
            int[] values = lines[0].Split(' ').Skip(1).Select(int.Parse).ToArray();

            // Parse the constraints (item weights and knapsack capacity)
            string[] constraintParts = lines[1].Split(' ');
            int[] weights = constraintParts.Take(values.Length).Select(int.Parse).ToArray();
            int capacity = int.Parse(constraintParts.Last().Trim());

            // Since the third line just confirms all variables are binary, we can skip processing it.

            // Solve the knapsack problem
            int[] selectedItems = SolveKnapsack(weights, values, capacity);

            // Prepare results
            List<string> results = new List<string>();
            results.Add($"Selected item indices: {string.Join(", ", selectedItems)}");
            results.Add($"Total value: {selectedItems.Sum(i => values[i])}");
            results.Add($"Total weight: {selectedItems.Sum(i => weights[i])}");

            // Write results to output file
            FileHandler fileHandler = new FileHandler();
            fileHandler.WriteFile(outputFilePath, results.ToArray());
        }

        private int[] SolveKnapsack(int[] weights, int[] values, int capacity)
        {
            int n = values.Length;
            int[,] dp = new int[n + 1, capacity + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (weights[i - 1] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            List<int> selectedItems = new List<int>();
            int remainingCapacity = capacity;

            for (int i = n; i > 0 && remainingCapacity > 0; i--)
            {
                if (dp[i, remainingCapacity] != dp[i - 1, remainingCapacity])
                {
                    selectedItems.Add(i - 1);
                    remainingCapacity -= weights[i - 1];
                }
            }

            selectedItems.Reverse();
            return selectedItems.ToArray();
        }
        public DataTable GetLinearProgramRepresentation(string[] lines)
        {
            DataTable dataTable = new DataTable();

            // Parse data
            int[] values = lines[0].Split(' ').Skip(1).Select(int.Parse).ToArray();
            string[] constraintParts = lines[1].Split(' ');
            int[] weights = constraintParts.Take(values.Length).Select(int.Parse).ToArray();
            int capacity = int.Parse(constraintParts.Last().Trim());

            // Define columns
            dataTable.Columns.Add("", typeof(string)); // First column for row types (max, constraint, etc.)
            for (int i = 0; i < values.Length; i++)
            {
                dataTable.Columns.Add("x" + (i + 1), typeof(string)); // Columns x1, x2, ..., xn
            }
            dataTable.Columns.Add("rhs", typeof(string)); // Column for RHS

            // Objective function row
            DataRow objectiveRow = dataTable.NewRow();
            objectiveRow[0] = "max";
            for (int i = 0; i < values.Length; i++)
            {
                objectiveRow[i + 1] = "+" + values[i];
            }
            dataTable.Rows.Add(objectiveRow);

            // Constraints row
            DataRow constraintRow = dataTable.NewRow();
            constraintRow[0] = ""; // No label for the constraints row
            for (int i = 0; i < weights.Length; i++)
            {
                constraintRow[i + 1] = "+" + weights[i];
            }
            constraintRow["rhs"] = "<= " + capacity;
            dataTable.Rows.Add(constraintRow);

            // Binary variables row
            DataRow binaryRow = dataTable.NewRow();
            binaryRow[0] = "bin";
            for (int i = 0; i < values.Length; i++)
            {
                binaryRow[i + 1] = "bin";
            }
            dataTable.Rows.Add(binaryRow);

            return dataTable;
        }

    }
}
