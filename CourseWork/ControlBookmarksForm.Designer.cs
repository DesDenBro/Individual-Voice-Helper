namespace CourseWork
{
    partial class ControlBookmarksForm
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
            this.add_btn = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.bookmarks_cb = new System.Windows.Forms.ComboBox();
            this.link_tb = new System.Windows.Forms.TextBox();
            this.browserChoise_l = new System.Windows.Forms.Label();
            this.browserChoice_cb = new System.Windows.Forms.ComboBox();
            this.importBM_btn = new System.Windows.Forms.Button();
            this.crud_gb = new System.Windows.Forms.GroupBox();
            this.import_gb = new System.Windows.Forms.GroupBox();
            this.crud_gb.SuspendLayout();
            this.import_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(6, 73);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(165, 36);
            this.add_btn.TabIndex = 0;
            this.add_btn.Text = "add_btn";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Location = new System.Drawing.Point(6, 115);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(165, 36);
            this.edit_btn.TabIndex = 1;
            this.edit_btn.Text = "edit_btn";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.edit_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(6, 157);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(165, 36);
            this.delete_btn.TabIndex = 2;
            this.delete_btn.Text = "delete_btn";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // bookmarks_cb
            // 
            this.bookmarks_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bookmarks_cb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bookmarks_cb.FormattingEnabled = true;
            this.bookmarks_cb.Location = new System.Drawing.Point(6, 19);
            this.bookmarks_cb.Name = "bookmarks_cb";
            this.bookmarks_cb.Size = new System.Drawing.Size(165, 21);
            this.bookmarks_cb.TabIndex = 3;
            this.bookmarks_cb.SelectedIndexChanged += new System.EventHandler(this.bookmarks_cb_SelectedIndexChanged);
            // 
            // link_tb
            // 
            this.link_tb.Location = new System.Drawing.Point(6, 47);
            this.link_tb.Name = "link_tb";
            this.link_tb.ReadOnly = true;
            this.link_tb.Size = new System.Drawing.Size(165, 20);
            this.link_tb.TabIndex = 4;
            // 
            // browserChoise_l
            // 
            this.browserChoise_l.AutoSize = true;
            this.browserChoise_l.Location = new System.Drawing.Point(6, 19);
            this.browserChoise_l.Name = "browserChoise_l";
            this.browserChoise_l.Size = new System.Drawing.Size(84, 13);
            this.browserChoise_l.TabIndex = 7;
            this.browserChoise_l.Text = "browserChoise_l";
            // 
            // browserChoice_cb
            // 
            this.browserChoice_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.browserChoice_cb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browserChoice_cb.FormattingEnabled = true;
            this.browserChoice_cb.Items.AddRange(new object[] {
            "Chrome",
            "Yandex"});
            this.browserChoice_cb.Location = new System.Drawing.Point(9, 41);
            this.browserChoice_cb.Name = "browserChoice_cb";
            this.browserChoice_cb.Size = new System.Drawing.Size(172, 21);
            this.browserChoice_cb.TabIndex = 6;
            // 
            // importBM_btn
            // 
            this.importBM_btn.Location = new System.Drawing.Point(9, 73);
            this.importBM_btn.Name = "importBM_btn";
            this.importBM_btn.Size = new System.Drawing.Size(172, 36);
            this.importBM_btn.TabIndex = 5;
            this.importBM_btn.Text = "importBM_btn";
            this.importBM_btn.UseVisualStyleBackColor = true;
            this.importBM_btn.Click += new System.EventHandler(this.importBM_btn_Click);
            // 
            // crud_gb
            // 
            this.crud_gb.Controls.Add(this.bookmarks_cb);
            this.crud_gb.Controls.Add(this.add_btn);
            this.crud_gb.Controls.Add(this.edit_btn);
            this.crud_gb.Controls.Add(this.delete_btn);
            this.crud_gb.Controls.Add(this.link_tb);
            this.crud_gb.Location = new System.Drawing.Point(12, 12);
            this.crud_gb.Name = "crud_gb";
            this.crud_gb.Size = new System.Drawing.Size(181, 203);
            this.crud_gb.TabIndex = 8;
            this.crud_gb.TabStop = false;
            this.crud_gb.Text = "crud_gb";
            // 
            // import_gb
            // 
            this.import_gb.Controls.Add(this.importBM_btn);
            this.import_gb.Controls.Add(this.browserChoice_cb);
            this.import_gb.Controls.Add(this.browserChoise_l);
            this.import_gb.Location = new System.Drawing.Point(199, 12);
            this.import_gb.Name = "import_gb";
            this.import_gb.Size = new System.Drawing.Size(190, 120);
            this.import_gb.TabIndex = 9;
            this.import_gb.TabStop = false;
            this.import_gb.Text = "import_gb";
            // 
            // ControlBookmarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 223);
            this.Controls.Add(this.import_gb);
            this.Controls.Add(this.crud_gb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ControlBookmarksForm";
            this.Text = "ControlBookmarksForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlBookmarksForm_FormClosed);
            this.crud_gb.ResumeLayout(false);
            this.crud_gb.PerformLayout();
            this.import_gb.ResumeLayout(false);
            this.import_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.ComboBox bookmarks_cb;
        private System.Windows.Forms.TextBox link_tb;
        private System.Windows.Forms.Label browserChoise_l;
        private System.Windows.Forms.ComboBox browserChoice_cb;
        private System.Windows.Forms.Button importBM_btn;
        private System.Windows.Forms.GroupBox crud_gb;
        private System.Windows.Forms.GroupBox import_gb;
    }
}