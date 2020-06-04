namespace Sudoku
{
    partial class SudokuForm
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
            this.dgv_Sudoku = new System.Windows.Forms.DataGridView();
            this.btn_SolveOneField = new System.Windows.Forms.Button();
            this.btn_SolveEntireGrid = new System.Windows.Forms.Button();
            this.lbl_Difficulty = new System.Windows.Forms.Label();
            this.lbl_DiagonalRows = new System.Windows.Forms.Label();
            this.btn_ShowMistakes = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_Hints = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Rate = new System.Windows.Forms.Button();
            this.solverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_MarkFields = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sudoku)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Sudoku
            // 
            this.dgv_Sudoku.AllowUserToAddRows = false;
            this.dgv_Sudoku.AllowUserToDeleteRows = false;
            this.dgv_Sudoku.AllowUserToResizeColumns = false;
            this.dgv_Sudoku.AllowUserToResizeRows = false;
            this.dgv_Sudoku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Sudoku.ColumnHeadersVisible = false;
            this.dgv_Sudoku.Location = new System.Drawing.Point(12, 36);
            this.dgv_Sudoku.MultiSelect = false;
            this.dgv_Sudoku.Name = "dgv_Sudoku";
            this.dgv_Sudoku.RowHeadersVisible = false;
            this.dgv_Sudoku.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Sudoku.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Sudoku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Sudoku.Size = new System.Drawing.Size(580, 477);
            this.dgv_Sudoku.TabIndex = 0;
            this.dgv_Sudoku.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Sudoku_CellValueChanged);
            this.dgv_Sudoku.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Dgv_Sudoku_Scroll);
            // 
            // btn_SolveOneField
            // 
            this.btn_SolveOneField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SolveOneField.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SolveOneField.Location = new System.Drawing.Point(815, 469);
            this.btn_SolveOneField.Name = "btn_SolveOneField";
            this.btn_SolveOneField.Size = new System.Drawing.Size(138, 23);
            this.btn_SolveOneField.TabIndex = 1;
            this.btn_SolveOneField.Text = "Solve one field";
            this.btn_SolveOneField.UseVisualStyleBackColor = true;
            this.btn_SolveOneField.Click += new System.EventHandler(this.Btn_SolveOneField_Click);
            // 
            // btn_SolveEntireGrid
            // 
            this.btn_SolveEntireGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SolveEntireGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SolveEntireGrid.Location = new System.Drawing.Point(815, 498);
            this.btn_SolveEntireGrid.Name = "btn_SolveEntireGrid";
            this.btn_SolveEntireGrid.Size = new System.Drawing.Size(138, 23);
            this.btn_SolveEntireGrid.TabIndex = 2;
            this.btn_SolveEntireGrid.Text = "Solve entire grid";
            this.btn_SolveEntireGrid.UseVisualStyleBackColor = true;
            this.btn_SolveEntireGrid.Click += new System.EventHandler(this.Btn_SolveEntireGrid_Click);
            // 
            // lbl_Difficulty
            // 
            this.lbl_Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Difficulty.AutoSize = true;
            this.lbl_Difficulty.Location = new System.Drawing.Point(812, 321);
            this.lbl_Difficulty.Name = "lbl_Difficulty";
            this.lbl_Difficulty.Size = new System.Drawing.Size(50, 13);
            this.lbl_Difficulty.TabIndex = 3;
            this.lbl_Difficulty.Text = "Difficulty:";
            // 
            // lbl_DiagonalRows
            // 
            this.lbl_DiagonalRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DiagonalRows.AutoSize = true;
            this.lbl_DiagonalRows.Location = new System.Drawing.Point(812, 334);
            this.lbl_DiagonalRows.Name = "lbl_DiagonalRows";
            this.lbl_DiagonalRows.Size = new System.Drawing.Size(82, 13);
            this.lbl_DiagonalRows.TabIndex = 4;
            this.lbl_DiagonalRows.Text = "Diagonal Rows:";
            // 
            // btn_ShowMistakes
            // 
            this.btn_ShowMistakes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowMistakes.Location = new System.Drawing.Point(815, 440);
            this.btn_ShowMistakes.Name = "btn_ShowMistakes";
            this.btn_ShowMistakes.Size = new System.Drawing.Size(138, 23);
            this.btn_ShowMistakes.TabIndex = 6;
            this.btn_ShowMistakes.Text = "Show Mistakes";
            this.btn_ShowMistakes.UseVisualStyleBackColor = true;
            this.btn_ShowMistakes.Click += new System.EventHandler(this.Btn_ShowMistakes_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Confirm.Location = new System.Drawing.Point(815, 411);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(138, 23);
            this.btn_Confirm.TabIndex = 7;
            this.btn_Confirm.Text = "Confirm";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(812, 269);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(36, 13);
            this.lbl_Time.TabIndex = 8;
            this.lbl_Time.Text = "Time: ";
            // 
            // lbl_Hints
            // 
            this.lbl_Hints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Hints.AutoSize = true;
            this.lbl_Hints.Location = new System.Drawing.Point(812, 282);
            this.lbl_Hints.Name = "lbl_Hints";
            this.lbl_Hints.Size = new System.Drawing.Size(34, 13);
            this.lbl_Hints.TabIndex = 9;
            this.lbl_Hints.Text = "Hints:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.solverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SaveAs,
            this.tsmi_Save});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmi_SaveAs
            // 
            this.tsmi_SaveAs.Name = "tsmi_SaveAs";
            this.tsmi_SaveAs.Size = new System.Drawing.Size(180, 22);
            this.tsmi_SaveAs.Text = "save as...";
            this.tsmi_SaveAs.Click += new System.EventHandler(this.Tsmi_SaveAs_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Save.Text = "save";
            this.tsmi_Save.Click += new System.EventHandler(this.Tsmi_Save_Click);
            // 
            // btn_Rate
            // 
            this.btn_Rate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Rate.Location = new System.Drawing.Point(815, 382);
            this.btn_Rate.Name = "btn_Rate";
            this.btn_Rate.Size = new System.Drawing.Size(138, 23);
            this.btn_Rate.TabIndex = 11;
            this.btn_Rate.Text = "Rate";
            this.btn_Rate.UseVisualStyleBackColor = true;
            this.btn_Rate.Click += new System.EventHandler(this.Btn_Rate_Click);
            // 
            // solverToolStripMenuItem
            // 
            this.solverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_MarkFields});
            this.solverToolStripMenuItem.Name = "solverToolStripMenuItem";
            this.solverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.solverToolStripMenuItem.Text = "Solver";
            // 
            // tsmi_MarkFields
            // 
            this.tsmi_MarkFields.Name = "tsmi_MarkFields";
            this.tsmi_MarkFields.Size = new System.Drawing.Size(180, 22);
            this.tsmi_MarkFields.Text = "mark fields";
            this.tsmi_MarkFields.Click += new System.EventHandler(this.Tsmi_MarkFields_Click);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 534);
            this.Controls.Add(this.btn_Rate);
            this.Controls.Add(this.lbl_Hints);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.btn_ShowMistakes);
            this.Controls.Add(this.lbl_DiagonalRows);
            this.Controls.Add(this.lbl_Difficulty);
            this.Controls.Add(this.btn_SolveEntireGrid);
            this.Controls.Add(this.btn_SolveOneField);
            this.Controls.Add(this.dgv_Sudoku);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SudokuForm";
            this.Text = "Sudoku";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sudoku)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Sudoku;
        private System.Windows.Forms.Button btn_SolveOneField;
        private System.Windows.Forms.Button btn_SolveEntireGrid;
        private System.Windows.Forms.Label lbl_Difficulty;
        private System.Windows.Forms.Label lbl_DiagonalRows;
        private System.Windows.Forms.Button btn_ShowMistakes;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_Hints;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveAs;
        private System.Windows.Forms.Button btn_Rate;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem solverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MarkFields;
    }
}

