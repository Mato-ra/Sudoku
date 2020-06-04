namespace Sudoku
{
    partial class PregeneratedPuzzleForm
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
            this.dgv_GridData = new System.Windows.Forms.DataGridView();
            this.clm_GridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Diagonals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GridData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_GridData
            // 
            this.dgv_GridData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_GridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_GridID,
            this.clm_Difficulty,
            this.clm_Diagonals,
            this.clm_Rating});
            this.dgv_GridData.Location = new System.Drawing.Point(13, 13);
            this.dgv_GridData.Name = "dgv_GridData";
            this.dgv_GridData.RowHeadersVisible = false;
            this.dgv_GridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GridData.Size = new System.Drawing.Size(424, 307);
            this.dgv_GridData.TabIndex = 0;
            this.dgv_GridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_GridData_CellDoubleClick);
            // 
            // clm_GridID
            // 
            this.clm_GridID.HeaderText = "grid ID";
            this.clm_GridID.Name = "clm_GridID";
            this.clm_GridID.ReadOnly = true;
            // 
            // clm_Difficulty
            // 
            this.clm_Difficulty.HeaderText = "difficulty";
            this.clm_Difficulty.Name = "clm_Difficulty";
            this.clm_Difficulty.ReadOnly = true;
            this.clm_Difficulty.Width = 125;
            // 
            // clm_Diagonals
            // 
            this.clm_Diagonals.HeaderText = "Diagonals";
            this.clm_Diagonals.Name = "clm_Diagonals";
            this.clm_Diagonals.ReadOnly = true;
            // 
            // clm_Rating
            // 
            this.clm_Rating.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_Rating.HeaderText = "Rating";
            this.clm_Rating.Name = "clm_Rating";
            this.clm_Rating.ReadOnly = true;
            // 
            // btn_Open
            // 
            this.btn_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Open.Location = new System.Drawing.Point(225, 326);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(103, 23);
            this.btn_Open.TabIndex = 1;
            this.btn_Open.Text = "open grid";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.Location = new System.Drawing.Point(334, 326);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(103, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "close window";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // PregeneratedPuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 361);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.dgv_GridData);
            this.MaximumSize = new System.Drawing.Size(465, 1000);
            this.MinimumSize = new System.Drawing.Size(465, 400);
            this.Name = "PregeneratedPuzzleForm";
            this.Text = "pregenerated puzzles";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_GridData;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_GridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Difficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Diagonals;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_Rating;
    }
}