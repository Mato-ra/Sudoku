namespace Sudoku
{
    partial class SaveForm
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
            this.rb_DontChangeEditability = new System.Windows.Forms.RadioButton();
            this.rb_MakeAllFilledFieldsUneditable = new System.Windows.Forms.RadioButton();
            this.rb_MakeAllFieldsEditable = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rb_DontChangeEditability
            // 
            this.rb_DontChangeEditability.AutoSize = true;
            this.rb_DontChangeEditability.Location = new System.Drawing.Point(94, 21);
            this.rb_DontChangeEditability.Name = "rb_DontChangeEditability";
            this.rb_DontChangeEditability.Size = new System.Drawing.Size(133, 17);
            this.rb_DontChangeEditability.TabIndex = 0;
            this.rb_DontChangeEditability.TabStop = true;
            this.rb_DontChangeEditability.Text = "don\'t change editability";
            this.rb_DontChangeEditability.UseVisualStyleBackColor = true;
            // 
            // rb_MakeAllFilledFieldsUneditable
            // 
            this.rb_MakeAllFilledFieldsUneditable.AutoSize = true;
            this.rb_MakeAllFilledFieldsUneditable.Location = new System.Drawing.Point(94, 44);
            this.rb_MakeAllFilledFieldsUneditable.Name = "rb_MakeAllFilledFieldsUneditable";
            this.rb_MakeAllFilledFieldsUneditable.Size = new System.Drawing.Size(167, 17);
            this.rb_MakeAllFilledFieldsUneditable.TabIndex = 1;
            this.rb_MakeAllFilledFieldsUneditable.TabStop = true;
            this.rb_MakeAllFilledFieldsUneditable.Text = "make all filled fields uneditable";
            this.rb_MakeAllFilledFieldsUneditable.UseVisualStyleBackColor = true;
            // 
            // rb_MakeAllFieldsEditable
            // 
            this.rb_MakeAllFieldsEditable.AutoSize = true;
            this.rb_MakeAllFieldsEditable.Location = new System.Drawing.Point(94, 67);
            this.rb_MakeAllFieldsEditable.Name = "rb_MakeAllFieldsEditable";
            this.rb_MakeAllFieldsEditable.Size = new System.Drawing.Size(131, 17);
            this.rb_MakeAllFieldsEditable.TabIndex = 2;
            this.rb_MakeAllFieldsEditable.TabStop = true;
            this.rb_MakeAllFieldsEditable.Text = "make all fields editable";
            this.rb_MakeAllFieldsEditable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "editability:";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(12, 110);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(118, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(141, 110);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(118, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 145);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_MakeAllFieldsEditable);
            this.Controls.Add(this.rb_MakeAllFilledFieldsUneditable);
            this.Controls.Add(this.rb_DontChangeEditability);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SaveForm";
            this.Text = "save config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_DontChangeEditability;
        private System.Windows.Forms.RadioButton rb_MakeAllFilledFieldsUneditable;
        private System.Windows.Forms.RadioButton rb_MakeAllFieldsEditable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
    }
}