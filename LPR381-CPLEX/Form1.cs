using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPR381_CPLEX.DataLayer;
using LPR381_CPLEX.BusinessLogic;
using System.IO;

namespace LPR381_CPLEX
{
    public partial class Form1 : Form
    {
        private string inputFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files|*.txt",
                Title = "Select Input File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);

                // Create an instance of SimplexSolver
                SimplexSolver solver = new SimplexSolver();

                // Solve the problem and display canonical form and iterations
                solver.SolveLinearProblem(lines, "output.txt", dataGridViewCanonicalForm, metroSetPanel1);
            }
            MessageBox.Show("Simplex solution is on output text file under debug");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FileHandler fileHandler = new FileHandler();
                string[] lines = fileHandler.ReadFile(filePath);

                Knapsack knapsackSolver = new Knapsack();
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "knapsack_output.txt");
                knapsackSolver.SolveKnapsackProblem(lines, outputFilePath);

                MessageBox.Show("Knapsack solution saved to " + outputFilePath);

                // Clear the DataGridView before displaying new data
                dataGridViewCanonicalForm.Rows.Clear();
                dataGridViewCanonicalForm.Columns.Clear();

                // Get the results as a DataTable
                DataTable knapsackResults = knapsackSolver.GetLinearProgramRepresentation(lines);

                // Assuming dataGridViewKnapsack is your DataGridView
                dataGridViewCanonicalForm.DataSource = knapsackResults;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FileHandler fileHandler = new FileHandler();
                string[] lines = fileHandler.ReadFile(filePath);

                BranchAndBoundSP solver = new BranchAndBoundSP();
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "branch_and_bound_output.txt");
                solver.SolveMILPProblem(lines, outputFilePath);

                MessageBox.Show("MILP solution saved to " + outputFilePath);

                dataGridViewCanonicalForm.DataSource = null; // Unbind the DataGridView from any existing data source

                // Clear the DataGridView before displaying new data
                dataGridViewCanonicalForm.Rows.Clear();
                dataGridViewCanonicalForm.Columns.Clear();

                // Get the results as a DataTable
                DataTable branchAndBoundResults = solver.GetLinearProgramRepresentation(lines);

                // Display the branch and bound results in the DataGridView
                dataGridViewCanonicalForm.DataSource = branchAndBoundResults;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FileHandler fileHandler = new FileHandler();
                string[] lines = fileHandler.ReadFile(filePath);

                CuttingPlane solver = new CuttingPlane();
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "cutting_plane_output.txt");
                solver.SolveIntegerProblem(lines, outputFilePath);

                MessageBox.Show("Integer solution saved to " + outputFilePath);

                // Clear the DataGridView before displaying new data
                dataGridViewCanonicalForm.DataSource = null;

                // Get the results as a DataTable
                DataTable cuttingPlaneResults = solver.GetLinearProgramRepresentation(lines);

                // Display the cutting plane results in the DataGridView
                dataGridViewCanonicalForm.DataSource = cuttingPlaneResults;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(inputFilePath))
            {
                MessageBox.Show("Please upload a file first.");
                return;
            }

            string newConstraint = textBoxConstraintInput.Text.Trim();
            if (string.IsNullOrEmpty(newConstraint))
            {
                MessageBox.Show("Please enter a constraint.");
                return;
            }

            try
            {
                // Read all lines from the input file
                var lines = File.ReadAllLines(inputFilePath).ToList();

                // Determine the position of the sign restriction line
                int signRestrictionIndex = lines.FindIndex(line => line.Contains("bin"));

                // If there is no sign restriction line, add it at the end
                if (signRestrictionIndex == -1)
                {
                    signRestrictionIndex = lines.Count;
                    lines.Add("bin");
                }

                // Insert the new constraint before the sign restriction line
                lines.Insert(signRestrictionIndex, newConstraint);

                // Write the updated lines back to the file
                File.WriteAllLines(inputFilePath, lines);

                // Refresh DataGridView to show updated canonical form
                SimplexSolver solver = new SimplexSolver();
                List<string[]> canonicalFormData = solver.ConvertToCanonicalForm(lines.ToArray());
                solver.DisplayCanonicalForm(dataGridViewCanonicalForm, canonicalFormData);

                MessageBox.Show("Constraint added successfully and canonical form updated.");
            }
            catch (ExecutionEngineException ex)
            {
                MessageBox.Show($"An error occurred while adding the constraint: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                inputFilePath = openFileDialog.FileName;
                FileHandler fileHandler = new FileHandler();
                string[] lines = fileHandler.ReadFile(inputFilePath);

                // Display canonical form
                SimplexSolver solver = new SimplexSolver();
                List<string[]> canonicalFormData = solver.ConvertToCanonicalForm(lines);
                solver.DisplayCanonicalForm(dataGridViewCanonicalForm, canonicalFormData);

                MessageBox.Show("File loaded and canonical form displayed.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Title = "Select a Linear Programming File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                FileHandler fileHandler = new FileHandler();
                string[] lines = fileHandler.ReadFile(filePath);

                DualityAnalysis duality = new DualityAnalysis();

                // Process the LP problem and display the duality analysis
                string dualityAnalysisResult = duality.PerformDualityAnalysis(lines);
                metroSetRichTextBox1.Text = dualityAnalysisResult;
            }
        }

        private void metroSetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            ShadowPricing shadowPricing = new ShadowPricing();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the LP file
                    string[] lpLines = fileHandler.ReadFile(openFileDialog.FileName);

                    // Calculate shadow pricing
                    string result = shadowPricing.CalculateShadowPricing(lpLines);

                    // Display the result in MetroSetRichTextBox
                    metroSetRichTextBox2.Text = result;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                openFileDialog.Title = "Upload LP File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the selected file
                    string filePath = openFileDialog.FileName;

                    // Perform the sensitivity analysis
                    SensitivityAnalysis analysis = new SensitivityAnalysis(metroSetRichTextBox3);
                    analysis.LoadLPFile(filePath);
                }
            }
        }
        private void ProcessFileContent(string[] lines)
        {
            // Extract ranges and details from the LP file content
            string nonBasicVariableRange = GetNonBasicVariableRange(lines);
            string basicVariableRange = GetBasicVariableRange(lines);
            string rhsRange = GetConstraintRHSRange(lines);
            string variableRange = GetVariableRangeInNonBasicColumn(lines);

            // Display the results in the MetroSetRichTextBox
            metroSetRichTextBox3.Text = $"Non-Basic Variable Range: {nonBasicVariableRange}\n" +
                                        $"Basic Variable Range: {basicVariableRange}\n" +
                                        $"Constraint RHS Range: {rhsRange}\n" +
                                        $"Variable Range in Non-Basic Column: {variableRange}";
        }

        private string GetNonBasicVariableRange(string[] lines)
        {
            // Extract the objective function line
            string objectiveLine = lines[0];
            var coefficients = objectiveLine.Split(' ').Skip(1).Select(s => int.Parse(s.Replace("+", "")));

            // Assuming non-basic variables are the coefficients in the objective function
            int min = coefficients.Min();
            int max = coefficients.Max();

            return $"{min} to {max}";
        }

        private string GetBasicVariableRange(string[] lines)
        {
            // Assuming basic variables correspond to coefficients in constraints
            var constraintLines = lines.Skip(1).Take(lines.Length - 2);
            var coefficients = constraintLines.SelectMany(line => line.Split(' ').Skip(1).Take(line.Split(' ').Length - 2).Select(s => int.Parse(s.Replace("+", ""))));

            int min = coefficients.Min();
            int max = coefficients.Max();

            return $"{min} to {max}";
        }

        private string GetConstraintRHSRange(string[] lines)
        {
            // Extract the RHS values from the constraint lines
            var constraintLines = lines.Skip(1).Take(lines.Length - 2);
            var rhsValues = constraintLines.Select(line => int.Parse(line.Split(' ').Last()));

            int min = rhsValues.Min();
            int max = rhsValues.Max();

            return $"{min} to {max}";
        }

        private string GetVariableRangeInNonBasicColumn(string[] lines)
        {
            // Assuming this method calculates the range for the coefficients of a specific variable
            // in the non-basic column (e.g., first column after the objective)
            var variableColumnValues = lines.Skip(1).Take(lines.Length - 2).Select(line => int.Parse(line.Split(' ')[1]));

            int min = variableColumnValues.Min();
            int max = variableColumnValues.Max();

            return $"{min} to {max}";
        }
    }
}

