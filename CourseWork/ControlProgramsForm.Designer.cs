namespace CourseWork
{
    partial class ControlProgramsForm
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
            this.path_tb = new System.Windows.Forms.TextBox();
            this.programs_cb = new System.Windows.Forms.ComboBox();
            this.delete_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.testProgram_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // path_tb
            // 
            this.path_tb.Location = new System.Drawing.Point(12, 40);
            this.path_tb.Name = "path_tb";
            this.path_tb.ReadOnly = true;
            this.path_tb.Size = new System.Drawing.Size(180, 20);
            this.path_tb.TabIndex = 9;
            // 
            // programs_cb
            // 
            this.programs_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programs_cb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.programs_cb.FormattingEnabled = true;
            this.programs_cb.Location = new System.Drawing.Point(12, 12);
            this.programs_cb.Name = "programs_cb";
            this.programs_cb.Size = new System.Drawing.Size(180, 21);
            this.programs_cb.TabIndex = 8;
            this.programs_cb.SelectedIndexChanged += new System.EventHandler(this.programs_cb_SelectedIndexChanged);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(12, 150);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(180, 36);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "delete_btn";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(12, 66);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(180, 36);
            this.add_btn.TabIndex = 5;
            this.add_btn.Text = "add_btn";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // testProgram_btn
            // 
            this.testProgram_btn.Location = new System.Drawing.Point(12, 108);
            this.testProgram_btn.Name = "testProgram_btn";
            this.testProgram_btn.Size = new System.Drawing.Size(180, 36);
            this.testProgram_btn.TabIndex = 10;
            this.testProgram_btn.Text = "testProgram_btn";
            this.testProgram_btn.UseVisualStyleBackColor = true;
            this.testProgram_btn.Click += new System.EventHandler(this.testProgram_btn_Click);
            // 
            // ControlProgramsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 198);
            this.Controls.Add(this.testProgram_btn);
            this.Controls.Add(this.path_tb);
            this.Controls.Add(this.programs_cb);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.add_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ControlProgramsForm";
            this.Text = "ControlProgramsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlProgramsForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path_tb;
        private System.Windows.Forms.ComboBox programs_cb;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button testProgram_btn;
    }
}