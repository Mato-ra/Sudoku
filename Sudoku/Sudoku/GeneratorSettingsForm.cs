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
    public partial class GeneratorSettingsForm : Form
    {
        public GeneratorSettingsForm()
        {
            InitializeComponent();
            cb_Difficulty.SelectedIndex = 0;
        }

        private void Btn_CreateGrid_Click(object sender, EventArgs e)
        {
            Sudoku sudoku = null;
            var difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), cb_Difficulty.Text, true);

            if (cb_UseSeeds.Checked)
            {
                var seed = SeedConverter.GetRandomSeed(9, difficulty, cb_DiagonalRows.Checked);
                var gridCode = SeedConverter.ConvertSeedIntoRandomGridCode(9, difficulty, cb_DiagonalRows.Checked, seed);
                sudoku = new Sudoku(gridCode);
            }
            else
            {
                sudoku = new Sudoku(9, difficulty, cb_DiagonalRows.Checked, false);
            }
            new SudokuForm(sudoku, null).Show();
        }

        private void Btn_CreateSeeds_Click(object sender, EventArgs e)
        {
            CreateSeeds(Convert.ToInt32(textBox1.Text), 9, (Difficulty)Enum.Parse(typeof(Difficulty), cb_Difficulty.Text, true), cb_DiagonalRows.Checked);
        }

        private void CreateSeeds(int amount, int fieldsPerRowAmount, Difficulty difficulty, bool diagonalRows)
        {
            for (int i = 0; i < amount; i++)
            {
                File.AppendAllLines($"C:\\Users\\martti.rasilainen\\Arbeiten\\VSProjekte\\Sudoku\\Sudoku\\Sudoku\\Properties\\{difficulty}{diagonalRows}.txt", new string[1] { SeedConverter.GenerateSudokuAndGetSeed(fieldsPerRowAmount, difficulty, diagonalRows, false) } as IEnumerable<string>);
            }
        }
    }
}