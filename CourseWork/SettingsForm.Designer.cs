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
            this.language_l = new System.Windows.Forms.Label();
            this.languages_cb = new System.Windows.Forms.ComboBox();
            this.Profile_pan = new System.Windows.Forms.Panel();
            this.showCommands_btn = new System.Windows.Forms.Button();
            this.VoiceHelper_pan = new System.Windows.Forms.Panel();
            this.controlPrograms_btn = new System.Windows.Forms.Button();
            this.controlBM_btn = new System.Windows.Forms.Button();
            this.Common_pan.SuspendLayout();
            this.VoiceHelper_pan.SuspendLayout();
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
            this.Common_pan.Controls.Add(this.language_l);
            this.Common_pan.Controls.Add(this.languages_cb);
            this.Common_pan.Location = new System.Drawing.Point(156, 13);
            this.Common_pan.Name = "Common_pan";
            this.Common_pan.Size = new System.Drawing.Size(394, 277);
            this.Common_pan.TabIndex = 1;
            this.Common_pan.Tag = "Common";
            // 
            // language_l
            // 
            this.language_l.AutoSize = true;
            this.language_l.Location = new System.Drawing.Point(11, 8);
            this.language_l.Name = "language_l";
            this.language_l.Size = new System.Drawing.Size(59, 13);
            this.language_l.TabIndex = 2;
            this.language_l.Text = "language_l";
            // 
            // languages_cb
            // 
            this.languages_cb.FormattingEnabled = true;
            this.languages_cb.Items.AddRange(new object[] {
            "English",
            "Русский"});
            this.languages_cb.Location = new System.Drawing.Point(14, 27);
            this.languages_cb.Name = "languages_cb";
            this.languages_cb.Size = new System.Drawing.Size(121, 21);
            this.languages_cb.TabIndex = 0;
            this.languages_cb.SelectedIndexChanged += new System.EventHandler(this.languages_cb_SelectedIndexChanged);
            // 
            // Profile_pan
            // 
            this.Profile_pan.BackgroundImage = global::CourseWork.Properties.Resources.settings;
            this.Profile_pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Profile_pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Profile_pan.Location = new System.Drawing.Point(568, 13);
            this.Profile_pan.Name = "Profile_pan";
            this.Profile_pan.Size = new System.Drawing.Size(394, 277);
            this.Profile_pan.TabIndex = 2;
            this.Profile_pan.Tag = "Profile";
            // 
            // showCommands_btn
            // 
            this.showCommands_btn.Location = new System.Drawing.Point(268, 16);
            this.showCommands_btn.Name = "showCommands_btn";
            this.showCommands_btn.Size = new System.Drawing.Size(112, 41);
            this.showCommands_btn.TabIndex = 0;
            this.showCommands_btn.Text = "showCommands_btn";
            this.showCommands_btn.UseVisualStyleBackColor = true;
            this.showCommands_btn.Click += new System.EventHandler(this.showCommands_btn_Click);
            // 
            // VoiceHelper_pan
            // 
            this.VoiceHelper_pan.BackgroundImage = global::CourseWork.Properties.Resources.settings;
            this.VoiceHelper_pan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.VoiceHelper_pan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VoiceHelper_pan.Controls.Add(this.controlPrograms_btn);
            this.VoiceHelper_pan.Controls.Add(this.showCommands_btn);
            this.VoiceHelper_pan.Controls.Add(this.controlBM_btn);
            this.VoiceHelper_pan.Location = new System.Drawing.Point(568, 303);
            this.VoiceHelper_pan.Name = "VoiceHelper_pan";
            this.VoiceHelper_pan.Size = new System.Drawing.Size(394, 277);
            this.VoiceHelper_pan.TabIndex = 3;
            this.VoiceHelper_pan.Tag = "Voice helper";
            // 
            // controlPrograms_btn
            // 
            this.controlPrograms_btn.Location = new System.Drawing.Point(15, 63);
            this.controlPrograms_btn.Name = "controlPrograms_btn";
            this.controlPrograms_btn.Size = new System.Drawing.Size(122, 41);
            this.controlPrograms_btn.TabIndex = 0;
            this.controlPrograms_btn.Text = "controlPrograms_btn";
            this.controlPrograms_btn.UseVisualStyleBackColor = true;
            this.controlPrograms_btn.Click += new System.EventHandler(this.controlPrograms_btn_Click);
            // 
            // controlBM_btn
            // 
            this.controlBM_btn.Location = new System.Drawing.Point(15, 16);
            this.controlBM_btn.Name = "controlBM_btn";
            this.controlBM_btn.Size = new System.Drawing.Size(122, 41);
            this.controlBM_btn.TabIndex = 2;
            this.controlBM_btn.Text = "controlBM_btn";
            this.controlBM_btn.UseVisualStyleBackColor = true;
            this.controlBM_btn.Click += new System.EventHandler(this.ControlBM_btn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 592);
            this.Controls.Add(this.Common_pan);
            this.Controls.Add(this.Profile_pan);
            this.Controls.Add(this.menu_lb);
            this.Controls.Add(this.VoiceHelper_pan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Common_pan.ResumeLayout(false);
            this.Common_pan.PerformLayout();
            this.VoiceHelper_pan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox menu_lb;
        private System.Windows.Forms.Panel Common_pan;
        private System.Windows.Forms.Panel Profile_pan;
        private System.Windows.Forms.Panel VoiceHelper_pan;
        private System.Windows.Forms.Label language_l;
        private System.Windows.Forms.ComboBox languages_cb;
        private System.Windows.Forms.Button controlBM_btn;
        private System.Windows.Forms.Button showCommands_btn;
        private System.Windows.Forms.Button controlPrograms_btn;
    }
}