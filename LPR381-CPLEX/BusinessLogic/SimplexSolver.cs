using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ILOG.Concert;
using ILOG.CPLEX;
using LPR381_CPLEX.DataLayer;
using MetroSet_UI.Controls;

namespace LPR381_CPLEX.BusinessLogic
{
    class SimplexSolver
    {
        public void SolveLinearProblem(string[] lines, string outputFilePath, DataGridView dataGridViewCanonicalForm, MetroSetPanel metroSetPanel)
        {
            Cplex cplex = new Cplex();
            List<string> iterations = new List<string>();

            try
            {
                // Convert to Canonical Form
                List<string[]> canonicalFormData = ConvertToCanonicalForm(lines);
                DisplayCanonicalForm(dataGridViewCanonicalForm, canonicalFormData);

                iterations.Add("Canonical Form:");
                iterations.AddRange(canonicalFormData.Select(row => string.Join(" ", row)));

                // Determine if it's a maximization or minimization problem
                bool isMaximization = lines[0].StartsWith("max");

                // Parse objective function
                List<INumVar> decisionVars = new List<INumVar>();
                ILinearNumExpr objective = cplex.LinearNumExpr();
                string[] objectiveCoefficients = lines[0].Split(' ');

                for (int i = 1; i < objectiveCoefficients.Length; i++)
                {
                    double coeff = double.Parse(objectiveCoefficients[i]);
                    var varType = lines[lines.Length - 1].Contains("bin") ? NumVarType.Bool : NumVarType.Float;
                    INumVar var = cplex.NumVar(0, Double.MaxValue, varType);
                    decisionVars.Add(var);
                    objective.AddTerm(coeff, var);
                }

                // Set objective function
                if (isMaximization)
                    cplex.AddMaximize(objective);
                else
                    cplex.AddMinimize(objective);

                // Parse constraints
                for (int i = 1; i < lines.Length - 1; i++)
                {
                    string[] constraintParts = lines[i].Split(' ');
                    ILinearNumExpr constraintExpr = cplex.LinearNumExpr();

                    for (int j = 0; j < decisionVars.Count; j++)
                    {
                        double coeff = double.Parse(constraintParts[j]);
                        constraintExpr.AddTerm(coeff, decisionVars[j]);
                    }

                    // Determine the type of constraint
                    string inequalityType = constraintParts[constraintParts.Length - 2];
                    double rhsValue = double.Parse(constraintParts[constraintParts.Length - 1]);

                    if (inequalityType == "<=")
                        cplex.AddLe(constraintExpr, rhsValue);
                    else if (inequalityType == ">=")
                        cplex.AddGe(constraintExpr, rhsValue);
                    else if (inequalityType == "=")
                        cplex.AddEq(constraintExpr, rhsValue);
                }

                // Solve the problem and store tableau iterations
                if (cplex.Solve())
                {
                    iterations.Add($"Objective Value: {cplex.ObjValue}");

                    for (int i = 0; i < decisionVars.Count; i++)
                    {
                        iterations.Add($"Variable {i + 1}: {cplex.GetValue(decisionVars[i])}");
                    }

                    // Write iterations and final results to output
                    FileHandler fileHandler = new FileHandler();
                    fileHandler.WriteFile(outputFilePath, iterations.ToArray());

                    // Display iterations in the MetroSetPanel
                    DisplayIterationsInPanel(metroSetPanel, iterations);
                }
                else
                {
                    // Handle infeasible or unbounded cases
                    FileHandler fileHandler = new FileHandler();
                    fileHandler.WriteFile(outputFilePath, new string[] { "No feasible solution found." });
                }
            }
            finally
            {
                cplex.End();
            }
        }

        private void DisplayIterationsInPanel(MetroSetPanel metroSetPanel, List<string> iterations)
        {
            metroSetPanel.Controls.Clear(); // Clear previous content

            int yPosition = 10; // Start position for the first label

            foreach (string iteration in iterations)
            {
                Label label = new Label
                {
                    Text = iteration,
                    Location = new System.Drawing.Point(10, yPosition),
                    AutoSize = true,
                    ForeColor = System.Drawing.Color.White, // Adjust color as needed
                    BackColor = System.Drawing.Color.Black // Adjust background color as needed
                };

                metroSetPanel.Controls.Add(label);
                yPosition += label.Height + 10; // Move to the next position
            }
        }
        public List<string[]> ConvertToCanonicalForm(string[] lines)
        {
            List<string[]> canonicalFormData = new List<string[]>();
            bool isMaximization = lines[0].StartsWith("max");

            // Convert objective function to canonical form
            string[] objectiveParts = lines[0].Split(' ');
            List<string> objectiveCanonical = new List<string> { isMaximization ? "max" : "min" };

            for (int i = 1; i < objectiveParts.Length; i++)
            {
                objectiveCanonical.Add(objectiveParts[i] + "x" + i);
            }
            canonicalFormData.Add(objectiveCanonical.ToArray());

            // Convert constraints to canonical form
            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] constraintParts = lines[i].Split(' ');
                List<string> constraintCanonical = new List<string>();

                for (int j = 0; j < constraintParts.Length - 2; j++)
                {
                    constraintCanonical.Add(constraintParts[j] + "x" + (j + 1));
                }

                string inequalityType = constraintParts[constraintParts.Length - 2];
                double rhsValue = double.Parse(constraintParts[constraintParts.Length - 1]);

                if (inequalityType == "<=")
                    constraintCanonical.Add("+ s" + i + " = " + rhsValue);
                else if (inequalityType == ">=")
                    constraintCanonical.Add("- s" + i + " = " + rhsValue);
                else
                    constraintCanonical.Add("= " + rhsValue);

                canonicalFormData.Add(constraintCanonical.ToArray());
            }

            // Add variable types if present
            canonicalFormData.Add(new[] { lines[lines.Length - 1] });

            return canonicalFormData;
        }

        public void DisplayCanonicalForm(DataGridView dataGridView, List<string[]> canonicalFormData)
        {
            // Temporarily unbind any data source
            dataGridView.DataSource = null;

            // Clear columns and rows
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            // Determine the maximum number of columns needed
            int maxColumns = canonicalFormData.Max(row => row.Length);

            // Create columns
            for (int i = 0; i < maxColumns; i++)
            {
                dataGridView.Columns.Add($"Column{i}", $"Column {i + 1}");
            }

            // Add rows
            foreach (var row in canonicalFormData)
            {
                dataGridView.Rows.Add(row);
            }

            // Adjust column widths
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
