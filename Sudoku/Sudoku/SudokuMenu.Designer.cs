namespace Sudoku
{
    partial class SudokuMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_LoadPregeneratedGrid = new System.Windows.Forms.Button();
            this.btn_OpenGrid = new System.Windows.Forms.Button();
            this.btn_NewGrid = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_LoadPregeneratedGrid
            // 
            this.btn_LoadPregeneratedGrid.Location = new System.Drawing.Point(121, 12);
            this.btn_LoadPregeneratedGrid.Name = "btn_LoadPregeneratedGrid";
            this.btn_LoadPregeneratedGrid.Size = new System.Drawing.Size(103, 42);
            this.btn_LoadPregeneratedGrid.TabIndex = 1;
            this.btn_LoadPregeneratedGrid.Text = "load pregenerated grid...";
            this.btn_LoadPregeneratedGrid.UseVisualStyleBackColor = true;
            this.btn_LoadPregeneratedGrid.Click += new System.EventHandler(this.Btn_LoadPregeneratedGrid_Click);
            // 
            // btn_OpenGrid
            // 
            this.btn_OpenGrid.Location = new System.Drawing.Point(230, 12);
            this.btn_OpenGrid.Name = "btn_OpenGrid";
            this.btn_OpenGrid.Size = new System.Drawing.Size(103, 42);
            this.btn_OpenGrid.TabIndex = 2;
            this.btn_OpenGrid.Text = "open grid...";
            this.btn_OpenGrid.UseVisualStyleBackColor = true;
            this.btn_OpenGrid.Click += new System.EventHandler(this.Btn_OpenGrid_Click);
            // 
            // btn_NewGrid
            // 
            this.btn_NewGrid.Location = new System.Drawing.Point(12, 12);
            this.btn_NewGrid.Name = "btn_NewGrid";
            this.btn_NewGrid.Size = new System.Drawing.Size(103, 42);
            this.btn_NewGrid.TabIndex = 0;
            this.btn_NewGrid.Text = "new grid...";
            this.btn_NewGrid.UseVisualStyleBackColor = true;
            this.btn_NewGrid.Click += new System.EventHandler(this.Btn_NewGrid_Click);
            // 
            // SudokuMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 79);
            this.Controls.Add(this.btn_NewGrid);
            this.Controls.Add(this.btn_OpenGrid);
            this.Controls.Add(this.btn_LoadPregeneratedGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SudokuMenu";
            this.Text = "Sudoku menu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_LoadPregeneratedGrid;
        private System.Windows.Forms.Button btn_OpenGrid;
        private System.Windows.Forms.Button btn_NewGrid;
    }
}