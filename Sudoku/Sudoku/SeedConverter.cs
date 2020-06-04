using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal static class SeedConverter
    {
        public static string ConvertSeedIntoRandomGridCode(int fieldsPerRowAmount, Difficulty difficulty, bool diagonalRows, string seed)
        {
            var fieldSeedArray = new string[fieldsPerRowAmount, fieldsPerRowAmount];
            var seedArray = seed.Split('|');
            var fieldSeeds = seedArray[1].Split('.');

            var gridCode = $"{fieldsPerRowAmount}.{fieldsPerRowAmount},{difficulty},{seedArray[0]},{diagonalRows}";

            for (int i = 0; i < fieldSeeds.Length; i++)
            {
                fieldSeedArray[i / fieldsPerRowAmount, i % fieldsPerRowAmount] = fieldSeeds[i];
            }

            var random = new Random();
            RotateStringArray(fieldSeedArray, random.Next(0, 4));
            if (random.Next(0, 2) == 1)
            {
                MirrorStringArray(fieldSeedArray);
            }

            gridCode += $"|{ConvertFieldSeedArrayIntoFieldData(fieldSeedArray)}";

            return gridCode;
        }

        public static string ConvertSudokuIntoSeed(Sudoku sudoku)
        {
            var completeArray = sudoku.GetCopyOfCompleteSudokuArray();
            var incompleteArray = sudoku.SudokuIncompleteArray;
            var fieldSeedList = new List<string>();

            for (int x = 0; x < completeArray.GetLength(0); x++)
            {
                for (int y = 0; y < completeArray.GetLength(1); y++)
                {
                    var s = $"{Convert.ToChar(64 + incompleteArray[x, y])}{Convert.ToChar(64 + completeArray[x, y])}{Convert.ToChar(64 + sudoku.GetBoxNumberOfCoordinate(new int[2] { x, y }))}";
                    fieldSeedList.Add(s);
                }
            }

            var fieldSeed = String.Join(".", fieldSeedList);
            var gridSeed = $"{sudoku.rating}";
            return $"{gridSeed}|{fieldSeed}";
        }

        public static string GenerateSudokuAndGetSeed(int fieldsPerRowAmount, Difficulty difficulty, bool diagonalRows, bool randomBoxFormation)
        {
            var sudoku = new Sudoku(fieldsPerRowAmount, difficulty, diagonalRows, randomBoxFormation);
            return ConvertSudokuIntoSeed(sudoku);
        }

        public static string GetRandomSeed(int fieldsPerRowAmount, Difficulty difficulty, bool diagonalRows)
        {
            List<string> seedList = new List<string>();
            switch (fieldsPerRowAmount)
            {
                case 9:
                    switch (difficulty)
                    {
                        case Difficulty.Easy:
                            if (diagonalRows)
                            {
                                seedList = Properties.Resources.EasyTrue.Split(Convert.ToChar(10)).ToList();
                            }
                            else
                            {
                                seedList = Properties.Resources.EasyFalse.Split(Convert.ToChar(10)).ToList();
                            }
                            break;

                        case Difficulty.Normal:
                            if (diagonalRows)
                            {
                                seedList = Properties.Resources.NormalTrue.Split(Convert.ToChar(10)).ToList();
                            }
                            else
                            {
                                seedList = Properties.Resources.NormalFalse.Split(Convert.ToChar(10)).ToList();
                            }
                            break;

                        case Difficulty.Hard:
                            if (diagonalRows)
                            {
                                seedList = Properties.Resources.HardTrue.Split(Convert.ToChar(10)).ToList();
                            }
                            else
                            {
                                seedList = Properties.Resources.HardFalse.Split(Convert.ToChar(10)).ToList();
                            }
                            break;

                        case Difficulty.VeryHard:
                            if (diagonalRows)
                            {
                                seedList = Properties.Resources.VeryHardTrue.Split(Convert.ToChar(10)).ToList();
                            }
                            else
                            {
                                seedList = Properties.Resources.VeryHardFalse.Split(Convert.ToChar(10)).ToList();
                            }
                            break;

                        case Difficulty.ExtremelyHard:
                            if (diagonalRows)
                            {
                                seedList = Properties.Resources.ExtremelyHardTrue.Split(Convert.ToChar(10)).ToList();
                            }
                            else
                            {
                                seedList = Properties.Resources.ExtremelyHardFalse.Split(Convert.ToChar(10)).ToList();
                            }
                            break;
                    }
                    break;
            }
            return seedList[new Random().Next(0, seedList.Count - 1)];
        }

        private static string ConvertFieldSeedArrayIntoFieldData(string[,] fieldSeedArray)
        {
            var fieldDataList = new List<string>();
            var intList = new List<int>();
            for (int i = 1; i <= fieldSeedArray.GetLength(0); i++)
            {
                intList.Add(i);
            }
            intList = RandomizeList(intList);
            intList.Insert(0, 0);

            for (int x = 0; x < fieldSeedArray.GetLength(0); x++)
            {
                for (int y = 0; y < fieldSeedArray.GetLength(1); y++)
                {
                    var fs = fieldSeedArray[x, y];
                    var fieldData = $"{x}.{y},{intList[Convert.ToInt32(fs[0] - 64)]},{intList[Convert.ToInt32(fs[1] - 64)]},{(fs[0] != Convert.ToChar(64)).ToString()},{ Convert.ToInt32(fs[2]) - 64}";

                    fieldDataList.Add(fieldData);
                }
            }

            return String.Join(";", fieldDataList);
        }

        private static void MirrorStringArray(string[,] stringArray)
        {
            var modelArray = new string[stringArray.GetLength(0), stringArray.GetLength(1)];
            Array.Copy(stringArray, modelArray, stringArray.Length);

            for (int x = 0; x < modelArray.GetLength(0); x++)
            {
                for (int y = 0; y < modelArray.GetLength(1); y++)
                {
                    stringArray[modelArray.GetLength(0) - 1 - x, y] = modelArray[x, y];
                }
            }
        }

        private static List<int> RandomizeList(List<int> list)
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

        private static void RotateStringArray(string[,] stringArray, int rotations)
        {
            var modelArray = new string[stringArray.GetLength(0), stringArray.GetLength(1)];
            Array.Copy(stringArray, modelArray, stringArray.Length);

            for (int x = 0; x < modelArray.GetLength(0); x++)
            {
                for (int y = 0; y < modelArray.GetLength(1); y++)
                {
                    int[] coordinate = new int[2] { x, y };

                    for (int i = 0; i < rotations; i++)
                    {
                        var newCoordinate = new int[2] { coordinate[1], modelArray.GetLength(0) - 1 - coordinate[0] };
                        coordinate = newCoordinate;
                    }

                    stringArray[coordinate[0], coordinate[1]] = modelArray[x, y];
                }
            }
        }
    }
}