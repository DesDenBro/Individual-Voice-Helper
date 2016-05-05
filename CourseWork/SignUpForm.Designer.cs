namespace CourseWork
{
    partial class SignUpForm
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
            this.CreateBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newLogin = new System.Windows.Forms.TextBox();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newPasswordConfirm = new System.Windows.Forms.TextBox();
            this.user_gb = new System.Windows.Forms.GroupBox();
            this.AI_gb = new System.Windows.Forms.GroupBox();
            this.deleteName_btn = new System.Windows.Forms.Button();
            this.addName_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.names_lb = new System.Windows.Forms.ListBox();
            this.femaleSexChoose_rb = new System.Windows.Forms.RadioButton();
            this.maleSexChoose_rb = new System.Windows.Forms.RadioButton();
            this.createAIChoose_cb = new System.Windows.Forms.CheckBox();
            this.user_gb.SuspendLayout();
            this.AI_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(12, 179);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(157, 28);
            this.CreateBtn.TabIndex = 0;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // newLogin
            // 
            this.newLogin.Location = new System.Drawing.Point(11, 38);
            this.newLogin.Name = "newLogin";
            this.newLogin.Size = new System.Drawing.Size(131, 20);
            this.newLogin.TabIndex = 3;
            // 
            // newPassword
            // 
            this.newPassword.Location = new System.Drawing.Point(11, 81);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(131, 20);
            this.newPassword.TabIndex = 4;
            this.newPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm password";
            // 
            // newPasswordConfirm
            // 
            this.newPasswordConfirm.Location = new System.Drawing.Point(11, 125);
            this.newPasswordConfirm.Name = "newPasswordConfirm";
            this.newPasswordConfirm.Size = new System.Drawing.Size(131, 20);
            this.newPasswordConfirm.TabIndex = 6;
            this.newPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // user_gb
            // 
            this.user_gb.Controls.Add(this.label1);
            this.user_gb.Controls.Add(this.newLogin);
            this.user_gb.Controls.Add(this.label2);
            this.user_gb.Controls.Add(this.newPasswordConfirm);
            this.user_gb.Controls.Add(this.newPassword);
            this.user_gb.Controls.Add(this.label3);
            this.user_gb.Location = new System.Drawing.Point(12, 12);
            this.user_gb.Name = "user_gb";
            this.user_gb.Size = new System.Drawing.Size(157, 161);
            this.user_gb.TabIndex = 7;
            this.user_gb.TabStop = false;
            this.user_gb.Text = "User";
            // 
            // AI_gb
            // 
            this.AI_gb.Controls.Add(this.deleteName_btn);
            this.AI_gb.Controls.Add(this.addName_btn);
            this.AI_gb.Controls.Add(this.label4);
            this.AI_gb.Controls.Add(this.names_lb);
            this.AI_gb.Controls.Add(this.femaleSexChoose_rb);
            this.AI_gb.Controls.Add(this.maleSexChoose_rb);
            this.AI_gb.Controls.Add(this.createAIChoose_cb);
            this.AI_gb.Location = new System.Drawing.Point(176, 12);
            this.AI_gb.Name = "AI_gb";
            this.AI_gb.Size = new System.Drawing.Size(229, 195);
            this.AI_gb.TabIndex = 8;
            this.AI_gb.TabStop = false;
            this.AI_gb.Text = "Voice helper";
            // 
            // deleteName_btn
            // 
            this.deleteName_btn.Location = new System.Drawing.Point(164, 145);
            this.deleteName_btn.Name = "deleteName_btn";
            this.deleteName_btn.Size = new System.Drawing.Size(59, 44);
            this.deleteName_btn.TabIndex = 12;
            this.deleteName_btn.Text = "Delete name";
            this.deleteName_btn.UseVisualStyleBackColor = true;
            this.deleteName_btn.Click += new System.EventHandler(this.deleteName_btn_Click);
            // 
            // addName_btn
            // 
            this.addName_btn.Location = new System.Drawing.Point(164, 101);
            this.addName_btn.Name = "addName_btn";
            this.addName_btn.Size = new System.Drawing.Size(59, 44);
            this.addName_btn.TabIndex = 11;
            this.addName_btn.Text = "Add name";
            this.addName_btn.UseVisualStyleBackColor = true;
            this.addName_btn.Click += new System.EventHandler(this.addName_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Helper names";
            // 
            // names_lb
            // 
            this.names_lb.FormattingEnabled = true;
            this.names_lb.Location = new System.Drawing.Point(9, 55);
            this.names_lb.Name = "names_lb";
            this.names_lb.Size = new System.Drawing.Size(149, 134);
            this.names_lb.TabIndex = 9;
            // 
            // femaleSexChoose_rb
            // 
            this.femaleSexChoose_rb.AutoSize = true;
            this.femaleSexChoose_rb.Location = new System.Drawing.Point(164, 78);
            this.femaleSexChoose_rb.Name = "femaleSexChoose_rb";
            this.femaleSexChoose_rb.Size = new System.Drawing.Size(59, 17);
            this.femaleSexChoose_rb.TabIndex = 8;
            this.femaleSexChoose_rb.TabStop = true;
            this.femaleSexChoose_rb.Text = "Female";
            this.femaleSexChoose_rb.UseVisualStyleBackColor = true;
            // 
            // maleSexChoose_rb
            // 
            this.maleSexChoose_rb.AutoSize = true;
            this.maleSexChoose_rb.Checked = true;
            this.maleSexChoose_rb.Location = new System.Drawing.Point(164, 55);
            this.maleSexChoose_rb.Name = "maleSexChoose_rb";
            this.maleSexChoose_rb.Size = new System.Drawing.Size(48, 17);
            this.maleSexChoose_rb.TabIndex = 7;
            this.maleSexChoose_rb.TabStop = true;
            this.maleSexChoose_rb.Text = "Male";
            this.maleSexChoose_rb.UseVisualStyleBackColor = true;
            // 
            // createAIChoose_cb
            // 
            this.createAIChoose_cb.AutoSize = true;
            this.createAIChoose_cb.Checked = true;
            this.createAIChoose_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createAIChoose_cb.Location = new System.Drawing.Point(9, 19);
            this.createAIChoose_cb.Name = "createAIChoose_cb";
            this.createAIChoose_cb.Size = new System.Drawing.Size(127, 17);
            this.createAIChoose_cb.TabIndex = 0;
            this.createAIChoose_cb.Text = "Create AI for this user";
            this.createAIChoose_cb.UseVisualStyleBackColor = true;
            this.createAIChoose_cb.CheckedChanged += new System.EventHandler(this.createAIChoose_cb_CheckedChanged);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 216);
            this.Controls.Add(this.AI_gb);
            this.Controls.Add(this.user_gb);
            this.Controls.Add(this.CreateBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SignUpForm";
            this.Text = "Sign Up";
            this.user_gb.ResumeLayout(false);
            this.user_gb.PerformLayout();
            this.AI_gb.ResumeLayout(false);
            this.AI_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newLogin;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newPasswordConfirm;
        private System.Windows.Forms.GroupBox user_gb;
        private System.Windows.Forms.GroupBox AI_gb;
        private System.Windows.Forms.RadioButton femaleSexChoose_rb;
        private System.Windows.Forms.RadioButton maleSexChoose_rb;
        private System.Windows.Forms.CheckBox createAIChoose_cb;
        private System.Windows.Forms.Button deleteName_btn;
        private System.Windows.Forms.Button addName_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox names_lb;
    }
}