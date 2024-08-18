using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILOG.Concert;
using ILOG.CPLEX;

namespace LPR381_CPLEX.BusinessLogic
{
    class ShadowPricing
    {
        public string CalculateShadowPricing(string[] lpLines)
        {
            string result = "Shadow Prices:\n";

            try
            {
                Cplex cplex = new Cplex();

                // Objective function and variables
                INumVar[] vars = cplex.NumVarArray(lpLines[0].Split(' ').Length - 1, 0.0, double.MaxValue);
                ILinearNumExpr objective = cplex.LinearNumExpr();

                string[] objectiveCoefficients = lpLines[0].Split(' ');

                for (int i = 1; i < objectiveCoefficients.Length; i++)
                {
                    objective.AddTerm(Convert.ToDouble(objectiveCoefficients[i]), vars[i - 1]);
                }

                cplex.AddMaximize(objective);

                // Constraints
                IRange[] constraints = new IRange[lpLines.Length - 2];

                for (int i = 1; i < lpLines.Length - 1; i++)
                {
                    string[] constraintParts = lpLines[i].Split(' ');
                    ILinearNumExpr constraint = cplex.LinearNumExpr();

                    for (int j = 0; j < vars.Length; j++)
                    {
                        constraint.AddTerm(Convert.ToDouble(constraintParts[j]), vars[j]);
                    }

                    double rhs = Convert.ToDouble(constraintParts[constraintParts.Length - 1]);
                    constraints[i - 1] = cplex.AddLe(constraint, rhs);
                }

                // Solve the model
                if (cplex.Solve())
                {
                    // Extract and display shadow prices (dual values)
                    for (int i = 0; i < constraints.Length; i++)
                    {
                        double shadowPrice = cplex.GetDual(constraints[i]);
                        result += $"Constraint {i + 1}: Shadow Price = {shadowPrice}\n";
                    }
                }
                else
                {
                    result = "Unable to solve the LP problem.";
                }

                cplex.End();
            }
            catch (ILOG.Concert.Exception ex)
            {
                result = "Error: " + ex.Message;
            }

            return result;
        }
    }
}
