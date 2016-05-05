namespace CourseWork
{
    partial class SettingsForm
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
            this.menu_lb = new System.Windows.Forms.ListBox();
            this.Common_pan = new System.Windows.Forms.Panel();
            this.Language_l = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Profile_pan = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.VoiceHelper_pan = new System.Windows.Forms.Panel();
            this.objects_gb = new System.Windows.Forms.GroupBox();
            this.ControlBM_btn = new System.Windows.Forms.Button();
            this.controlPrograms_btn = new System.Windows.Forms.Button();
            this.Common_pan.SuspendLayout();
            this.Profile_pan.SuspendLayout();
            this.VoiceHelper_pan.SuspendLayout();
            this.objects_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu_lb
            // 
            this.menu_lb.FormattingEnabled = true;
            this.menu_lb.Location = new System.Drawing.Point(13, 13);
            this.menu_lb.Name = "menu_lb";
            this.menu_lb.Size = new System.Drawing.Size(138, 277);
            this.menu_lb.TabIndex = 0;
            this.menu_lb.SelectedIndexChanged += new System.EventHandler(this.menu_lb_SelectedIndexChanged);
            // 
            // Common_pan
            // 
            this.Common_pan.BackgroundImage = global::CourseWork.Properties.Resources.settings;
            this.Common_pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Common_pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Common_pan.Controls.Add(this.Language_l);
            this.Common_pan.Controls.Add(this.comboBox1);
            this.Common_pan.Location = new System.Drawing.Point(156, 13);
            this.Common_pan.Name = "Common_pan";
            this.Common_pan.Size = new System.Drawing.Size(394, 277);
            this.Common_pan.TabIndex = 1;
            // 
            // Language_l
            // 
            this.Language_l.AutoSize = true;
            this.Language_l.Location = new System.Drawing.Point(11, 16);
            this.Language_l.Name = "Language_l";
            this.Language_l.Size = new System.Drawing.Size(90, 13);
            this.Language_l.TabIndex = 2;
            this.Language_l.Text = "Choose language";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Russian",
            "English"});
            this.comboBox1.Location = new System.Drawing.Point(14, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Profile_pan
            // 
            this.Profile_pan.BackgroundImage = global::CourseWork.Properties.Resources.settings;
            this.Profile_pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Profile_pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Profile_pan.Controls.Add(this.button1);
            this.Profile_pan.Location = new System.Drawing.Point(568, 13);
            this.Profile_pan.Name = "Profile_pan";
            this.Profile_pan.Size = new System.Drawing.Size(394, 277);
            this.Profile_pan.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VoiceHelper_pan
            // 
            this.VoiceHelper_pan.BackgroundImage = global::CourseWork.Properties.Resources.settings;
            this.VoiceHelper_pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.VoiceHelper_pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoiceHelper_pan.Controls.Add(this.objects_gb);
            this.VoiceHelper_pan.Location = new System.Drawing.Point(568, 305);
            this.VoiceHelper_pan.Name = "VoiceHelper_pan";
            this.VoiceHelper_pan.Size = new System.Drawing.Size(394, 277);
            this.VoiceHelper_pan.TabIndex = 3;
            // 
            // objects_gb
            // 
            this.objects_gb.Controls.Add(this.ControlBM_btn);
            this.objects_gb.Controls.Add(this.controlPrograms_btn);
            this.objects_gb.Location = new System.Drawing.Point(14, 17);
            this.objects_gb.Name = "objects_gb";
            this.objects_gb.Size = new System.Drawing.Size(180, 66);
            this.objects_gb.TabIndex = 2;
            this.objects_gb.TabStop = false;
            this.objects_gb.Text = "Objects for start";
            // 
            // ControlBM_btn
            // 
            this.ControlBM_btn.Location = new System.Drawing.Point(6, 19);
            this.ControlBM_btn.Name = "ControlBM_btn";
            this.ControlBM_btn.Size = new System.Drawing.Size(83, 41);
            this.ControlBM_btn.TabIndex = 2;
            this.ControlBM_btn.Text = "Control bookmarks";
            this.ControlBM_btn.UseVisualStyleBackColor = true;
            this.ControlBM_btn.Click += new System.EventHandler(this.ControlBM_btn_Click);
            // 
            // controlPrograms_btn
            // 
            this.controlPrograms_btn.Location = new System.Drawing.Point(95, 19);
            this.controlPrograms_btn.Name = "controlPrograms_btn";
            this.controlPrograms_btn.Size = new System.Drawing.Size(79, 41);
            this.controlPrograms_btn.TabIndex = 0;
            this.controlPrograms_btn.Text = "Control programs";
            this.controlPrograms_btn.UseVisualStyleBackColor = true;
            this.controlPrograms_btn.Click += new System.EventHandler(this.controlPrograms_btn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 592);
            this.Controls.Add(this.VoiceHelper_pan);
            this.Controls.Add(this.Common_pan);
            this.Controls.Add(this.Profile_pan);
            this.Controls.Add(this.menu_lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Common_pan.ResumeLayout(false);
            this.Common_pan.PerformLayout();
            this.Profile_pan.ResumeLayout(false);
            this.VoiceHelper_pan.ResumeLayout(false);
            this.objects_gb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox menu_lb;
        private System.Windows.Forms.Panel Common_pan;
        private System.Windows.Forms.Panel Profile_pan;
        private System.Windows.Forms.Panel VoiceHelper_pan;
        private System.Windows.Forms.Label Language_l;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button ControlBM_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox objects_gb;
        private System.Windows.Forms.Button controlPrograms_btn;
    }
}