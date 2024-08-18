using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LPR381_CPLEX.DataLayer
{
    class FileHandler
    {
        public string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public void WriteFile(string filePath, string[] lines)
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
