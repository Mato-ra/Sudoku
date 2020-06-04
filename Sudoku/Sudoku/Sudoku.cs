using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    public class Sudoku
    {
        public readonly bool randomBoxFormation;
        public int boxPerRowAmount;
        public bool diagonalRows;
        public Difficulty difficulty;
        public int[] dimensions;
        public int fieldsPerRowAmount;
        public int rating = 0;
        public List<int[][]> SudokuBoxArrayList = null;
        public int[,] SudokuFilledInArray = null;
        public int[,] SudokuIncompleteArray = null;
        private int[] difficultyRange = new int[2];
        private List<int> integersList;
        private List<int[][]> protectedPatternsList;
        private int[,] SudokuCompleteArray = null;

        public Sudoku(int fieldsPerRowAmount, Difficulty difficulty, bool diagonalRows, bool randomBoxFormation)
        {
            this.fieldsPerRowAmount = fieldsPerRowAmount;
            switch (fieldsPerRowAmount)
            {
                case 9:
                    boxPerRowAmount = 3;
                    break;
            }

            this.difficulty = difficulty;
            this.diagonalRows = diagonalRows;
            this.randomBoxFormation = randomBoxFormation;
            integersList = CreateListOfAllIntegers();
            SudokuFilledInArray = CreateEmptySudokuArray();
            if (difficulty == Difficulty.Custom)
            {
                CreateSudokuBoxes();
                integersList = CreateListOfAllIntegers();
                SudokuCompleteArray = CreateEmptySudokuArray();
                SudokuIncompleteArray = CreateEmptySudokuArray();
                SudokuFilledInArray = CreateEmptySudokuArray();
            }
            else
            {
                CreateCompleteSudokuGrid();
                CreateIncompleteSudokuGrid();
            }
        }

        public Sudoku(string gridCode)
        {
            var gridCodeArr = gridCode.Split('|');
            ReadGridCodeGridData(gridCodeArr[0]);
            ReadGridCodeFieldData(gridCodeArr[1]);
        }

        public int[,] CreateEmptySudokuArray()
        {
            return new int[fieldsPerRowAmount, fieldsPerRowAmount];
        }

        public List<int> CreateListOfAllIntegers()
        {
            var l = new List<int>();
            for (int i = 1; i <= fieldsPerRowAmount; i++)
            {
                l.Add(i);
            }

            return l;
        }

        public int[][] GetBoxArrayOfCoordinate(int[] coordinate)
        {
            foreach (var box in SudokuBoxArrayList)
            {
                foreach (var field in box)
                {
                    if (field[0] == coordinate[0] && field[1] == coordinate[1])
                        return box;
                }
            }
            return null;
        }

        public int GetBoxNumberOfCoordinate(int[] coordinate)
        {
            foreach (var box in SudokuBoxArrayList)
            {
                foreach (var field in box)
                {
                    if (field[0] == coordinate[0] && field[1] == coordinate[1])
                        return SudokuBoxArrayList.IndexOf(box);
                }
            }
            return -1;
        }

        public int[,] GetCopyOfCompleteSudokuArray()
        {
            return Solver.CopySudoku(SudokuCompleteArray);
        }

        public int GetIntegerOfCompleteArray(int[] coordinate)
        {
            if (SudokuCompleteArray != null)
            {
                return SudokuCompleteArray[coordinate[0], coordinate[1]];
            }
            else
            {
                return 0;
            }
        }

        public int GetIntegerOfFilledInArray(int[] coordinate)
        {
            if (SudokuFilledInArray != null)
            {
                return SudokuFilledInArray[coordinate[0], coordinate[1]];
            }
            else
            {
                return 0;
            }
        }

        public int GetIntegerOfIncompleteArray(int[] coordinate)
        {
            if (SudokuIncompleteArray != null)
            {
                return SudokuIncompleteArray[coordinate[0], coordinate[1]];
            }
            else
            {
                return 0;
            }
        }

        public List<int> GetListOfAllIntegers()
        {
            return integersList;
        }

        public void ReadGridCodeFieldData(string fieldCode)
        {
            var fieldCodeArr = fieldCode.Split(';');

            foreach (var f in fieldCodeArr)
            {
                var fieldDataArr = f.Split(',');
                var coordinate = fieldDataArr[0].Split('.').Select(Int32.Parse).ToArray();

                var i = Convert.ToInt32(fieldDataArr[1]);

                if (i != 0)
                {
                    if (fieldDataArr[3] == "True")
                    {
                        SudokuIncompleteArray[coordinate[0], coordinate[1]] = i;
                    }
                    else
                    {
                        SudokuFilledInArray[coordinate[0], coordinate[1]] = i;
                    }
                }

                SudokuCompleteArray[coordinate[0], coordinate[1]] = Convert.ToInt32(fieldDataArr[2]);

                var s = SudokuBoxArrayList[Convert.ToInt32(fieldDataArr[4])];
                for (int c = 0; c < s.Length; c++)
                {
                    if (s[c][0] == -1)
                    {
                        s[c] = coordinate;
                        break;
                    }
                }
            }
        }

        public void ReadGridCodeGridData(string gridData)
        {
            var gridDataArr = gridData.Split(',');

            switch (gridDataArr[0])
            {
                case "9.9":
                    boxPerRowAmount = 3;
                    fieldsPerRowAmount = 9;
                    break;
            }

            difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), gridDataArr[1]);
            rating = Convert.ToInt32(gridDataArr[2]);

            if (gridDataArr[3] == "True")
            {
                diagonalRows = true;
            }
            SudokuCompleteArray = CreateEmptySudokuArray();
            SudokuIncompleteArray = CreateEmptySudokuArray();
            SudokuFilledInArray = CreateEmptySudokuArray();
            SudokuBoxArrayList = new List<int[][]>();
            integersList = CreateListOfAllIntegers();

            for (int i = 0; i < fieldsPerRowAmount; i++)
            {
                SudokuBoxArrayList.Add(new int[fieldsPerRowAmount][]);
                for (int j = 0; j < fieldsPerRowAmount; j++)
                {
                    SudokuBoxArrayList[i][j] = new int[2] { -1, -1 };
                }
            }
        }

        public void SetCompleteSudokuArray(int[,] sudokuArray)
        {
            SudokuCompleteArray = sudokuArray;
        }

        private short CheckIfDifficultyMet(Difficulty difficulty, int[,] sudokuArray)
        {
            //-1: too hard,
            //0: too easy,
            //1: met,

            var tooEasy = false;

            int[] numbersPerBox;
            int[] instancesOfNumbers;
            int[] numbersPerRow;
            int[] overallNumbers;

            switch (difficulty)
            {
                case Difficulty.Easy:
                    numbersPerBox = new int[2] { 2, 9 };
                    instancesOfNumbers = new int[2] { 1, 9 };
                    numbersPerRow = new int[2] { 1, 9 };
                    overallNumbers = new int[2] { 30, 40 };
                    break;

                case Difficulty.Normal:
                    numbersPerBox = new int[2] { 1, 8 };
                    instancesOfNumbers = new int[2] { 1, 7 };
                    numbersPerRow = new int[2] { 1, 7 };
                    overallNumbers = new int[2] { 25, 30 };
                    break;

                case Difficulty.Hard:
                    numbersPerBox = new int[2] { 1, 5 };
                    instancesOfNumbers = new int[2] { 0, 7 };
                    numbersPerRow = new int[2] { 0, 5 };
                    overallNumbers = new int[2] { 20, 25 };
                    break;

                case Difficulty.VeryHard:
                    numbersPerBox = new int[2] { 0, 7 };
                    instancesOfNumbers = new int[2] { 0, 7 };
                    numbersPerRow = new int[2] { 0, 7 };
                    overallNumbers = new int[2] { 17, 25 };
                    break;

                case Difficulty.ExtremelyHard:
                    numbersPerBox = new int[2] { 0, 9 };
                    instancesOfNumbers = new int[2] { 0, 9 };
                    numbersPerRow = new int[2] { 0, 9 };
                    overallNumbers = new int[2] { 15, 25 };
                    break;

                default:
                    numbersPerBox = new int[2] { 2, 9 };
                    instancesOfNumbers = new int[2] { 1, 9 };
                    numbersPerRow = new int[2] { 1, 9 };
                    overallNumbers = new int[2] { 30, 35 };
                    break;
            }
            if (!diagonalRows)
            {
                overallNumbers[1] += 3;
            }

            int n;

            if (!CheckIfProtectedPatternsAreSafe(sudokuArray))
            {
                return -1;
            }

            foreach (var i in CreateListOfAllIntegers())
            {
                n = Solver.CountInstancesOfInteger(i, sudokuArray);
                if (n > instancesOfNumbers[1])
                    tooEasy = true;
                if (n < instancesOfNumbers[0])
                    return -1;

                n = Solver.CountIntegersOfRow(i - 1, sudokuArray);
                if (n > numbersPerRow[1])
                    tooEasy = true;
                if (n < numbersPerRow[0])
                    return -1;

                n = Solver.CountIntegersOfColumn(i - 1, sudokuArray);
                if (n > numbersPerRow[1])
                    tooEasy = true;
                if (n < numbersPerRow[0])
                    return -1;

                n = Solver.CountIntegersOfBox(SudokuBoxArrayList[i - 1], sudokuArray);
                if (n > numbersPerBox[1])
                    tooEasy = true;
                if (n < numbersPerBox[0])
                    return -1;
            }

            n = Solver.CountIntegersOfGrid(sudokuArray);
            if (n > overallNumbers[1])
                tooEasy = true;
            if (n < overallNumbers[0])
                return -1;

            if (tooEasy)
                return 0;

            return 1;
        }

        private bool CheckIfProtectedPatternIsSafe(int[,] sudokuArray, int[][] protectedPattern)
        {
            foreach (var c in protectedPattern)
            {
                if (sudokuArray[c[0], c[1]] != 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckIfProtectedPatternsAreSafe(int[,] sudokuArray)
        {
            for (int i = 0; i < protectedPatternsList.Count; i++)
            {
                if (!CheckIfProtectedPatternIsSafe(sudokuArray, protectedPatternsList[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private void CreateCompleteSudokuGrid()
        {
            SudokuCompleteArray = CreateEmptySudokuArray();
            CreateSudokuBoxes();

            var sudokuArray = Solver.CopySudoku(SudokuCompleteArray);

            FillSudoku(sudokuArray);
        }

        private void CreateIncompleteSudokuGrid()
        {
            int[,] sudokuArray = Solver.CopySudoku(SudokuCompleteArray); ;
            protectedPatternsList = DetermineProtectedPatterns();

            if (boxPerRowAmount == 3)
            {
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        difficultyRange[0] = 450;
                        difficultyRange[1] = 530;
                        break;

                    case Difficulty.Normal:
                        if (diagonalRows)
                        {
                            difficultyRange[0] = 560;
                            difficultyRange[1] = 660;
                        }
                        else
                        {
                            difficultyRange[0] = 530;
                            difficultyRange[1] = 575;
                        }
                        break;

                    case Difficulty.Hard:
                        if (diagonalRows)
                        {
                            difficultyRange[0] = 660;
                            difficultyRange[1] = 775;
                        }
                        else
                        {
                            difficultyRange[0] = 575;
                            difficultyRange[1] = 630;
                        }
                        break;

                    case Difficulty.VeryHard:
                        if (diagonalRows)
                        {
                            difficultyRange[0] = 775;
                            difficultyRange[1] = 950;
                        }
                        else
                        {
                            difficultyRange[0] = 630;
                            difficultyRange[1] = 700;
                        }
                        break;

                    case Difficulty.ExtremelyHard:
                        if (diagonalRows)
                        {
                            difficultyRange[0] = 950;
                            difficultyRange[1] = 1500;
                        }
                        else
                        {
                            difficultyRange[0] = 700;
                            difficultyRange[1] = 1500;
                        }
                        break;
                }
            }

            while (true)
            {
                RemoveRandomIntegers(sudokuArray);

                if (CheckIfDifficultyMet(difficulty, sudokuArray) == 1)
                {
                    var p = Solver.RateSudokuGrid(this, Solver.CopySudoku(sudokuArray));
                    if (p >= difficultyRange[0] && p <= difficultyRange[1])
                    {
                        rating = p;
                        break;
                    }
                }

                sudokuArray = Solver.CopySudoku(SudokuCompleteArray);
            }

            SudokuIncompleteArray = Solver.CopySudoku(sudokuArray);
        }

        private void CreateSudokuBoxes()
        {
            SudokuBoxArrayList = new List<int[][]>();
            if (!randomBoxFormation)
            {
                for (int i = 0; i < fieldsPerRowAmount; i++)
                {
                    SudokuBoxArrayList.Add(new int[fieldsPerRowAmount][]);
                    for (int j = 0; j < fieldsPerRowAmount; j++)
                    {
                        SudokuBoxArrayList[i][j] = new int[2]
                        {
                                (i / boxPerRowAmount) * boxPerRowAmount + j % boxPerRowAmount,
                                (i % boxPerRowAmount) * boxPerRowAmount + j / boxPerRowAmount,
                        };
                    }
                }
            }
        }

        private List<int[][]> DetermineProtectedPatterns()
        {
            var protectedPatternsList = new List<int[][]>();

            for (int x1 = 0; x1 < fieldsPerRowAmount; x1++)
            {
                for (int x2 = x1 + 1; x2 < fieldsPerRowAmount; x2++)
                {
                    for (int i = 0; i < fieldsPerRowAmount; i++)
                    {
                        for (int j = i + 1; j < fieldsPerRowAmount; j++)
                        {
                            if (GetBoxNumberOfCoordinate(new int[2] { x1, i }) == GetBoxNumberOfCoordinate(new int[2] { x1, j })
                                &&
                                GetBoxNumberOfCoordinate(new int[2] { x2, i }) == GetBoxNumberOfCoordinate(new int[2] { x2, j })
                                )
                            {
                                if (SudokuCompleteArray[x1, i] == SudokuCompleteArray[x2, j] && SudokuCompleteArray[x1, j] == SudokuCompleteArray[x2, i])
                                {
                                    protectedPatternsList.Add(new int[][] {
                                        new int[] { x1, i },
                                        new int[] { x1, j },
                                        new int[] { x2, i },
                                        new int[] { x2, j },
                                    }
                                    );
                                }
                            }
                        }
                    }
                }
            }

            return protectedPatternsList;
        }

        private void FillSudoku(int[,] sudokuArray)
        {
            var sudokuBacklog = new List<int[,]>();
            sudokuBacklog.Add(sudokuArray);
            var intList = CreateListOfAllIntegers();
            foreach (var i in intList)
            {
                sudokuBacklog.Add(null);
            }

            intList = RandomizeList(intList);
            var attempt = 0;
            for (int i = 0; i < intList.Count;)
            {
                var currentSudoku = sudokuBacklog[i];
                var newSudoku = InsertIntIntoSudoku(intList[i], currentSudoku);

                if (newSudoku != null)
                {
                    sudokuBacklog[i + 1] = newSudoku;
                    i += 1;
                    attempt = 0;
                }
                else
                {
                    attempt += 1;
                    if (attempt >= i * 3)
                    {
                        attempt = 0;
                        i -= 1;
                        if (i < 0)
                            i = 0;
                    }
                }
            }

            sudokuArray = sudokuBacklog[intList.Count];
            SudokuCompleteArray = Solver.CopySudoku(sudokuArray);
        }

        private bool InsertIntIntoColumn(int integer, int column, int[,] sudokuArray)
        {
            for (int i = 0; i < fieldsPerRowAmount; i++)
            {
                if (InsertIntIntoField(sudokuArray, new int[2] { column, i }, integer))
                    return true;
                if (sudokuArray[column, i] == integer)
                    return true;
            }
            return false;
        }

        private bool InsertIntIntoDiagonals(int integer, List<int> rowList, int[,] sudokuArray)
        {
            for (int i = 0; i < rowList.Count; i++)
            {
                if (InsertIntIntoField(sudokuArray, new int[2] { rowList[i] - 1, rowList[i] - 1 }, integer))
                {
                    if (1 + rowList[i] * 2 == fieldsPerRowAmount)
                    {
                        return true;
                    }
                    break;
                }
                if (i == rowList.Count - 1)
                    return false;
            }
            for (int i = 0; i < rowList.Count; i++)
            {
                if (InsertIntIntoField(sudokuArray, new int[2] { fieldsPerRowAmount - rowList[i], rowList[i] - 1 }, integer))
                {
                    return true;
                }
            }
            return false;
        }

        private bool InsertIntIntoField(int[,] sudokuArray, int[] coordinate, int integer)
        {
            if (sudokuArray[coordinate[0], coordinate[1]] == integer)
                return true;
            if (sudokuArray[coordinate[0], coordinate[1]] != 0)
                return false;
            if (Solver.CheckIfAssignable(this, sudokuArray, coordinate, integer))
            {
                sudokuArray[coordinate[0], coordinate[1]] = integer;
                return true;
            }
            return false;
        }

        private bool InsertIntIntoRow(int integer, int row, int[,] sudokuArray)
        {
            for (int i = 0; i < fieldsPerRowAmount; i++)
            {
                if (InsertIntIntoField(sudokuArray, new int[2] { i, row }, integer))
                    return true;
                if (sudokuArray[i, row] == integer)
                    return true;
            }
            return false;
        }

        private int[,] InsertIntIntoSudoku(int integer, int[,] sudokuArray)
        {
            int[,] newSudokuArray = Solver.CopySudoku(sudokuArray);

            var rowList = CreateListOfAllIntegers();
            rowList = RandomizeList(rowList);

            for (int i = 0; i < rowList.Count; i++)
            {
                if (i == 0 && diagonalRows)
                {
                    if (!InsertIntIntoDiagonals(integer, rowList, newSudokuArray))
                        break;
                }

                if (!InsertIntIntoRow(integer, rowList[i] - 1, newSudokuArray))
                {
                    break;
                }
                if (i == rowList.Count - 1)
                {
                    return newSudokuArray;
                }
            }

            newSudokuArray = Solver.CopySudoku(sudokuArray);

            for (int i = 0; i < rowList.Count; i++)
            {
                if (i == 0 && diagonalRows)
                {
                    if (!InsertIntIntoDiagonals(integer, rowList, newSudokuArray))
                        break;
                }

                if (!InsertIntIntoColumn(integer, rowList[i] - 1, newSudokuArray))
                {
                    break;
                }
                if (i == rowList.Count - 1)
                {
                    return newSudokuArray;
                }
            }

            return null;
        }

        private List<int> RandomizeList(List<int> list)
        {
            var r = new Random();
            var copyList = new List<int>();

            foreach (int i in list)
            {
                copyList.Add(i);
            }

            var newList = new List<int>();
            while (copyList.Count > 0)
            {
                var n = r.Next(0, copyList.Count);
                newList.Add(copyList[n]);
                copyList.RemoveAt(n);
            }
            return newList;
        }

        private void RemoveRandomIntegers(int[,] sudokuArray)
        {
            var r = new Random();

            var boolArray = new bool[5] { false, false, false, false, false };

            var excludedCoordinatesList = new List<int[]>();

            switch (difficulty)
            {
                case Difficulty.Easy:
                    break;

                case Difficulty.Normal:
                    boolArray[0] = true;
                    break;

                case Difficulty.Hard:
                    boolArray[0] = true;
                    boolArray[1] = true;
                    break;

                case Difficulty.VeryHard:
                    boolArray[0] = true;
                    boolArray[1] = true;
                    boolArray[2] = true;
                    boolArray[3] = true;
                    break;

                case Difficulty.ExtremelyHard:
                    boolArray[0] = true;
                    boolArray[1] = true;
                    boolArray[2] = true;
                    boolArray[3] = true;
                    boolArray[4] = true;
                    break;
            }
            for (int j = 0; j < 5; j++)
            {
                var rowsList = RandomizeList(integersList);

                for (int i = 0; i < rowsList.Count; i++)
                {
                    var coordinate = new int[2] { r.Next(0, fieldsPerRowAmount), rowsList[i] - 1 };
                    int n = sudokuArray[coordinate[0], coordinate[1]];
                    if (n != 0 && !Solver.CheckIfCoordinateListContainsCoordinate(excludedCoordinatesList, coordinate))
                    {
                        sudokuArray[coordinate[0], coordinate[1]] = 0;
                        if (CheckIfDifficultyMet(difficulty, sudokuArray) == -1)
                        {
                            sudokuArray[coordinate[0], coordinate[1]] = n;
                            excludedCoordinatesList.Add(coordinate);
                        }
                        else
                        {
                            var p = Solver.RateSudokuGrid(this, Solver.CopySudoku(sudokuArray), boolArray[0], boolArray[1], boolArray[2], boolArray[3], boolArray[4]);

                            if (p == 0 || p > difficultyRange[1])
                            {
                                sudokuArray[coordinate[0], coordinate[1]] = n;
                                excludedCoordinatesList.Add(coordinate);
                            }
                        }
                    }
                }

                var columnList = RandomizeList(rowsList);

                for (int i = 0; i < columnList.Count; i++)
                {
                    var coordinate = new int[2] { columnList[i] - 1, r.Next(0, fieldsPerRowAmount) };
                    int n = sudokuArray[coordinate[0], coordinate[1]];
                    if (n != 0 && !Solver.CheckIfCoordinateListContainsCoordinate(excludedCoordinatesList, coordinate))
                    {
                        sudokuArray[coordinate[0], coordinate[1]] = 0;
                        if (CheckIfDifficultyMet(difficulty, sudokuArray) == -1)
                        {
                            sudokuArray[coordinate[0], coordinate[1]] = n;
                            excludedCoordinatesList.Add(coordinate);
                        }
                        else
                        {
                            var p = Solver.RateSudokuGrid(this, Solver.CopySudoku(sudokuArray), boolArray[0], boolArray[1], boolArray[2], boolArray[3], boolArray[4]);

                            if (p == 0 || p > difficultyRange[1])
                            {
                                sudokuArray[coordinate[0], coordinate[1]] = n;
                                excludedCoordinatesList.Add(coordinate);
                            }
                        }
                    }
                }
            }

            var rowList = RandomizeList(integersList);

            for (int x = 0; x < fieldsPerRowAmount; x++)
            {
                int row = rowList[x] - 1;
                var columnList = RandomizeList(rowList);
                for (int y = 0; y < fieldsPerRowAmount; y++)
                {
                    int col = columnList[x] - 1;
                    var coordinate = new int[2] { col, row };
                    int n = sudokuArray[col, row];
                    if (n != 0 && !Solver.CheckIfCoordinateListContainsCoordinate(excludedCoordinatesList, coordinate))
                    {
                        sudokuArray[col, row] = 0;
                        if (CheckIfDifficultyMet(difficulty, sudokuArray) == -1)
                        {
                            sudokuArray[coordinate[0], coordinate[1]] = n;
                            excludedCoordinatesList.Add(coordinate);
                        }
                        else
                        {
                            var p = Solver.RateSudokuGrid(this, Solver.CopySudoku(sudokuArray), boolArray[0], boolArray[1], boolArray[2], boolArray[3], boolArray[4]);

                            if (p == 0 || p > difficultyRange[1])
                            {
                                sudokuArray[coordinate[0], coordinate[1]] = n;
                                excludedCoordinatesList.Add(coordinate);
                            }
                            else
                            {
                                Console.WriteLine(p);
                            }
                        }
                    }
                }
            }
        }
    }
}