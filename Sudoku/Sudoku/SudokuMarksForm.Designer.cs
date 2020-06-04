namespace Sudoku
{
    partial class SudokuMarksForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_Highlight = new System.Windows.Forms.Button();
            this.cb_HighlightCriteriaType = new System.Windows.Forms.ComboBox();
            this.cb_CriteriaValue = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_RuleOut = new System.Windows.Forms.Button();
            this.btn_Mark = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sudoku)).BeginInit();
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
            this.dgv_Sudoku.Location = new System.Drawing.Point(12, 12);
            this.dgv_Sudoku.Name = "dgv_Sudoku";
            this.dgv_Sudoku.RowHeadersVisible = false;
            this.dgv_Sudoku.Size = new System.Drawing.Size(199, 174);
            this.dgv_Sudoku.TabIndex = 0;
            // 
            // btn_Highlight
            // 
            this.btn_Highlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Highlight.Location = new System.Drawing.Point(452, 339);
            this.btn_Highlight.Name = "btn_Highlight";
            this.btn_Highlight.Size = new System.Drawing.Size(121, 23);
            this.btn_Highlight.TabIndex = 1;
            this.btn_Highlight.Text = "highlight";
            this.btn_Highlight.UseVisualStyleBackColor = true;
            this.btn_Highlight.Click += new System.EventHandler(this.Btn_Highlight_Click);
            // 
            // cb_HighlightCriteriaType
            // 
            this.cb_HighlightCriteriaType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_HighlightCriteriaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HighlightCriteriaType.FormattingEnabled = true;
            this.cb_HighlightCriteriaType.Items.AddRange(new object[] {
            "mark value",
            "mark amount"});
            this.cb_HighlightCriteriaType.Location = new System.Drawing.Point(452, 285);
            this.cb_HighlightCriteriaType.Name = "cb_HighlightCriteriaType";
            this.cb_HighlightCriteriaType.Size = new System.Drawing.Size(121, 21);
            this.cb_HighlightCriteriaType.TabIndex = 2;
            // 
            // cb_CriteriaValue
            // 
            this.cb_CriteriaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_CriteriaValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CriteriaValue.FormattingEnabled = true;
            this.cb_CriteriaValue.Location = new System.Drawing.Point(452, 312);
            this.cb_CriteriaValue.Name = "cb_CriteriaValue";
            this.cb_CriteriaValue.Size = new System.Drawing.Size(121, 21);
            this.cb_CriteriaValue.TabIndex = 3;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reset.Location = new System.Drawing.Point(452, 368);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(121, 23);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.Btn_Reset_Click);
            // 
            // btn_RuleOut
            // 
            this.btn_RuleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RuleOut.Location = new System.Drawing.Point(452, 397);
            this.btn_RuleOut.Name = "btn_RuleOut";
            this.btn_RuleOut.Size = new System.Drawing.Size(121, 23);
            this.btn_RuleOut.TabIndex = 5;
            this.btn_RuleOut.Text = "rule out";
            this.btn_RuleOut.UseVisualStyleBackColor = true;
            this.btn_RuleOut.Click += new System.EventHandler(this.Btn_RuleOut_Click);
            // 
            // btn_Mark
            // 
            this.btn_Mark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Mark.Location = new System.Drawing.Point(452, 397);
            this.btn_Mark.Name = "btn_Mark";
            this.btn_Mark.Size = new System.Drawing.Size(121, 23);
            this.btn_Mark.TabIndex = 6;
            this.btn_Mark.Text = "mark";
            this.btn_Mark.UseVisualStyleBackColor = true;
            this.btn_Mark.Click += new System.EventHandler(this.Btn_Mark_Click);
            // 
            // SudokuMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 432);
            this.Controls.Add(this.btn_Mark);
            this.Controls.Add(this.btn_RuleOut);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.cb_CriteriaValue);
            this.Controls.Add(this.cb_HighlightCriteriaType);
            this.Controls.Add(this.btn_Highlight);
            this.Controls.Add(this.dgv_Sudoku);
            this.Name = "SudokuMarksForm";
            this.Text = "Sudoku Marks";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Sudoku)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Sudoku;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_Highlight;
        private System.Windows.Forms.ComboBox cb_HighlightCriteriaType;
        private System.Windows.Forms.ComboBox cb_CriteriaValue;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_RuleOut;
        private System.Windows.Forms.Button btn_Mark;
    }
}