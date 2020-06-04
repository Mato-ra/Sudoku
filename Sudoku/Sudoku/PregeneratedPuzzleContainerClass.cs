using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal static class PregeneratedPuzzleContainerClass
    {
        public static string GetGridCode(int gridID)
        {
            return Properties.Resources.PregeneratedPuzzles.Split(Convert.ToChar(10))[gridID - 1];
        }

        public static List<string[]> GetGridInfoList()
        {
            var gridInfoList = new List<string[]>();
            for (int i = 1; i <= 50; i++)
            {
                var s = GetGridCode(i);
                s = s.Split('|')[0];
                var sa = s.Split(',');
                gridInfoList.Add(sa);
            }
            return gridInfoList;
        }
    }
}