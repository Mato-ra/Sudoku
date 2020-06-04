using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] arguments)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (arguments.Length > 0)
            {
                var path = arguments[0];
                Application.Run(new SudokuForm(SudokuFileReader.LoadGridFromFile(path), path));
            }
            else
            {
                Application.Run(new SudokuMenu());
            }
        }
    }
}