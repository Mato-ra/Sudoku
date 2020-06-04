using System.Collections.Generic;
using System.Linq;
using System;

namespace Sudoku
{
    internal static class Solver
    {
        public static bool CheckIfAssignable(Sudoku sudoku, int[,] sudokuArray, int[] coordinate, int newInteger)
        {
            if (sudokuArray[coordinate[0], coordinate[1]] != 0)
                return false;

            // check row and column
            for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
            {
                if (sudokuArray[i, coordinate[1]] == newInteger)
                {
                    return false;
                }
                if (sudokuArray[coordinate[0], i] == newInteger)
                {
                    return false;
                }
            }

            // check box

            var boxArray = sudoku.GetBoxArrayOfCoordinate(coordinate);

            foreach (var field in boxArray)
            {
                if (sudokuArray[field[0], field[1]] == newInteger)
                    return false;
            }

            // check diagonal

            if (sudoku.diagonalRows)
            {
                if (coordinate[0] == coordinate[1])
                {
                    for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                    {
                        if (sudokuArray[i, i] == newInteger)
                            return false;
                    }
                }
                if (sudoku.fieldsPerRowAmount - 1 - coordinate[0] == coordinate[1])
                {
                    for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                    {
                        if (sudokuArray[sudoku.fieldsPerRowAmount - 1 - i, i] == newInteger)
                            return false;
                    }
                }
            }

            return true;
        }

        public static bool CheckIfComplete(int[,] sudokuArray)
        {
            foreach (var f in sudokuArray)
            {
                if (f == 0)
                    return false;
            }
            return true;
        }

