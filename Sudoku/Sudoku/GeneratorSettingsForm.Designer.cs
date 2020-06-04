namespace Sudoku
{
    partial class GeneratorSettingsForm
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
            this.btn_CreateGrid = new System.Windows.Forms.Button();
            this.cb_DiagonalRows = new System.Windows.Forms.CheckBox();
            this.cb_Difficulty = new System.Windows.Forms.ComboBox();
            this.lbl_Difficulty = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_CreateSeeds = new System.Windows.Forms.Button();
            this.cb_UseSeeds = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_CreateGrid
            // 
            this.btn_CreateGrid.Location = new System.Drawing.Point(143, 69);
            this.btn_CreateGrid.Name = "btn_CreateGrid";
            this.btn_CreateGrid.Size = new System.Drawing.Size(89, 23);
            this.btn_CreateGrid.TabIndex = 0;
            this.btn_CreateGrid.Text = "Create grid";
            this.btn_CreateGrid.UseVisualStyleBackColor = true;
            this.btn_CreateGrid.Click += new System.EventHandler(this.Btn_CreateGrid_Click);
            // 
            // cb_DiagonalRows
            // 
            this.cb_DiagonalRows.AutoSize = true;
            this.cb_DiagonalRows.Location = new System.Drawing.Point(15, 73);
            this.cb_DiagonalRows.Name = "cb_DiagonalRows";
            this.cb_DiagonalRows.Size = new System.Drawing.Size(91, 17);
            this.cb_DiagonalRows.TabIndex = 1;
            this.cb_DiagonalRows.Text = "diagonal rows";
            this.cb_DiagonalRows.UseVisualStyleBackColor = true;
            // 
            // cb_Difficulty
            // 
            this.cb_Difficulty.CausesValidation = false;
            this.cb_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Difficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "VeryHard",
            "ExtremelyHard",
            "Custom"});
            this.cb_Difficulty.Location = new System.Drawing.Point(66, 12);
            this.cb_Difficulty.Name = "cb_Difficulty";
            this.cb_Difficulty.Size = new System.Drawing.Size(166, 21);
            this.cb_Difficulty.TabIndex = 2;
            // 
            // lbl_Difficulty
            // 
            this.lbl_Difficulty.AutoSize = true;
            this.lbl_Difficulty.Location = new System.Drawing.Point(12, 15);
            this.lbl_Difficulty.Name = "lbl_Difficulty";
            this.lbl_Difficulty.Size = new System.Drawing.Size(48, 13);
            this.lbl_Difficulty.TabIndex = 3;
            this.lbl_Difficulty.Text = "difficulty:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // btn_CreateSeeds
            // 
            this.btn_CreateSeeds.Location = new System.Drawing.Point(143, 126);
            this.btn_CreateSeeds.Name = "btn_CreateSeeds";
            this.btn_CreateSeeds.Size = new System.Drawing.Size(89, 23);
            this.btn_CreateSeeds.TabIndex = 5;
            this.btn_CreateSeeds.Text = "Create Seeds";
            this.btn_CreateSeeds.UseVisualStyleBackColor = true;
            this.btn_CreateSeeds.Click += new System.EventHandler(this.Btn_CreateSeeds_Click);
            // 
            // cb_UseSeeds
            // 
            this.cb_UseSeeds.AutoSize = true;
            this.cb_UseSeeds.Location = new System.Drawing.Point(15, 50);
            this.cb_UseSeeds.Name = "cb_UseSeeds";
            this.cb_UseSeeds.Size = new System.Drawing.Size(74, 17);
            this.cb_UseSeeds.TabIndex = 6;
            this.cb_UseSeeds.Text = "use seeds";
            this.cb_UseSeeds.UseVisualStyleBackColor = true;
            // 
            // GeneratorSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 161);
            this.Controls.Add(this.cb_UseSeeds);
            this.Controls.Add(this.btn_CreateSeeds);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_Difficulty);
            this.Controls.Add(this.cb_Difficulty);
            this.Controls.Add(this.cb_DiagonalRows);
            this.Controls.Add(this.btn_CreateGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GeneratorSettingsForm";
            this.Text = "Generator settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateGrid;
        private System.Windows.Forms.CheckBox cb_DiagonalRows;
        private System.Windows.Forms.ComboBox cb_Difficulty;
        private System.Windows.Forms.Label lbl_Difficulty;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_CreateSeeds;
        private System.Windows.Forms.CheckBox cb_UseSeeds;
    }
}