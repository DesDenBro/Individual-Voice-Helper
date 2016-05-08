namespace CourseWork
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyHappenedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyCanceledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Checker = new System.Windows.Forms.Timer(this.components);
            this.VoiceCommands = new System.Windows.Forms.StatusStrip();
            this.userVoice_ss = new System.Windows.Forms.ToolStripStatusLabel();
            this.VoiceChecker = new System.Windows.Forms.Timer(this.components);
            this.Menu.SuspendLayout();
            this.VoiceCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(170, 20);
            this.addEventToolStripMenuItem.Text = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.addEventToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(462, 24);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(167, 20);
            this.programToolStripMenuItem.Text = "programToolStripMenuItem";
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.changeUserToolStripMenuItem.Text = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Click += new System.EventHandler(this.changeUserToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exitToolStripMenuItem.Text = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEventsToolStripMenuItem,
            this.inProcessToolStripMenuItem,
            this.onlyHappenedToolStripMenuItem,
            this.onlyCanceledToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.filterToolStripMenuItem.Text = "filterToolStripMenuItem";
            // 
            // allEventsToolStripMenuItem
            // 
            this.allEventsToolStripMenuItem.Name = "allEventsToolStripMenuItem";
            this.allEventsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.allEventsToolStripMenuItem.Text = "allEventsToolStripMenuItem";
            this.allEventsToolStripMenuItem.Click += new System.EventHandler(this.allEventsToolStripMenuItem_Click);
            // 
            // inProcessToolStripMenuItem
            // 
            this.inProcessToolStripMenuItem.Name = "inProcessToolStripMenuItem";
            this.inProcessToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.inProcessToolStripMenuItem.Text = "inProcessToolStripMenuItem";
            this.inProcessToolStripMenuItem.Click += new System.EventHandler(this.inProcessToolStripMenuItem_Click);
            // 
            // onlyHappenedToolStripMenuItem
            // 
            this.onlyHappenedToolStripMenuItem.Name = "onlyHappenedToolStripMenuItem";
            this.onlyHappenedToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.onlyHappenedToolStripMenuItem.Text = "onlyHappenedToolStripMenuItem";
            this.onlyHappenedToolStripMenuItem.Click += new System.EventHandler(this.onlyHappenedToolStripMenuItem_Click);
            // 
            // onlyCanceledToolStripMenuItem
            // 
            this.onlyCanceledToolStripMenuItem.Name = "onlyCanceledToolStripMenuItem";
            this.onlyCanceledToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.onlyCanceledToolStripMenuItem.Text = "onlyCanceledToolStripMenuItem";
            this.onlyCanceledToolStripMenuItem.Click += new System.EventHandler(this.onlyCanceledToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.dateToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.searchToolStripMenuItem.Text = "searchToolStripMenuItem";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.nameToolStripMenuItem.Text = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dateToolStripMenuItem.Text = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.dateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.settingsToolStripMenuItem.Text = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // Checker
            // 
            this.Checker.Interval = 10000;
            this.Checker.Tick += new System.EventHandler(this.Checker_Tick);
            // 
            // VoiceCommands
            // 
            this.VoiceCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userVoice_ss});
            this.VoiceCommands.Location = new System.Drawing.Point(0, 429);
            this.VoiceCommands.Name = "VoiceCommands";
            this.VoiceCommands.Size = new System.Drawing.Size(462, 22);
            this.VoiceCommands.TabIndex = 3;
            this.VoiceCommands.Text = "statusStrip1";
            // 
            // userVoice_ss
            // 
            this.userVoice_ss.Name = "userVoice_ss";
            this.userVoice_ss.Size = new System.Drawing.Size(0, 17);
            // 
            // VoiceChecker
            // 
            this.VoiceChecker.Tick += new System.EventHandler(this.VoiceChecker_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 451);
            this.Controls.Add(this.VoiceCommands);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu;
            this.MinimumSize = new System.Drawing.Size(380, 220);
            this.Name = "MainForm";
            this.Text = "Event helper";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.VoiceCommands.ResumeLayout(false);
            this.VoiceCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyHappenedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyCanceledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.Timer Checker;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip VoiceCommands;
        private System.Windows.Forms.ToolStripStatusLabel userVoice_ss;
        private System.Windows.Forms.Timer VoiceChecker;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
    }
}

