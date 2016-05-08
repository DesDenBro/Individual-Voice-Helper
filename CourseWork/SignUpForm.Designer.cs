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
            this.create_btn = new System.Windows.Forms.Button();
            this.login_l = new System.Windows.Forms.Label();
            this.password_l = new System.Windows.Forms.Label();
            this.newLogin = new System.Windows.Forms.TextBox();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.confPassword_l = new System.Windows.Forms.Label();
            this.newPasswordConfirm = new System.Windows.Forms.TextBox();
            this.user_gb = new System.Windows.Forms.GroupBox();
            this.AI_gb = new System.Windows.Forms.GroupBox();
            this.deleteName_btn = new System.Windows.Forms.Button();
            this.addName_btn = new System.Windows.Forms.Button();
            this.helperNames_l = new System.Windows.Forms.Label();
            this.names_lb = new System.Windows.Forms.ListBox();
            this.femaleSexChoose_rb = new System.Windows.Forms.RadioButton();
            this.maleGenderChoose_rb = new System.Windows.Forms.RadioButton();
            this.createAIChoose_cb = new System.Windows.Forms.CheckBox();
            this.user_gb.SuspendLayout();
            this.AI_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // create_btn
            // 
            this.create_btn.Location = new System.Drawing.Point(12, 179);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(157, 28);
            this.create_btn.TabIndex = 0;
            this.create_btn.Text = "Create_btn";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // login_l
            // 
            this.login_l.AutoSize = true;
            this.login_l.Location = new System.Drawing.Point(14, 23);
            this.login_l.Name = "login_l";
            this.login_l.Size = new System.Drawing.Size(37, 13);
            this.login_l.TabIndex = 1;
            this.login_l.Text = "login_l";
            // 
            // password_l
            // 
            this.password_l.AutoSize = true;
            this.password_l.Location = new System.Drawing.Point(14, 65);
            this.password_l.Name = "password_l";
            this.password_l.Size = new System.Drawing.Size(53, 13);
            this.password_l.TabIndex = 2;
            this.password_l.Text = "Password";
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
            // confPassword_l
            // 
            this.confPassword_l.AutoSize = true;
            this.confPassword_l.Location = new System.Drawing.Point(14, 109);
            this.confPassword_l.Name = "confPassword_l";
            this.confPassword_l.Size = new System.Drawing.Size(82, 13);
            this.confPassword_l.TabIndex = 5;
            this.confPassword_l.Text = "confPassword_l";
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
            this.user_gb.Controls.Add(this.login_l);
            this.user_gb.Controls.Add(this.newLogin);
            this.user_gb.Controls.Add(this.password_l);
            this.user_gb.Controls.Add(this.newPasswordConfirm);
            this.user_gb.Controls.Add(this.newPassword);
            this.user_gb.Controls.Add(this.confPassword_l);
            this.user_gb.Location = new System.Drawing.Point(12, 12);
            this.user_gb.Name = "user_gb";
            this.user_gb.Size = new System.Drawing.Size(157, 161);
            this.user_gb.TabIndex = 7;
            this.user_gb.TabStop = false;
            this.user_gb.Text = "user_gb";
            // 
            // AI_gb
            // 
            this.AI_gb.Controls.Add(this.deleteName_btn);
            this.AI_gb.Controls.Add(this.addName_btn);
            this.AI_gb.Controls.Add(this.helperNames_l);
            this.AI_gb.Controls.Add(this.names_lb);
            this.AI_gb.Controls.Add(this.femaleSexChoose_rb);
            this.AI_gb.Controls.Add(this.maleGenderChoose_rb);
            this.AI_gb.Controls.Add(this.createAIChoose_cb);
            this.AI_gb.Location = new System.Drawing.Point(176, 12);
            this.AI_gb.Name = "AI_gb";
            this.AI_gb.Size = new System.Drawing.Size(229, 195);
            this.AI_gb.TabIndex = 8;
            this.AI_gb.TabStop = false;
            this.AI_gb.Text = "AI_gb";
            // 
            // deleteName_btn
            // 
            this.deleteName_btn.Location = new System.Drawing.Point(164, 145);
            this.deleteName_btn.Name = "deleteName_btn";
            this.deleteName_btn.Size = new System.Drawing.Size(59, 44);
            this.deleteName_btn.TabIndex = 12;
            this.deleteName_btn.Text = "deleteName_btn";
            this.deleteName_btn.UseVisualStyleBackColor = true;
            this.deleteName_btn.Click += new System.EventHandler(this.deleteName_btn_Click);
            // 
            // addName_btn
            // 
            this.addName_btn.Location = new System.Drawing.Point(164, 101);
            this.addName_btn.Name = "addName_btn";
            this.addName_btn.Size = new System.Drawing.Size(59, 44);
            this.addName_btn.TabIndex = 11;
            this.addName_btn.Text = "addName_btn";
            this.addName_btn.UseVisualStyleBackColor = true;
            this.addName_btn.Click += new System.EventHandler(this.addName_btn_Click);
            // 
            // helperNames_l
            // 
            this.helperNames_l.AutoSize = true;
            this.helperNames_l.Location = new System.Drawing.Point(6, 38);
            this.helperNames_l.Name = "helperNames_l";
            this.helperNames_l.Size = new System.Drawing.Size(77, 13);
            this.helperNames_l.TabIndex = 10;
            this.helperNames_l.Text = "helperNames_l";
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
            this.femaleSexChoose_rb.Size = new System.Drawing.Size(125, 17);
            this.femaleSexChoose_rb.TabIndex = 8;
            this.femaleSexChoose_rb.TabStop = true;
            this.femaleSexChoose_rb.Text = "femaleSexChoose_rb";
            this.femaleSexChoose_rb.UseVisualStyleBackColor = true;
            // 
            // maleGenderChoose_rb
            // 
            this.maleGenderChoose_rb.AutoSize = true;
            this.maleGenderChoose_rb.Checked = true;
            this.maleGenderChoose_rb.Location = new System.Drawing.Point(164, 55);
            this.maleGenderChoose_rb.Name = "maleGenderChoose_rb";
            this.maleGenderChoose_rb.Size = new System.Drawing.Size(133, 17);
            this.maleGenderChoose_rb.TabIndex = 7;
            this.maleGenderChoose_rb.TabStop = true;
            this.maleGenderChoose_rb.Text = "maleGenderChoose_rb";
            this.maleGenderChoose_rb.UseVisualStyleBackColor = true;
            // 
            // createAIChoose_cb
            // 
            this.createAIChoose_cb.AutoSize = true;
            this.createAIChoose_cb.Checked = true;
            this.createAIChoose_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createAIChoose_cb.Location = new System.Drawing.Point(9, 19);
            this.createAIChoose_cb.Name = "createAIChoose_cb";
            this.createAIChoose_cb.Size = new System.Drawing.Size(120, 17);
            this.createAIChoose_cb.TabIndex = 0;
            this.createAIChoose_cb.Text = "createAIChoose_cb";
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
            this.Controls.Add(this.create_btn);
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

        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Label login_l;
        private System.Windows.Forms.Label password_l;
        private System.Windows.Forms.TextBox newLogin;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label confPassword_l;
        private System.Windows.Forms.TextBox newPasswordConfirm;
        private System.Windows.Forms.GroupBox user_gb;
        private System.Windows.Forms.GroupBox AI_gb;
        private System.Windows.Forms.RadioButton femaleSexChoose_rb;
        private System.Windows.Forms.RadioButton maleGenderChoose_rb;
        private System.Windows.Forms.CheckBox createAIChoose_cb;
        private System.Windows.Forms.Button deleteName_btn;
        private System.Windows.Forms.Button addName_btn;
        private System.Windows.Forms.Label helperNames_l;
        private System.Windows.Forms.ListBox names_lb;
    }
}