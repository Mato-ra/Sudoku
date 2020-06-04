using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class PregeneratedPuzzleForm : Form
    {
        public PregeneratedPuzzleForm()
        {
            InitializeComponent();
            FillDataGridView();
        }

        public void FillDataGridView()
        {
            var ga = PregeneratedPuzzleContainerClass.GetGridInfoList();
            for (int i = 0; i < ga.Count; i++)
            {
                dgv_GridData.Rows.Add();
                dgv_GridData[0, i].Value = i + 1;
                dgv_GridData[1, i].Value = ga[i][1];
                dgv_GridData[2, i].Value = ga[i][3];
                dgv_GridData[3, i].Value = Convert.ToInt32(ga[i][2]);
            }
        }

        public void OpenGrid()
        {
            var id = Convert.ToInt32(dgv_GridData[0, dgv_GridData.CurrentCell.RowIndex].Value);
            var gc = PregeneratedPuzzleContainerClass.GetGridCode(id);
            new SudokuForm(new Sudoku(gc), $"Puzzle #{id}").Show();
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            OpenGrid();
        }

        private void Dgv_GridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenGrid();
        }
    }
}