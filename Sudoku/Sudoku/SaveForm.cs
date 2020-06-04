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
    public partial class SaveForm : Form
    {
        public string path;
        private Sudoku sudoku;

        public SaveForm(Sudoku sudoku)
        {
            InitializeComponent();
            this.sudoku = sudoku;
        }

        public SaveForm(Sudoku sudoku, string path)
        {
            if (path != null && File.Exists(path))
            {
                this.path = path;
            }
            InitializeComponent();
            this.sudoku = sudoku;
        }

        public void Btn_Save_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                Save(sudoku, path);
                Close();
            }
            else
            {
                var sf = new SaveFileDialog();
                sf.Filter = "avlsdk files (*.avlsdk)|*.avlsdk";

                sf.ShowDialog();

                if (sf.FileName != "")
                {
                    Save(sudoku, sf.FileName);
                    Close();
                }
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool DetermineIfFieldIsReadOnly(Sudoku sudoku, int[] coordinate)
        {
            if (rb_MakeAllFieldsEditable.Checked)
            {
                return false;
            }
            if (rb_MakeAllFilledFieldsUneditable.Checked)
            {
                if (sudoku.GetIntegerOfFilledInArray(coordinate) != 0 || sudoku.GetIntegerOfIncompleteArray(coordinate) != 0)
                {
                    return true;
                }
            }
            if (rb_DontChangeEditability.Checked)
            {
                if (sudoku.GetIntegerOfIncompleteArray(coordinate) != 0)
                {
                    return true;
                }
            }
            return false;
        }

        private string GetFieldCode(Sudoku sudoku, int[] coordinate)
        {
            var coordinateString = $"{coordinate[0]}.{coordinate[1]}";
            var visibleNumber = sudoku.GetIntegerOfIncompleteArray(coordinate);
            if (visibleNumber == 0)
            {
                visibleNumber = sudoku.GetIntegerOfFilledInArray(coordinate);
            }
            var solutionNumber = sudoku.GetIntegerOfCompleteArray(coordinate);
            string isReadOnlyString = DetermineIfFieldIsReadOnly(sudoku, coordinate).ToString();
            var boxID = sudoku.GetBoxNumberOfCoordinate(coordinate);

            return $"{coordinateString},{visibleNumber},{solutionNumber},{isReadOnlyString},{boxID}";
        }

        private string GetGridDataCode(Sudoku sudoku)
        {
            var difficulty = sudoku.difficulty;
            var rating = sudoku.rating;
            if (!rb_DontChangeEditability.Checked)
            {
                difficulty = Difficulty.Custom;
                rating = 0;
            }
            return $"{sudoku.SudokuIncompleteArray.GetLength(0)}.{sudoku.SudokuIncompleteArray.GetLength(1)},{difficulty},{rating},{sudoku.diagonalRows}";
        }

        private void Save(Sudoku sudoku, string path)
        {
            var gridCode = GetGridDataCode(sudoku);

            this.path = path;

            var fieldCodeList = new List<string>();
            for (int x = 0; x < sudoku.fieldsPerRowAmount; x++)
            {
                for (int y = 0; y < sudoku.fieldsPerRowAmount; y++)
                {
                    fieldCodeList.Add(GetFieldCode(sudoku, new int[2] { x, y }));
                }
            }

            var fieldCodes = String.Join(";", fieldCodeList);

            File.WriteAllText(path, $"{gridCode}|{fieldCodes}");
        }
    }
}