        public static bool CheckIfCoordinateListContainsCoordinate(List<int[]> coordinateList, int[] coordinate)
        {
            foreach (var c in coordinateList)
            {
                if (coordinate[0] == c[0] && coordinate[1] == c[1])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckIfGridHasMultipleSolutions(Sudoku sudoku, int[,] sudokuArray)
        {
            return CheckIfGridHasOnlyOneSolution(sudoku, sudokuArray, GetCoordinateListOfEmptyFields(sudokuArray));
        }

        public static bool CheckIfGridHasOnlyOneSolution(Sudoku sudoku, int[,] sudokuArray, List<int[]> emptyFieldCoordinateList)
        {
            var intList = sudoku.GetListOfAllIntegers();
            var solutions = 0;
            var coordinateList = emptyFieldCoordinateList;

            for (int n = 0; n < coordinateList.Count;)
            {
                if (n < 0)
                {
                    return false;
                }
                var coordinate = coordinateList[n];
                var previousValue = sudokuArray[coordinate[0], coordinate[1]];
                sudokuArray[coordinate[0], coordinate[1]] = 0;
                var index = intList.IndexOf(previousValue) + 1;
                for (int i = index; i <= intList.Count; i++)
                {
                    if (i == intList.Count)
                    {
                        n -= 1;
                        break;
                    }
                    if (CheckIfAssignable(sudoku, sudokuArray, coordinate, intList[i]))
                    {
                        if (n == coordinateList.Count - 1)
                        {
                            solutions += 1;
                            if (solutions >= 2)
                            {
                                return false;
                            }
                            n -= 1;
                            break;
                        }
                        sudokuArray[coordinate[0], coordinate[1]] = intList[i];
                        n += 1;
                        break;
                    }
                }
            }

            return true;
        }

        public static bool CompareSudokuGrids(int[,] sudokuArray1, int[,] sudokuArray2)
        {
            for (int x = 0; x < sudokuArray1.GetLength(0); x++)
            {
                for (int y = 0; y < sudokuArray1.GetLength(1); y++)
                {
                    if (sudokuArray1[x, y] != sudokuArray2[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static List<int[]> CompareSudokuGridsAndFindMistakes(int[,] incompleteArray, int[,] completeArray)
        {
            var mistakesList = new List<int[]>();
            for (int x = 0; x < incompleteArray.GetLength(0); x++)
            {
                for (int y = 0; y < incompleteArray.GetLength(1); y++)
                {
                    if (incompleteArray[x, y] != 0)
                    {
                        if (incompleteArray[x, y] != completeArray[x, y])
                        {
                            mistakesList.Add(new int[2] { x, y });
                        }
                    }
                }
            }

            return mistakesList;
        }

        public static int[,] CopySudoku(int[,] sudokuArray)
        {
            var sArray = new int[sudokuArray.GetLength(0), sudokuArray.GetLength(1)];
            Array.Copy(sudokuArray, sArray, sudokuArray.Length);
            return sArray;
        }

        public static int CountEmptyFieldsOfGrid(int[,] sudokuArray)
        {
            var n = 0;
            foreach (int i in sudokuArray)
            {
                if (i == 0)
                    n += 1;
            }
            return n;
        }

        public static int CountInstancesOfInteger(int integer, int[,] sudokuArray)
        {
            var n = 0;
            foreach (int i in sudokuArray)
            {
                if (i == integer)
                    n += 1;
            }
            return n;
        }

        public static int CountIntegersOfBox(int[][] box, int[,] sudokuArray)
        {
            var n = 0;
            foreach (int[] b in box)
            {
                if (sudokuArray[b[0], b[1]] != 0)
                {
                    n += 1;
                }
            }
            return n;
        }

        public static int CountIntegersOfColumn(int column, int[,] sudokuArray)
        {
            var n = 0;
            for (int i = 0; i < sudokuArray.GetLength(1); i++)
            {
                if (sudokuArray[column, i] != 0)
                    n += 1;
            }
            return n;
        }

        public static int CountIntegersOfGrid(int[,] sudokuArray)
        {
            var n = 0;
            foreach (int i in sudokuArray)
            {
                if (i != 0)
                    n += 1;
            }
            return n;
        }

        public static int CountIntegersOfRow(int row, int[,] sudokuArray)
        {
            var n = 0;
            for (int i = 0; i < sudokuArray.GetLength(0); i++)
            {
                if (sudokuArray[i, row] != 0)
                    n += 1;
            }
            return n;
        }

        public static int[,][] CreateFieldMarkArray(Sudoku sudoku, int[,] sudokuArray, bool interruptIfSinglePossibility)
        {
            var fieldmarks = new int[sudoku.fieldsPerRowAmount, sudoku.fieldsPerRowAmount][];
            var intList = sudoku.GetListOfAllIntegers();

            for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                {
                    var f = new List<int>();
                    if (sudokuArray[x, y] == 0)
                    {
                        var cell = new int[2] { x, y };
                        foreach (int i in intList)
                        {
                            if (CheckIfAssignable(sudoku, sudokuArray, cell, i))
                            {
                                f.Add(i);
                            }
                        }
                    }

                    fieldmarks[x, y] = f.ToArray();
                    if (f.Count == 1 && interruptIfSinglePossibility)
                    {
                        return fieldmarks;
                    }
                }
            }

            return fieldmarks;
        }

        public static List<int[]> GetCoordinateListOfEmptyFields(int[,] sudokuArray)
        {
            var coordinateList = new List<int[]>();

            for (int x = 0; x < sudokuArray.GetLength(0); x++)
            {
                for (int y = 0; y < sudokuArray.GetLength(1); y++)
                {
                    if (sudokuArray[x, y] == 0)
                    {
                        coordinateList.Add(new int[2] { x, y });
                    }
                }
            }

            return coordinateList;
        }

        public static bool PerformFullRuleOut(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            var ruleOutPositive = false;

            while (RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                ruleOutPositive = true;
            }
            while (RuleOutOuterMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                ruleOutPositive = true;
            }
            while (RuleOutMarksWithForcedChain(sudoku, sudokuArray, fieldmarks))
            {
                ruleOutPositive = true;
            }
            while (RuleOutMarksWithFish(sudoku, fieldmarks))
            {
                ruleOutPositive = true;
            }
            while (RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                ruleOutPositive = true;
            }

            if (ruleOutPositive)
            {
                PerformFullRuleOut(sudoku, sudokuArray, fieldmarks);
            }

            return ruleOutPositive;
        }

        public static int RateSudokuGrid(Sudoku sudoku, int[,] sudokuArray)
        {
            return RateSudokuGrid(sudoku, sudokuArray, true, true, true, true, true);
        }

        public static int RateSudokuGrid(Sudoku sudoku, int[,] sudokuArray, bool useGroupChains, bool useFish, bool useNakedAndHiddenGroups, bool useForcedChain, bool doubleCheck)
        {
            var points = 0;
            while (true)
            {
                var f = Solver.SolveAndRateOneField(sudoku, sudokuArray, useGroupChains, useFish, useNakedAndHiddenGroups, useForcedChain, doubleCheck);
                if (f == 0)
                {
                    return 0;
                }
                else
                {
                    points += f;
                }
                if (Solver.CheckIfComplete(sudokuArray))
                    return points;
            }
        }

        public static int SolveAndRateOneField(Sudoku sudoku, int[,] sudokuArray)
        {
            return SolveAndRateOneField(sudoku, sudokuArray, true, true, true, true, true);
        }

        public static int SolveAndRateOneField(Sudoku sudoku, int[,] sudokuArray, bool useGroupChains, bool useFish, bool useNakedAndHiddenGroups, bool useForcedChain, bool doubleCheck)
        {
            var fieldmarks = CreateFieldMarkArray(sudoku, sudokuArray, false);

            var i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
            if (i != 0)
            {
                return i;
            }

            while (useGroupChains && RuleOutOuterMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 2;
                }
            }

            while (useGroupChains && RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 3;
                }
            }

            while (useNakedAndHiddenGroups && RuleOutMarksWithNakedOrHiddenGroups(sudoku, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 4;
                }
            }

            while (useFish && RuleOutMarksWithFish(sudoku, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 5;
                }
            }
            while (useForcedChain && RuleOutMarksWithForcedChain(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 6;
                }
            }

            //double check

            while (doubleCheck && useGroupChains && RuleOutOuterMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 6;
                }
            }

            while (doubleCheck && useGroupChains && RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 6;
                }
            }

            while (doubleCheck && useNakedAndHiddenGroups && RuleOutMarksWithNakedOrHiddenGroups(sudoku, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 7;
                }
            }

            while (doubleCheck && useFish && RuleOutMarksWithFish(sudoku, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 7;
                }
            }

            while (doubleCheck && useForcedChain && RuleOutMarksWithForcedChain(sudoku, sudokuArray, fieldmarks))
            {
                i = CheckForAndRateSolvableField(sudoku, sudokuArray, fieldmarks);
                if (i != 0)
                {
                    return i * 8;
                }
            }

            return 0;
        }

        public static bool SolveOneField(Sudoku sudoku, int[,] sudokuArray)
        {
            return SolveOneField(sudoku, sudokuArray, true, true, true, true, true);
        }

        public static bool SolveOneField(Sudoku sudoku, int[,] sudokuArray, bool useGroupChains, bool useFish, bool useNakedAndHiddenGroups, bool useForcedChain, bool doubleCheck)
        {
            var fieldmarks = CreateFieldMarkArray(sudoku, sudokuArray, true);

            if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
            {
                return true;
            }

            while (useGroupChains && RuleOutOuterMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (useGroupChains && RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (useNakedAndHiddenGroups && RuleOutMarksWithNakedOrHiddenGroups(sudoku, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (useFish && RuleOutMarksWithFish(sudoku, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (useForcedChain && RuleOutMarksWithForcedChain(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }
            //double check

            while (doubleCheck && useGroupChains && RuleOutOuterMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (doubleCheck && useGroupChains && RuleOutInnerMarksWithGroupChains(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (doubleCheck && useNakedAndHiddenGroups && RuleOutMarksWithNakedOrHiddenGroups(sudoku, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (doubleCheck && useFish && RuleOutMarksWithFish(sudoku, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            while (doubleCheck && useForcedChain && RuleOutMarksWithForcedChain(sudoku, sudokuArray, fieldmarks))
            {
                if (CheckForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool SolveSudokuGrid(Sudoku sudoku, int[,] sudokuArray)
        {
            return SolveSudokuGrid(sudoku, sudokuArray, true, true, true, true, true, true);
        }

        public static bool SolveSudokuGrid(Sudoku sudoku, int[,] sudokuArray, bool useGroupChains, bool useFish, bool useNakedAndHiddenGroups, bool useForcedChain, bool doubleCheck, bool useBruteForce)
        {
            while (true)
            {
                if (!SolveOneField(sudoku, sudokuArray, useGroupChains, useFish, useNakedAndHiddenGroups, useForcedChain, doubleCheck))
                {
                    if (useBruteForce)
                    {
                        return SolveWithBruteForce(sudoku, sudokuArray);
                    }
                    return false;
                }
                if (CheckIfComplete(sudokuArray))
                {
                    return true;
                }
            }
        }

        public static bool SolveWithBruteForce(Sudoku sudoku, int[,] sudokuArray)
        {
            return SolveWithBruteForce(sudoku, sudokuArray, GetCoordinateListOfEmptyFields(sudokuArray));
        }

        public static bool SolveWithBruteForce(Sudoku sudoku, int[,] sudokuArray, List<int[]> emptyFieldCoordinateList)
        {
            var intList = sudoku.GetListOfAllIntegers();

            var coordinateList = emptyFieldCoordinateList;

            for (int n = 0; n < coordinateList.Count;)
            {
                if (n < 0)
                {
                    return false;
                }
                var coordinate = coordinateList[n];
                var previousValue = sudokuArray[coordinate[0], coordinate[1]];
                sudokuArray[coordinate[0], coordinate[1]] = 0;
                var index = intList.IndexOf(previousValue) + 1;
                for (int i = index; i <= intList.Count; i++)
                {
                    if (i == intList.Count)
                    {
                        n -= 1;
                        break;
                    }
                    if (CheckIfAssignable(sudoku, sudokuArray, coordinate, intList[i]))
                    {
                        sudokuArray[coordinate[0], coordinate[1]] = intList[i];
                        n += 1;
                        break;
                    }
                }
            }

            return true;
        }

        private static bool CheckBoxForSolvableField(Sudoku sudoku, int[,] sudokuArray, int[][] box, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();
            foreach (int j in intList)
            {
                var possibleFields = new List<int[]>();
                foreach (var f in box)
                {
                    if (fieldmarks[f[0], f[1]].Contains(j))
                    {
                        possibleFields.Add(f);
                    }
                }
                if (possibleFields.Count == 1)
                {
                    sudokuArray[possibleFields[0][0], possibleFields[0][1]] = j;
                    return true;
                }
            }
            return false;
        }

        private static bool CheckColumnForSolvableField(Sudoku sudoku, int[,] sudokuArray, int column, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();
            foreach (int j in intList)
            {
                var possibleFields = new List<int>();
                for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                {
                    if (fieldmarks[column, i].Contains(j))
                    {
                        possibleFields.Add(i);
                    }
                }
                if (possibleFields.Count == 1)
                {
                    sudokuArray[column, possibleFields[0]] = j;
                    return true;
                }
            }
            return false;
        }

        private static bool CheckDiagonalsForSolvableField(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();
            foreach (int j in intList)
            {
                var possibleFields = new List<int>();
                for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                {
                    if (fieldmarks[i, i].Contains(j))
                    {
                        possibleFields.Add(i);
                    }
                }
                if (possibleFields.Count == 1)
                {
                    sudokuArray[possibleFields[0], possibleFields[0]] = j;
                    return true;
                }

                possibleFields = new List<int>();
                for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                {
                    if (fieldmarks[i, sudoku.fieldsPerRowAmount - 1 - i].Contains(j))
                    {
                        possibleFields.Add(i);
                    }
                }
                if (possibleFields.Count == 1)
                {
                    sudokuArray[possibleFields[0], sudoku.fieldsPerRowAmount - 1 - possibleFields[0]] = j;
                    return true;
                }
            }
            return false;
        }

        private static int CheckForAndRateSolvableField(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            foreach (var b in sudoku.SudokuBoxArrayList)
            {
                if (CheckBoxForSolvableField(sudoku, sudokuArray, b, fieldmarks))
                {
                    return 10;
                }
            }
            for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
            {
                if (CheckRowForSolvableField(sudoku, sudokuArray, i, fieldmarks))
                {
                    return 14;
                }
                if (CheckColumnForSolvableField(sudoku, sudokuArray, i, fieldmarks))
                {
                    return 14;
                }
            }

            if (sudoku.diagonalRows)
            {
                if (CheckDiagonalsForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return 16;
                }
            }

            if (CheckGridForSolvableField(sudoku, sudokuArray, fieldmarks))
            {
                return 25;
            }

            return 0;
        }

        private static bool CheckForSolvableField(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            if (CheckGridForSolvableField(sudoku, sudokuArray, fieldmarks))
            {
                return true;
            }

            foreach (var b in sudoku.SudokuBoxArrayList)
            {
                if (CheckBoxForSolvableField(sudoku, sudokuArray, b, fieldmarks))
                {
                    return true;
                }
            }
            for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
            {
                if (CheckRowForSolvableField(sudoku, sudokuArray, i, fieldmarks))
                {
                    return true;
                }
                if (CheckColumnForSolvableField(sudoku, sudokuArray, i, fieldmarks))
                {
                    return true;
                }
            }

            if (sudoku.diagonalRows)
            {
                if (CheckDiagonalsForSolvableField(sudoku, sudokuArray, fieldmarks))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckGridForSolvableField(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                {
                    while (fieldmarks[x, y].Contains(0))
                    {
                        RemoveMark(fieldmarks, new int[2] { x, y }, 0);
                    }
                    var l = fieldmarks[x, y];

                    if (l?.Length == 1)
                    {
                        sudokuArray[x, y] = l[0];
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckIfAscendingDiagonal(List<int[]> coordinateList, Sudoku sudoku)
        {
            if (coordinateList.Count == 0)
            {
                return false;
            }
            foreach (var cell in coordinateList)
            {
                if (cell[0] != sudoku.fieldsPerRowAmount - 1 - cell[1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfDescendingDiagonal(List<int[]> coordinateList, Sudoku sudoku)
        {
            if (coordinateList.Count == 0)
            {
                return false;
            }
            foreach (var cell in coordinateList)
            {
                if (cell[0] != cell[1])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfSameBox(List<int[]> coordinateList, Sudoku sudoku)
        {
            if (coordinateList.Count == 0)
            {
                return false;
            }
            var b = sudoku.GetBoxNumberOfCoordinate(coordinateList[0]);
            for (int i = 1; i < coordinateList.Count; i++)
            {
                if (sudoku.GetBoxNumberOfCoordinate(coordinateList[i]) != b)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfSameColumn(List<int[]> coordinateList)
        {
            if (coordinateList.Count == 0)
            {
                return false;
            }
            var row = coordinateList[0][0];
            for (int i = 1; i < coordinateList.Count; i++)
            {
                if (row != coordinateList[i][0])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckIfSameRow(List<int[]> coordinateList)
        {
            if (coordinateList.Count == 0)
            {
                return false;
            }
            var row = coordinateList[0][1];
            for (int i = 1; i < coordinateList.Count; i++)
            {
                if (row != coordinateList[i][1])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckRowForSolvableField(Sudoku sudoku, int[,] sudokuArray, int row, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();
            foreach (int j in intList)
            {
                var possibleFields = new List<int>();
                for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
                {
                    if (fieldmarks[i, row].Contains(j))
                    {
                        possibleFields.Add(i);
                    }
                }
                if (possibleFields.Count == 1)
                {
                    sudokuArray[possibleFields[0], row] = j;
                    return true;
                }
            }
            return false;
        }

        private static List<List<int>> CreateListOfAllCombinations(List<int> intList, int minimumAmount, int maximumAmount)
        {
            double combinationAmount = Math.Pow(2, intList.Count);

            var allCombinationsList = new List<List<int>>();

            for (int i = 1; i <= combinationAmount - 1; i++)
            {
                var amount = 0;
                var newCombination = new List<int>();
                string str = Convert.ToString(i, 2).PadLeft(intList.Count, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        newCombination.Add(intList[j]);
                        amount += 1;
                        if (amount > maximumAmount)
                        {
                            break;
                        }
                    }
                }
                if (amount >= minimumAmount && amount <= maximumAmount)
                {
                    allCombinationsList.Add(newCombination);
                }
            }

            return allCombinationsList;
        }

        private static List<int[]> CreateListOfCoordinatesContainedInBothLists(List<int[]> coordinateListA, List<int[]> coordinateListB)
        {
            var newCoordinateList = new List<int[]>();
            foreach (var ca in coordinateListA)
            {
                foreach (var cb in coordinateListB)
                {
                    if (ca[0] == cb[0] && ca[1] == cb[1])
                    {
                        newCoordinateList.Add(ca);
                    }
                }
            }
            return newCoordinateList;
        }

        private static List<int[]> CreateListOfFieldsRuledOutByAllScenarios(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks, int integer, List<int[]> coordinateList)
        {
            if (coordinateList.Count == 0)
            {
                return new List<int[]>();
            }

            var ruledOutFieldsListList = new List<List<int[]>>();

            foreach (var coordinate in coordinateList)
            {
                var newSudokuArray = CopySudoku(sudokuArray);
                newSudokuArray[coordinate[0], coordinate[1]] = integer;
                var newFieldArray = CreateFieldMarkArray(sudoku, newSudokuArray, false);
                while (RuleOutOuterMarksWithGroupChains(sudoku, newSudokuArray, newFieldArray))
                {
                }
                while (RuleOutInnerMarksWithGroupChains(sudoku, newSudokuArray, newFieldArray))
                {
                }
                var ruledOutCoordinatesList = CreateListOfRuledOutFieldmarkCoordinates(fieldmarks, newFieldArray, integer);
                for (int i = ruledOutCoordinatesList.Count - 1; i >= 0; i--)
                {
                    if (CheckIfCoordinateListContainsCoordinate(coordinateList, ruledOutCoordinatesList[i]))
                    {
                        ruledOutCoordinatesList.RemoveAt(i);
                    }
                }
                ruledOutFieldsListList.Add(ruledOutCoordinatesList);
            }

            for (int i = 1; i < ruledOutFieldsListList.Count; i++)
            {
                ruledOutFieldsListList[0] = CreateListOfCoordinatesContainedInBothLists(ruledOutFieldsListList[0], ruledOutFieldsListList[i]);
            }

            return ruledOutFieldsListList[0];
        }

        private static List<int[]> CreateListOfFieldsRuledOutByAllScenariosInBox(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks, int integer, int box)
        {
            var boxMarkList = GetListOfAllCoordinatesWithSpecificIntegerMarkInBox(sudoku, fieldmarks, integer, box);

            return CreateListOfFieldsRuledOutByAllScenarios(sudoku, sudokuArray, fieldmarks, integer, boxMarkList);
        }

        private static List<int[]> CreateListOfFieldsRuledOutByAllScenariosInColumn(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks, int integer, int column)
        {
            var columnMarkList = GetListOfAllCoordinatesWithSpecificIntegerMarkInColumn(sudoku, fieldmarks, integer, column);

            return CreateListOfFieldsRuledOutByAllScenarios(sudoku, sudokuArray, fieldmarks, integer, columnMarkList);
        }

        private static List<int[]> CreateListOfFieldsRuledOutByAllScenariosInDiagonals(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks, int integer)
        {
            var ascendingDiagonalMarkList = GetListOfAllCoordinatesWithSpecificIntegerMarkInAscendingDiagonal(sudoku, fieldmarks, integer);
            var descendingDiagonalMarkList = GetListOfAllCoordinatesWithSpecificIntegerMarkInDescendingDiagonal(sudoku, fieldmarks, integer);
            var ruledOutList = CreateListOfFieldsRuledOutByAllScenarios(sudoku, sudokuArray, fieldmarks, integer, ascendingDiagonalMarkList);
            ruledOutList.AddRange(CreateListOfFieldsRuledOutByAllScenarios(sudoku, sudokuArray, fieldmarks, integer, descendingDiagonalMarkList));
            return ruledOutList;
        }

        private static List<int[]> CreateListOfFieldsRuledOutByAllScenariosInRow(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks, int integer, int row)
        {
            var rowMarkList = GetListOfAllCoordinatesWithSpecificIntegerMarkInRow(sudoku, fieldmarks, integer, row);

            return CreateListOfFieldsRuledOutByAllScenarios(sudoku, sudokuArray, fieldmarks, integer, rowMarkList);
        }

        private static List<int[]> CreateListOfRuledOutFieldmarkCoordinates(int[,][] originalFieldmarks, int[,][] newFieldmarks, int integer)
        {
            var coordinateList = new List<int[]>();

            for (int x = 0; x < originalFieldmarks.GetLength(0); x++)
            {
                for (int y = 0; y < originalFieldmarks.GetLength(1); y++)
                {
                    if (originalFieldmarks[x, y].Contains(integer) && (!newFieldmarks[x, y].Contains(integer)))
                    {
                        coordinateList.Add(new int[2] { x, y });
                    }
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetHiddenGroup(List<int[]> fieldList, List<int> combination)
        {
            var hiddenGroup = new List<int[]>();
            foreach (var field in fieldList)
            {
                foreach (int i in combination)
                {
                    if (field.Contains(i))
                    {
                        hiddenGroup.Add(field);
                        break;
                    }
                }
            }
            if (hiddenGroup.Count == combination.Count)
            {
                return hiddenGroup;
            }

            return null;
        }

        private static List<int> GetListOfAllColumnsWithSpecificIntegerMarkInRow(int[,][] fieldmarks, int integer, int row)
        {
            var columnList = new List<int>();

            for (int x = 0; x < fieldmarks.GetLength(0); x++)
            {
                if (fieldmarks[x, row].Contains(integer))
                {
                    columnList.Add(x);
                }
            }

            return columnList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMark(Sudoku sudoku, int[,][] fieldmarks, int integer)
        {
            var coordinateList = new List<int[]>();

            for (int x = 0; x < fieldmarks.GetLength(0); x++)
            {
                for (int y = 0; y < fieldmarks.GetLength(1); y++)
                {
                    if (fieldmarks[x, y].Contains(integer))
                    {
                        coordinateList.Add(new int[2] { x, y });
                    }
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMarkInAscendingDiagonal(Sudoku sudoku, int[,][] fieldmarks, int integer)
        {
            var coordinateList = new List<int[]>();

            for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
            {
                if (fieldmarks[sudoku.fieldsPerRowAmount - 1 - xy, xy].Contains(integer))
                {
                    var coordinate = new int[2] { sudoku.fieldsPerRowAmount - 1 - xy, xy };
                    coordinateList.Add(coordinate);
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMarkInBox(Sudoku sudoku, int[,][] fieldmarks, int integer, int box)
        {
            var coordinateList = new List<int[]>();

            for (int x = 0; x < fieldmarks.GetLength(0); x++)
            {
                for (int y = 0; y < fieldmarks.GetLength(1); y++)
                {
                    if (fieldmarks[x, y].Contains(integer))
                    {
                        var coordinate = new int[2] { x, y };
                        if (sudoku.GetBoxNumberOfCoordinate(coordinate) == box)
                        {
                            coordinateList.Add(coordinate);
                        }
                    }
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMarkInColumn(Sudoku sudoku, int[,][] fieldmarks, int integer, int column)
        {
            var coordinateList = new List<int[]>();

            for (int y = 0; y < fieldmarks.GetLength(1); y++)
            {
                if (fieldmarks[column, y].Contains(integer))
                {
                    var coordinate = new int[2] { column, y };
                    coordinateList.Add(coordinate);
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMarkInDescendingDiagonal(Sudoku sudoku, int[,][] fieldmarks, int integer)
        {
            var coordinateList = new List<int[]>();

            for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
            {
                if (fieldmarks[xy, xy].Contains(integer))
                {
                    var coordinate = new int[2] { xy, xy };
                    coordinateList.Add(coordinate);
                }
            }

            return coordinateList;
        }

        private static List<int[]> GetListOfAllCoordinatesWithSpecificIntegerMarkInRow(Sudoku sudoku, int[,][] fieldmarks, int integer, int row)
        {
            var coordinateList = new List<int[]>();

            for (int x = 0; x < fieldmarks.GetLength(0); x++)
            {
                if (fieldmarks[x, row].Contains(integer))
                {
                    var coordinate = new int[2] { x, row };
                    coordinateList.Add(coordinate);
                }
            }

            return coordinateList;
        }

        private static List<int> GetListOfAllRowsWithSpecificIntegerMarkInColumn(int[,][] fieldmarks, int integer, int column)
        {
            var rowList = new List<int>();

            for (int y = 0; y < fieldmarks.GetLength(0); y++)
            {
                if (fieldmarks[column, y].Contains(integer))
                {
                    rowList.Add(y);
                }
            }

            return rowList;
        }

        private static List<int> GetListOfAssignableValues(Sudoku sudoku, int[,] sudokuArray, int[] coordinate)
        {
            var l = new List<int>();
            foreach (var i in sudoku.GetListOfAllIntegers())
            {
                if (CheckIfAssignable(sudoku, sudokuArray, coordinate, i))
                {
                    l.Add(i);
                }
            }
            return l;
        }

        private static void RemoveMark(int[,][] fieldmarks, int[] coordinate, int integer)
        {
            if (!fieldmarks[coordinate[0], coordinate[1]].Contains(integer))
            {
                return;
            }

            var l = fieldmarks[coordinate[0], coordinate[1]].ToList<int>();
            l.Remove(integer);
            fieldmarks[coordinate[0], coordinate[1]] = l.ToArray();
        }

        private static void RemoveMark(int[] field, int integer)
        {
            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == integer)
                {
                    field[i] = 0;
                }
            }
        }

        private static void RemoveMarks(int[,][] fieldmarks, List<int[]> coordinateList, int integer)
        {
            foreach (var coordinate in coordinateList)
            {
                RemoveMark(fieldmarks, coordinate, integer);
            }
        }

        private static bool RemoveMarksIfFishExist(int[,][] fieldmarks, List<List<int>> combinationList, int integer)
        {
            var ruleOutPositive = false;

            foreach (var combination in combinationList)
            {
                var columnList = combination;
                var rowList = new List<int>();

                foreach (var col in columnList)
                {
                    var rows = GetListOfAllRowsWithSpecificIntegerMarkInColumn(fieldmarks, integer, col);
                    if (rows.Count == 0)
                    {
                        rowList = null;
                    }
                    rowList?.AddRange(rows);
                }
                rowList = rowList?.Distinct().ToList();

                if (columnList.Count == rowList?.Count)
                {
                    foreach (var row in rowList)
                    {
                        for (int x = 0; x < fieldmarks.GetLength(0); x++)
                        {
                            if (fieldmarks[x, row].Contains(integer) && !columnList.Contains(x))
                            {
                                RemoveMark(fieldmarks, new int[2] { x, row }, integer);
                                ruleOutPositive = true;
                            }
                        }
                    }
                }

                rowList = combination;
                columnList = new List<int>();

                foreach (var row in rowList)
                {
                    var cols = GetListOfAllColumnsWithSpecificIntegerMarkInRow(fieldmarks, integer, row);
                    if (cols.Count == 0)
                    {
                        columnList = null;
                    }
                    columnList?.AddRange(cols);
                }
                columnList = columnList?.Distinct().ToList();

                if (columnList?.Count == rowList.Count)
                {
                    foreach (var column in columnList)
                    {
                        for (int y = 0; y < fieldmarks.GetLength(1); y++)
                        {
                            if (fieldmarks[column, y].Contains(integer) && !rowList.Contains(y))
                            {
                                RemoveMark(fieldmarks, new int[2] { column, y }, integer);
                                ruleOutPositive = true;
                            }
                        }
                    }
                }
            }

            return ruleOutPositive;
        }

        private static bool RemoveMarksIfHiddenGroupExists(List<int[]> fieldList)
        {
            var ruleOutPositive = false;

            var intList = new List<int>();

            foreach (var field in fieldList)
            {
                foreach (var i in field)
                {
                    if (i != 0 && !intList.Contains(i))
                    {
                        intList.Add(i);
                    }
                }
            }

            var combinationList = CreateListOfAllCombinations(intList, 2, 4);

            foreach (var combination in combinationList)
            {
                var hiddenGroup = GetHiddenGroup(fieldList, combination);
                if (hiddenGroup != null)
                {
                    for (int f = 0; f < hiddenGroup.Count; f++)
                    {
                        for (int i = hiddenGroup[f].Length - 1; i >= 0; i--)
                        {
                            var value = hiddenGroup[f][i];
                            if (value != 0 && !combination.Contains(value))
                            {
                                RemoveMark(hiddenGroup[f], value);
                                ruleOutPositive = true;
                            }
                        }
                    }
                }
            }

            return ruleOutPositive;
        }

        private static bool RuleOutInnerMarksWithGroupChains(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();

            var ruleOutPositive = false;

            foreach (int i in intList)
            {
                var boxfieldsWithMarkList = new List<List<int[]>>();

                for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
                {
                    var coordinateList = new List<int[]>();
                    for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                    {
                        if (fieldmarks[x, y].Contains(i))
                        {
                            coordinateList.Add(new int[2] { x, y });
                        }
                    }

                    if (CheckIfSameBox(coordinateList, sudoku))
                    {
                        var boxArray = sudoku.GetBoxArrayOfCoordinate(coordinateList[0]);
                        foreach (var cell in boxArray)
                        {
                            if (!CheckIfCoordinateListContainsCoordinate(coordinateList, cell))
                            {
                                if (fieldmarks[cell[0], cell[1]].Contains(i))
                                {
                                    RemoveMark(fieldmarks, cell, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                    }
                }

                for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                {
                    var coordinateList = new List<int[]>();
                    for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
                    {
                        if (fieldmarks[x, y].Contains(i))
                        {
                            coordinateList.Add(new int[2] { x, y });
                        }
                    }

                    if (CheckIfSameBox(coordinateList, sudoku))
                    {
                        var boxArray = sudoku.GetBoxArrayOfCoordinate(coordinateList[0]);
                        foreach (var cell in boxArray)
                        {
                            if (!CheckIfCoordinateListContainsCoordinate(coordinateList, cell))
                            {
                                if (fieldmarks[cell[0], cell[1]].Contains(i))
                                {
                                    RemoveMark(fieldmarks, cell, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                    }
                }

                if (sudoku.diagonalRows)
                {
                    var coordinateList = new List<int[]>();

                    for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
                    {
                        if (fieldmarks[xy, xy].Contains(i))
                        {
                            coordinateList.Add(new int[2] { xy, xy });
                        }
                    }

                    if (CheckIfSameBox(coordinateList, sudoku))
                    {
                        var boxArray = sudoku.GetBoxArrayOfCoordinate(coordinateList[0]);
                        foreach (var cell in boxArray)
                        {
                            if (!CheckIfCoordinateListContainsCoordinate(coordinateList, cell))
                            {
                                if (fieldmarks[cell[0], cell[1]].Contains(i))
                                {
                                    RemoveMark(fieldmarks, cell, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                    }

                    coordinateList = new List<int[]>();

                    for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
                    {
                        if (fieldmarks[xy, sudoku.fieldsPerRowAmount - 1 - xy].Contains(i))
                        {
                            coordinateList.Add(new int[2] { xy, sudoku.fieldsPerRowAmount - 1 - xy });
                        }
                    }

                    if (CheckIfSameBox(coordinateList, sudoku))
                    {
                        var boxArray = sudoku.GetBoxArrayOfCoordinate(coordinateList[0]);
                        foreach (var cell in boxArray)
                        {
                            if (!CheckIfCoordinateListContainsCoordinate(coordinateList, cell))
                            {
                                if (fieldmarks[cell[0], cell[1]].Contains(i))
                                {
                                    RemoveMark(fieldmarks, cell, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                    }
                }
            }

            return ruleOutPositive;
        }

        private static bool RuleOutMarksWithFish(Sudoku sudoku, int[,][] fieldmarks)
        {
            var ruleOutPositive = false;

            var indexList = new List<int>();
            for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
            {
                indexList.Add(i);
            }
            var indexCombinationList = CreateListOfAllCombinations(indexList, 2, 4);

            var intList = sudoku.GetListOfAllIntegers();

            foreach (var i in intList)
            {
                if (RemoveMarksIfFishExist(fieldmarks, indexCombinationList, i))
                {
                    ruleOutPositive = true;
                }
            }

            return ruleOutPositive;
        }

        private static bool RuleOutMarksWithForcedChain(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            var ruleOutPositive = false;

            foreach (int i in sudoku.GetListOfAllIntegers())
            {
                var markList = GetListOfAllCoordinatesWithSpecificIntegerMark(sudoku, fieldmarks, i);
                if (markList.Count > 0)
                {
                    List<int[]> ruledOutCoordinatesList;

                    for (int b = 0; b < sudoku.fieldsPerRowAmount; b++)
                    {
                        ruledOutCoordinatesList = CreateListOfFieldsRuledOutByAllScenariosInBox(sudoku, sudokuArray, fieldmarks, i, b);
                        if (ruledOutCoordinatesList.Count > 0)
                        {
                            ruleOutPositive = true;
                            RemoveMarks(fieldmarks, ruledOutCoordinatesList, i);
                        }

                        ruledOutCoordinatesList = CreateListOfFieldsRuledOutByAllScenariosInColumn(sudoku, sudokuArray, fieldmarks, i, b);
                        if (ruledOutCoordinatesList.Count > 0)
                        {
                            ruleOutPositive = true;
                            RemoveMarks(fieldmarks, ruledOutCoordinatesList, i);
                        }

                        ruledOutCoordinatesList = CreateListOfFieldsRuledOutByAllScenariosInRow(sudoku, sudokuArray, fieldmarks, i, b);
                        if (ruledOutCoordinatesList.Count > 0)
                        {
                            ruleOutPositive = true;
                            RemoveMarks(fieldmarks, ruledOutCoordinatesList, i);
                        }
                    }
                    if (sudoku.diagonalRows)
                    {
                        ruledOutCoordinatesList = CreateListOfFieldsRuledOutByAllScenariosInDiagonals(sudoku, sudokuArray, fieldmarks, i);
                        if (ruledOutCoordinatesList.Count > 0)
                        {
                            ruleOutPositive = true;
                            RemoveMarks(fieldmarks, ruledOutCoordinatesList, i);
                        }
                    }
                }
            }

            return ruleOutPositive;
        }

        private static bool RuleOutMarksWithNakedOrHiddenGroups(Sudoku sudoku, int[,][] fieldmarks)
        {
            var ruleOutPositive = false;

            for (int x = 0; x < fieldmarks.GetLength(0); x++)
            {
                var fieldList = new List<int[]>();
                for (int y = 0; y < fieldmarks.GetLength(1); y++)
                {
                    if (fieldmarks[x, y].Length > 0)
                    {
                        fieldList.Add(fieldmarks[x, y]);
                    }
                }
                if (RemoveMarksIfHiddenGroupExists(fieldList))
                {
                    ruleOutPositive = true;
                }
            }

            for (int y = 0; y < fieldmarks.GetLength(1); y++)
            {
                var fieldList = new List<int[]>();
                for (int x = 0; x < fieldmarks.GetLength(0); x++)
                {
                    if (fieldmarks[x, y].Length > 0)
                    {
                        fieldList.Add(fieldmarks[x, y]);
                    }
                }
                if (RemoveMarksIfHiddenGroupExists(fieldList))
                {
                    ruleOutPositive = true;
                }
            }

            if (sudoku.diagonalRows)
            {
                var descendingFieldList = new List<int[]>();
                var ascendingFieldList = new List<int[]>();
                for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
                {
                    if (fieldmarks[xy, xy].Length > 0)
                    {
                        descendingFieldList.Add(fieldmarks[xy, xy]);
                        ascendingFieldList.Add(fieldmarks[sudoku.fieldsPerRowAmount - 1 - xy, xy]);
                    }
                }
                if (RemoveMarksIfHiddenGroupExists(descendingFieldList))
                {
                    ruleOutPositive = true;
                }
                if (RemoveMarksIfHiddenGroupExists(ascendingFieldList))
                {
                    ruleOutPositive = true;
                }
            }

            foreach (var boxArray in sudoku.SudokuBoxArrayList)
            {
                var fieldList = new List<int[]>();
                for (int i = 0; i < boxArray.Length; i++)
                {
                    if (boxArray[i].Length > 0)
                    {
                        fieldList.Add(fieldmarks[boxArray[i][0], boxArray[i][1]]);
                    }
                }
                if (RemoveMarksIfHiddenGroupExists(fieldList))
                {
                    ruleOutPositive = true;
                }
            }

            return ruleOutPositive;
        }

        private static bool RuleOutOuterMarksWithGroupChains(Sudoku sudoku, int[,] sudokuArray, int[,][] fieldmarks)
        {
            var intList = sudoku.GetListOfAllIntegers();

            var ruleOutPositive = false;

            foreach (int i in intList)
            {
                var boxfieldsWithMarkList = new List<List<int[]>>();

                for (int b = 0; b < sudoku.fieldsPerRowAmount; b++)
                {
                    boxfieldsWithMarkList.Add(new List<int[]>());
                }

                for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
                {
                    for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                    {
                        if (fieldmarks[x, y].Contains(i))
                        {
                            var c = new int[2] { x, y };
                            boxfieldsWithMarkList[sudoku.GetBoxNumberOfCoordinate(c)].Add(c);
                        }
                    }
                }
                for (int b = 0; b < sudoku.fieldsPerRowAmount; b++)
                {
                    if (CheckIfSameRow(boxfieldsWithMarkList[b]))
                    {
                        var y = boxfieldsWithMarkList[b][0][1];
                        for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
                        {
                            var c = new int[2] { x, y };
                            if (fieldmarks[x, y].Contains(i) && sudoku.GetBoxNumberOfCoordinate(c) != b)
                            {
                                RemoveMark(fieldmarks, c, i);
                                ruleOutPositive = true;
                            }
                        }
                    }
                    if (CheckIfSameColumn(boxfieldsWithMarkList[b]))
                    {
                        var x = boxfieldsWithMarkList[b][0][0];
                        for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                        {
                            var c = new int[2] { x, y };
                            if (fieldmarks[x, y].Contains(i) && sudoku.GetBoxNumberOfCoordinate(c) != b)
                            {
                                RemoveMark(fieldmarks, c, i);
                                ruleOutPositive = true;
                            }
                        }
                    }
                    if (sudoku.diagonalRows)
                    {
                        if (CheckIfDescendingDiagonal(boxfieldsWithMarkList[b], sudoku))
                        {
                            for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
                            {
                                var c = new int[2] { xy, xy };
                                if (fieldmarks[c[0], c[1]].Contains(i) && sudoku.GetBoxNumberOfCoordinate(c) != b)
                                {
                                    RemoveMark(fieldmarks, c, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                        if (CheckIfAscendingDiagonal(boxfieldsWithMarkList[b], sudoku))
                        {
                            for (int xy = 0; xy < sudoku.fieldsPerRowAmount; xy++)
                            {
                                var c = new int[2] { xy, sudoku.fieldsPerRowAmount - 1 - xy };
                                if (fieldmarks[c[0], c[1]].Contains(i) && sudoku.GetBoxNumberOfCoordinate(c) != b)
                                {
                                    RemoveMark(fieldmarks, c, i);
                                    ruleOutPositive = true;
                                }
                            }
                        }
                    }
                }
            }

            return ruleOutPositive;
        }
    }
}