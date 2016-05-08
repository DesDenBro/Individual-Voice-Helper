namespace CourseWork
{
    partial class NoteForm
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
            this.send_btn = new System.Windows.Forms.Button();
            this.note_tb = new System.Windows.Forms.TextBox();
            this.text_l = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(12, 131);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(361, 31);
            this.send_btn.TabIndex = 0;
            this.send_btn.Text = "send_btn";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // note_tb
            // 
            this.note_tb.Location = new System.Drawing.Point(12, 30);
            this.note_tb.Multiline = true;
            this.note_tb.Name = "note_tb";
            this.note_tb.Size = new System.Drawing.Size(361, 95);
            this.note_tb.TabIndex = 1;
            // 
            // text_l
            // 
            this.text_l.AutoSize = true;
            this.text_l.Location = new System.Drawing.Point(12, 11);
            this.text_l.Name = "text_l";
            this.text_l.Size = new System.Drawing.Size(32, 13);
            this.text_l.TabIndex = 2;
            this.text_l.Text = "text_l";
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 174);
            this.Controls.Add(this.text_l);
            this.Controls.Add(this.note_tb);
            this.Controls.Add(this.send_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NoteForm";
            this.Text = "Form_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox note_tb;
        private System.Windows.Forms.Label text_l;
    }
}