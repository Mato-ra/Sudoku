using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    internal static class SudokuFileReader
    {
        public static Sudoku LoadGridFromFile(string path)
        {
            return ReadGridCode(File.ReadAllText(path));
        }

        public static Sudoku ReadGridCode(string gridCode)
        {
            return new Sudoku(gridCode);
        }
    }
}