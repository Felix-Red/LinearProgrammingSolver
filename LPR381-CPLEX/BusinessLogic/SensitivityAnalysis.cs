using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPR381_CPLEX.DataLayer;
using ILOG.Concert;
using ILOG.CPLEX;

namespace LPR381_CPLEX.BusinessLogic
{
    class SensitivityAnalysis
    {
        private FileHandler fileHandler;
        private MetroSet_UI.Controls.MetroSetRichTextBox richTextBox;

        public SensitivityAnalysis(MetroSet_UI.Controls.MetroSetRichTextBox rtb)
        {
            fileHandler = new FileHandler();
            richTextBox = rtb;
        }

        public void LoadLPFile(string filePath)
        {
            string[] lines = fileHandler.ReadFile(filePath);
            DisplaySensitivityAnalysis(lines);
        }

        private void DisplaySensitivityAnalysis(string[] lpLines)
        {
            // Assume the first line is the objective function, the next are constraints
            string objectiveFunction = lpLines[0];
            string[] constraints = new string[lpLines.Length - 2];
            Array.Copy(lpLines, 1, constraints, 0, lpLines.Length - 2);

            // Perform sensitivity analysis (this is just a placeholder logic)
            // You will need to implement the actual sensitivity analysis logic
            string nonBasicVariableRange = "Range for non-selected variables: 0";
            string basicVariableRange = "Range for selected basic variables: 15";
            string rhsRange = "Range for selected constraint RHS: 38";

            // Display the results in the RichTextBox
            richTextBox.AppendText("Objective Function: " + objectiveFunction + Environment.NewLine);
            richTextBox.AppendText("Constraints: " + Environment.NewLine);
            foreach (string constraint in constraints)
            {
                richTextBox.AppendText(constraint + Environment.NewLine);
            }
            richTextBox.AppendText(nonBasicVariableRange + Environment.NewLine);
            richTextBox.AppendText(basicVariableRange + Environment.NewLine);
            richTextBox.AppendText(rhsRange + Environment.NewLine);
        }
    }
}
