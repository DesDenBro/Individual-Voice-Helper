namespace CourseWork
{
    partial class EditEventForm
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
            this.editEvent_btn = new System.Windows.Forms.Button();
            this.eventText_l = new System.Windows.Forms.Label();
            this.eventName_l = new System.Windows.Forms.Label();
            this.eventName_tb = new System.Windows.Forms.TextBox();
            this.eventText_tb = new System.Windows.Forms.TextBox();
            this.voiceChecker = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.voiceCommand_ss = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editEvent_btn
            // 
            this.editEvent_btn.Location = new System.Drawing.Point(12, 337);
            this.editEvent_btn.Name = "editEvent_btn";
            this.editEvent_btn.Size = new System.Drawing.Size(351, 38);
            this.editEvent_btn.TabIndex = 1;
            this.editEvent_btn.Text = "Confirm edit";
            this.editEvent_btn.UseVisualStyleBackColor = true;
            this.editEvent_btn.Click += new System.EventHandler(this.editEvent_btn_Click);
            // 
            // eventText_l
            // 
            this.eventText_l.AutoSize = true;
            this.eventText_l.Location = new System.Drawing.Point(12, 218);
            this.eventText_l.Name = "eventText_l";
            this.eventText_l.Size = new System.Drawing.Size(55, 13);
            this.eventText_l.TabIndex = 3;
            this.eventText_l.Text = "Event text";
            // 
            // eventName_l
            // 
            this.eventName_l.AutoSize = true;
            this.eventName_l.Location = new System.Drawing.Point(12, 9);
            this.eventName_l.Name = "eventName_l";
            this.eventName_l.Size = new System.Drawing.Size(64, 13);
            this.eventName_l.TabIndex = 4;
            this.eventName_l.Text = "Event name";
            // 
            // eventName_tb
            // 
            this.eventName_tb.Location = new System.Drawing.Point(12, 25);
            this.eventName_tb.Name = "eventName_tb";
            this.eventName_tb.Size = new System.Drawing.Size(351, 20);
            this.eventName_tb.TabIndex = 5;
            // 
            // eventText_tb
            // 
            this.eventText_tb.Location = new System.Drawing.Point(12, 234);
            this.eventText_tb.Multiline = true;
            this.eventText_tb.Name = "eventText_tb";
            this.eventText_tb.Size = new System.Drawing.Size(351, 97);
            this.eventText_tb.TabIndex = 7;
            // 
            // voiceChecker
            // 
            this.voiceChecker.Tick += new System.EventHandler(this.voiceChecker_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voiceCommand_ss});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(376, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // voiceCommand_ss
            // 
            this.voiceCommand_ss.Name = "voiceCommand_ss";
            this.voiceCommand_ss.Size = new System.Drawing.Size(86, 17);
            this.voiceCommand_ss.Text = "Say command!";
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 404);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.eventText_tb);
            this.Controls.Add(this.eventName_tb);
            this.Controls.Add(this.eventName_l);
            this.Controls.Add(this.eventText_l);
            this.Controls.Add(this.editEvent_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditEventForm";
            this.Text = "Edit event";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editEvent_btn;
        private System.Windows.Forms.Label eventText_l;
        private System.Windows.Forms.Label eventName_l;
        private System.Windows.Forms.TextBox eventName_tb;
        private System.Windows.Forms.TextBox eventText_tb;
        private System.Windows.Forms.Timer voiceChecker;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel voiceCommand_ss;
    }
}