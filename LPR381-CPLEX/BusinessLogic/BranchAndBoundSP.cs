using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILOG.Concert;
using ILOG.CPLEX;
using LPR381_CPLEX.DataLayer;

namespace LPR381_CPLEX.BusinessLogic
{
    class BranchAndBoundSP
    {
        public void SolveMILPProblem(string[] lines, string outputFilePath)
        {
            Cplex cplex = new Cplex();

            try
            {
                // Determine if it's a maximization or minimization problem
                bool isMaximization = lines[0].StartsWith("max");

                // Parse objective function
                List<INumVar> decisionVars = new List<INumVar>();
                ILinearNumExpr objective = cplex.LinearNumExpr();
                string[] objectiveCoefficients = lines[0].Split(' ');

                for (int i = 1; i < objectiveCoefficients.Length; i++)
                {
                    double coeff = double.Parse(objectiveCoefficients[i]);
                    INumVar var = cplex.BoolVar();  // Initialize as binary variable for branch and bound
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

                // Solve the problem using branch and bound
                if (cplex.Solve())
                {
                    List<string> results = new List<string>();
                    results.Add($"Objective Value: {cplex.ObjValue}");

                    for (int i = 0; i < decisionVars.Count; i++)
                    {
                        results.Add($"Variable {i + 1}: {cplex.GetValue(decisionVars[i])}");
                    }

                    // Write results to output file
                    FileHandler fileHandler = new FileHandler();
                    fileHandler.WriteFile(outputFilePath, results.ToArray());
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
        public DataTable GetLinearProgramRepresentation(string[] lines)
        {
            DataTable dt = new DataTable();

            // Determine the number of variables and constraints
            int numVariables = lines[0].Split(' ').Length - 1;
            int numConstraints = lines.Length - 2; // Exclude the objective function and binary variable rows

            // Add columns for the DataTable
            dt.Columns.Add("Type"); // Objective, Constraints, and Binary Variables
            for (int i = 0; i < numVariables; i++)
            {
                dt.Columns.Add($"x{i + 1}");
            }

            // Add columns for slack variables
            for (int i = 0; i < numConstraints; i++)
            {
                dt.Columns.Add($"s{i + 1}");
            }
            dt.Columns.Add("rhs"); // Right-hand side of constraints

            // Add objective function row
            DataRow objectiveRow = dt.NewRow();
            objectiveRow[0] = lines[0].StartsWith("max") ? "max" : "min";
            string[] objectiveParts = lines[0].Split(' ');

            for (int i = 1; i <= numVariables; i++)
            {
                objectiveRow[i] = objectiveParts[i];
            }

            // Fill slack variable and rhs columns with empty strings
            for (int i = numVariables + 1; i < dt.Columns.Count - 1; i++)
            {
                objectiveRow[i] = string.Empty;
            }
            objectiveRow[dt.Columns.Count - 1] = string.Empty; // rhs column

            dt.Rows.Add(objectiveRow);

            // Add constraints rows
            for (int i = 1; i < lines.Length - 1; i++)
            {
                DataRow constraintRow = dt.NewRow();
                string[] constraintParts = lines[i].Split(' ');

                // Add coefficients for variables
                for (int j = 0; j < numVariables; j++)
                {
                    constraintRow[j + 1] = constraintParts[j];
                }

                // Add slack variable coefficients
                int slackIndex = i - 1; // Index of slack variable for the current constraint
                constraintRow[numVariables + slackIndex + 1] = "+1";

                // Add inequality sign and RHS in the last column
                string inequalityType = constraintParts[numVariables];
                double rhsValue = double.Parse(constraintParts[numVariables + 1]);
                constraintRow[dt.Columns.Count - 1] = $"{inequalityType} {rhsValue}";

                dt.Rows.Add(constraintRow);
            }

            // Add binary variable row
            DataRow binaryRow = dt.NewRow();
            binaryRow[0] = "bin";
            for (int i = 1; i <= numVariables; i++)
            {
                binaryRow[i] = "bin";
            }
            // Fill slack variable and rhs columns with empty strings
            for (int i = numVariables + 1; i < dt.Columns.Count - 1; i++)
            {
                binaryRow[i] = string.Empty;
            }
            binaryRow[dt.Columns.Count - 1] = string.Empty; // rhs column

            dt.Rows.Add(binaryRow);

            return dt;
        }
    }
}
