using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SudokuMarksForm : Form
    {
        public bool showMarks;
        private int[,][] fieldArray;
        private int hintsUsed = 0;
        private Sudoku sudoku;
        private int[,] sudokuArray;

        public SudokuMarksForm(Sudoku sudoku, int[,] sudokuArray)
        {
            InitializeComponent();
            fieldArray = Solver.CreateFieldMarkArray(sudoku, sudokuArray, false);
            this.sudoku = sudoku;
            this.sudokuArray = sudokuArray;
            CreateSudokuGrid(sudoku, sudokuArray);
            foreach (int i in sudoku.GetListOfAllIntegers())
            {
                cb_CriteriaValue.Items.Add(i);
            }
            cb_CriteriaValue.SelectedIndex = 0;
            cb_HighlightCriteriaType.SelectedIndex = 0;
        }

        public int GetHintsUsed()
        {
            return hintsUsed;
        }

        private void Btn_Highlight_Click(object sender, EventArgs e)
        {
            Highlight();
        }

        private void Btn_Mark_Click(object sender, EventArgs e)
        {
            showMarks = true;
            hintsUsed += 1;
            Reset();
        }

        private void Btn_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Btn_RuleOut_Click(object sender, EventArgs e)
        {
            Solver.PerformFullRuleOut(sudoku, sudokuArray, fieldArray);
            hintsUsed += 1;
            Reset();
            btn_RuleOut.Enabled = false;
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

        private void CreateSudokuGrid(Sudoku sudoku, int[,] sudokuArray)
        {
            dgv_Sudoku.Font = new Font("Calibri", 21);
            dgv_Sudoku.Width = sudoku.fieldsPerRowAmount * 50 + 3;
            dgv_Sudoku.Height = sudoku.fieldsPerRowAmount * 50 + 3;
            this.Width = sudoku.fieldsPerRowAmount * 50 + 2 + 190;
            this.Height = sudoku.fieldsPerRowAmount * 50 + 2 + 90;
            for (int i = 0; i < sudoku.fieldsPerRowAmount; i++)
            {
                dgv_Sudoku.Columns.Add(i.ToString(), i.ToString());
                dgv_Sudoku.Columns[i].Width = 50;
                dgv_Sudoku.Rows.Add();
                dgv_Sudoku.Rows[i].Height = 50;
            }

            var colorList = CreateBackColorList();
            var colorAmount = 1;
            if (!sudoku.randomBoxFormation)
                colorAmount = sudoku.boxPerRowAmount - 1;

            for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                {
                    dgv_Sudoku[x, y].Style.BackColor = colorList[sudoku.GetBoxNumberOfCoordinate(new int[2] { x, y }) % colorAmount];
                    dgv_Sudoku[x, y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (sudokuArray[x, y] != 0)
                    {
                        dgv_Sudoku[x, y].ReadOnly = true;
                        dgv_Sudoku[x, y].Style.ForeColor = Color.DarkGray;
                        dgv_Sudoku[x, y].Value = sudokuArray[x, y];
                    }
                    else
                    {
                        if (showMarks)
                        {
                            dgv_Sudoku[x, y].Value = String.Join(", ", fieldArray[x, y]);
                        }
                        dgv_Sudoku[x, y].Style.Font = new Font("Calibri", 10);
                        dgv_Sudoku[x, y].Style.WrapMode = DataGridViewTriState.True;
                    }
                }
            }
            btn_Highlight.Enabled = showMarks;
            btn_Mark.Visible = !showMarks;
            btn_RuleOut.Visible = showMarks;
        }

        private void Highlight()
        {
            var res = colorDialog1.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }
            var clr = colorDialog1.Color;

            for (int x = 0; x < fieldArray.GetLength(0); x++)
            {
                for (int y = 0; y < fieldArray.GetLength(1); y++)
                {
                    if (cb_HighlightCriteriaType.SelectedIndex == 0)
                    {
                        if (fieldArray[x, y].Contains(Convert.ToInt32(cb_CriteriaValue.Text)))
                        {
                            dgv_Sudoku[x, y].Style.BackColor = clr;
                        }
                    }
                    if (cb_HighlightCriteriaType.SelectedIndex == 1)
                    {
                        if (fieldArray[x, y].Length == (Convert.ToInt32(cb_CriteriaValue.Text)))
                        {
                            dgv_Sudoku[x, y].Style.BackColor = clr;
                        }
                    }
                }
            }
        }

        private void Reset()
        {
            dgv_Sudoku.Rows.Clear();
            dgv_Sudoku.Columns.Clear();
            CreateSudokuGrid(sudoku, sudokuArray);
        }
    }
}