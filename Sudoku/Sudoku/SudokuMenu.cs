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
    public partial class SudokuMenu : Form
    {
        public SudokuMenu()
        {
            InitializeComponent();
        }

        private void Btn_LoadPregeneratedGrid_Click(object sender, EventArgs e)
        {
            new PregeneratedPuzzleForm().ShowDialog();
        }

        private void Btn_NewGrid_Click(object sender, EventArgs e)
        {
            new GeneratorSettingsForm().Show();
        }

        private void Btn_OpenGrid_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();
            op.Filter = "avlsdk files (*.avlsdk)|*.avlsdk";
            op.ShowDialog();
            if (File.Exists(op.FileName))
            {
                new SudokuForm(SudokuFileReader.ReadGridCode(File.ReadAllText(op.FileName)), op.FileName).Show();
            }
        }
    }
}