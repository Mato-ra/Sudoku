using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        VeryHard,
        ExtremelyHard,
        Custom,
        Random,
    }

    public partial class SudokuForm : Form
    {
        private Sudoku CurrentSudoku;
        private int hints = 0;
        private string path;
        private SaveForm saveForm;
        private DateTime startTime;
        private Timer timer;

        public SudokuForm(int fieldsPerRow, Difficulty difficulty, bool diagonalRows, bool randomBoxFormation)
        {
            InitializeComponent();
            this.CurrentSudoku = new Sudoku(9, difficulty, diagonalRows, false);
            PrepareControls();
        }

        public SudokuForm(Sudoku sudoku, string path)
        {
            InitializeComponent();
            this.path = path;
            this.Text = $"Sudoku - {path}";
            this.CurrentSudoku = sudoku;
            PrepareControls();
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void Btn_Rate_Click(object sender, EventArgs e)
        {
            if (CurrentSudoku.difficulty == Difficulty.Custom)
            {
                CurrentSudoku.rating = Solver.RateSudokuGrid(CurrentSudoku, GetSudokuGrid(CurrentSudoku));
                lbl_Difficulty.Text = $"difficulty: {CurrentSudoku.difficulty.ToString()} ({CurrentSudoku.rating})";
            }
        }

        private void Btn_ShowMistakes_Click(object sender, EventArgs e)
        {
            ShowMistakes();
        }

        private void Btn_SolveEntireGrid_Click(object sender, EventArgs e)
        {
            SolveSudokuGrid();
        }

        private void Btn_SolveOneField_Click(object sender, EventArgs e)
        {
            SolveOneField();
        }

        private void Confirm()
        {
            var sudokuArray1 = GetSudokuGrid(CurrentSudoku);
            var sudokuArray2 = CurrentSudoku.GetCopyOfCompleteSudokuArray();

            if (Solver.CheckIfComplete(sudokuArray2))
            {
                ConfirmIfSolutionIsCorrect(sudokuArray1, sudokuArray2);
            }
            if (!Solver.CheckIfComplete(sudokuArray2))
            {
                sudokuArray2 = Solver.CopySudoku(CurrentSudoku.SudokuIncompleteArray);

                if (Solver.SolveSudokuGrid(CurrentSudoku, sudokuArray2))
                {
                    CurrentSudoku.SetCompleteSudokuArray(sudokuArray2);
                    ConfirmIfSolutionIsCorrect(sudokuArray1, sudokuArray2);
                }
                else
                {
                    MessageBox.Show("This grid doesn't have a solution and couldn't be solved by the application's algorithm.", "No solution given");
                }
            }
        }

        private void ConfirmIfSolutionIsCorrect(int[,] submittedGrid, int[,] solutionGrid)
        {
            if (Solver.CompareSudokuGrids(submittedGrid, solutionGrid))
            {
                timer.Enabled = false;
                MessageBox.Show("Your solution is correct!", "Congrats!");
                return;
            }
            else
            {
                MessageBox.Show("Your solution is incorrect!", "Try again!");
                return;
            }
        }

        private List<Color> CreateBackColorList()
        {
            return new List<Color>
            {
                Color.IndianRed,
                Color.LightBlue,
                Color.Yellow,
                Color.Aqua,
            };
        }

        private void CreateSudokuGrid()
        {
            dgv_Sudoku.Font = new Font("Calibri", 21);
            dgv_Sudoku.Width = CurrentSudoku.fieldsPerRowAmount * 50 + 3;
            dgv_Sudoku.Height = CurrentSudoku.fieldsPerRowAmount * 50 + 3;
            this.Width = CurrentSudoku.fieldsPerRowAmount * 50 + 2 + 190;
            this.Height = CurrentSudoku.fieldsPerRowAmount * 50 + 2 + 90;
            for (int i = 0; i < CurrentSudoku.fieldsPerRowAmount; i++)
            {
                dgv_Sudoku.Columns.Add(i.ToString(), i.ToString());
                dgv_Sudoku.Columns[i].Width = 50;
                dgv_Sudoku.Rows.Add();
                dgv_Sudoku.Rows[i].Height = 50;
            }

            var colorList = CreateBackColorList();
            var colorAmount = 1;
            if (!CurrentSudoku.randomBoxFormation)
                colorAmount = CurrentSudoku.boxPerRowAmount - 1;

            for (int x = 0; x < CurrentSudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < CurrentSudoku.fieldsPerRowAmount; y++)
                {
                    dgv_Sudoku[x, y].Style.BackColor = colorList[CurrentSudoku.GetBoxNumberOfCoordinate(new int[2] { x, y }) % colorAmount];
                    dgv_Sudoku[x, y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (CurrentSudoku.SudokuIncompleteArray[x, y] != 0)
                    {
                        dgv_Sudoku[x, y].ReadOnly = true;
                        dgv_Sudoku[x, y].Style.ForeColor = Color.DarkGray;
                        dgv_Sudoku[x, y].Value = CurrentSudoku.SudokuIncompleteArray[x, y];
                    }
                    else
                    {
                        if (CurrentSudoku.SudokuFilledInArray[x, y] != 0)
                        {
                            dgv_Sudoku[x, y].Value = CurrentSudoku.SudokuFilledInArray[x, y];
                        }
                    }
                }
            }
        }

        private void CreateTimer()
        {
            timer = new Timer();
            startTime = DateTime.Now;
            timer.Enabled = true;
            timer.Tick += UpdateTime;
            timer.Interval = 125;
        }

        private void Dgv_Sudoku_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgv_Sudoku[e.ColumnIndex, e.RowIndex];
            if (!cell.ReadOnly && cell.Style.ForeColor != Color.Black)
            {
                cell.Style.ForeColor = Color.Black;
            }
        }

        private void Dgv_Sudoku_Scroll(object sender, ScrollEventArgs e)
        {
            dgv_Sudoku.FirstDisplayedScrollingRowIndex = 0;
        }

        private int[,] GetSudokuGrid(Sudoku sudoku)
        {
            return GetSudokuGrid(sudoku, true);
        }

        private int[,] GetSudokuGrid(Sudoku sudoku, bool includeReadonlyNumbers)
        {
            var sudokuArray = sudoku.CreateEmptySudokuArray();
            var intList = sudoku.CreateListOfAllIntegers();
            for (int x = 0; x < CurrentSudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < CurrentSudoku.fieldsPerRowAmount; y++)
                {
                    try
                    {
                        string s = "0";
                        if (includeReadonlyNumbers || !dgv_Sudoku[x, y].ReadOnly)
                        {
                            s = dgv_Sudoku[x, y].Value.ToString();
                        }

                        var v = Convert.ToInt32(s);
                        if (intList.Contains(v))
                        {
                            sudokuArray[x, y] = v;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return sudokuArray;
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void PrepareControls()
        {
            lbl_Difficulty.Text = $"difficulty: {CurrentSudoku.difficulty.ToString()} ({CurrentSudoku.rating})";
            lbl_DiagonalRows.Text = $"diagonal rows: {CurrentSudoku.diagonalRows.ToString()}";
            lbl_Hints.Text = $"hints: {hints}";
            CreateSudokuGrid();
            CreateTimer();
            if (CurrentSudoku.difficulty != Difficulty.Custom)
            {
                btn_Rate.Visible = false;
            }
        }

        private void ShowMistakes()
        {
            var completeArray = CurrentSudoku.GetCopyOfCompleteSudokuArray();
            if (!Solver.CheckIfComplete(completeArray))
            {
                var incompleteArray = Solver.CopySudoku(CurrentSudoku.SudokuIncompleteArray);
                if (!Solver.SolveSudokuGrid(CurrentSudoku, incompleteArray))
                {
                    MessageBox.Show("This grid doesn't have a solution to compare with and couldn't be solved by the application's algorithm.", "No solution given");
                    return;
                }
                else
                {
                    completeArray = incompleteArray;
                    CurrentSudoku.SetCompleteSudokuArray(completeArray);
                }
            }
            var mistakesList = Solver.CompareSudokuGridsAndFindMistakes(GetSudokuGrid(CurrentSudoku), completeArray);

            foreach (var mistake in mistakesList)
            {
                hints += 1;
                dgv_Sudoku[mistake[0], mistake[1]].Style.ForeColor = Color.Red;
            }
            lbl_Hints.Text = $"hints: {hints}";
        }

        private bool SolveOneField()
        {
            var sudokuArray = GetSudokuGrid(CurrentSudoku);
            var b = Solver.SolveOneField(CurrentSudoku, sudokuArray);
            if (b)
            {
                hints += 1;
                UpdateSudokuGrid(sudokuArray);
            }
            else
            {
                var completeSudokuArray = CurrentSudoku.GetCopyOfCompleteSudokuArray();
                var emptyFieldList = Solver.GetCoordinateListOfEmptyFields(sudokuArray);
                if (!Solver.CheckIfComplete(completeSudokuArray))
                {
                    if (!Solver.SolveWithBruteForce(CurrentSudoku, sudokuArray, emptyFieldList))
                    {
                        return false;
                    }
                    else
                    {
                        completeSudokuArray = sudokuArray;
                        CurrentSudoku.SetCompleteSudokuArray(completeSudokuArray);
                    }
                }
                var coordinate = emptyFieldList[new Random().Next(0, emptyFieldList.Count)];
                var sudokuArray2 = GetSudokuGrid(CurrentSudoku);
                sudokuArray2[coordinate[0], coordinate[1]] = completeSudokuArray[coordinate[0], coordinate[1]];
                hints += 1;
                UpdateSudokuGrid(sudokuArray2);
            }

            return b;
        }

        private void SolveSudokuGrid()
        {
            var sudokuArray = GetSudokuGrid(CurrentSudoku);

            var h = Solver.CountEmptyFieldsOfGrid(sudokuArray);

            if (Solver.SolveWithBruteForce(CurrentSudoku, sudokuArray))
            {
                hints += h;
                UpdateSudokuGrid(sudokuArray);
            }
        }

        private void Tsmi_MarkFields_Click(object sender, EventArgs e)
        {
            var frm = new SudokuMarksForm(CurrentSudoku, GetSudokuGrid(CurrentSudoku, true));
            frm.ShowDialog();
            hints += frm.GetHintsUsed();
            UpdateSudokuGrid();
        }

        private void Tsmi_Save_Click(object sender, EventArgs e)
        {
            CurrentSudoku.SudokuFilledInArray = GetSudokuGrid(CurrentSudoku, false);
            if (saveForm != null)
            {
                if (File.Exists(path))
                {
                    saveForm.path = path;
                }
                saveForm.Btn_Save_Click(null, null);
            }
            else
            {
                saveForm = new SaveForm(CurrentSudoku, path);
                saveForm.ShowDialog();
            }
            if (File.Exists(saveForm.path))
            {
                path = saveForm.path;
                this.Text = $"Sudoku - {path}";
            }
        }

        private void Tsmi_SaveAs_Click(object sender, EventArgs e)
        {
            CurrentSudoku.SudokuFilledInArray = GetSudokuGrid(CurrentSudoku, false);
            if (saveForm == null)
            {
                saveForm = new SaveForm(CurrentSudoku, null);
            }
            else
            {
                saveForm.path = null;
            }
            saveForm.ShowDialog();
            if (File.Exists(saveForm.path))
            {
                path = saveForm.path;
                this.Text = $"Sudoku - {path}";
            }
        }

        private void UpdateSudokuGrid(int[,] sudokuArray)
        {
            for (int x = 0; x < CurrentSudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < CurrentSudoku.fieldsPerRowAmount; y++)
                {
                    if (sudokuArray[x, y] != 0)
                    {
                        dgv_Sudoku[x, y].Value = sudokuArray[x, y];
                    }
                }
            }
            lbl_Hints.Text = $"hints: {hints}";
        }

        private void UpdateSudokuGrid()
        {
            lbl_Hints.Text = $"hints: {hints}";
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            lbl_Time.Text = $"time: {(DateTime.Now.Subtract(startTime)).ToString(@"hh\:mm\:ss")}";
        }
    }
}