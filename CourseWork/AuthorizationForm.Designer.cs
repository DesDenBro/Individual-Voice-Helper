namespace CourseWork
{
    partial class AuthorizationForm
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
            this.logIn_btn = new System.Windows.Forms.Button();
            this.Password_tb = new System.Windows.Forms.TextBox();
            this.Login_tb = new System.Windows.Forms.TextBox();
            this.password_l = new System.Windows.Forms.Label();
            this.login_l = new System.Windows.Forms.Label();
            this.welcome_l = new System.Windows.Forms.Label();
            this.or_l = new System.Windows.Forms.Label();
            this.signUp_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logIn_btn
            // 
            this.logIn_btn.Location = new System.Drawing.Point(12, 152);
            this.logIn_btn.Name = "logIn_btn";
            this.logIn_btn.Size = new System.Drawing.Size(176, 33);
            this.logIn_btn.TabIndex = 0;
            this.logIn_btn.Text = "logIn_btn";
            this.logIn_btn.UseVisualStyleBackColor = true;
            this.logIn_btn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // Password_tb
            // 
            this.Password_tb.Location = new System.Drawing.Point(12, 122);
            this.Password_tb.Name = "Password_tb";
            this.Password_tb.Size = new System.Drawing.Size(176, 20);
            this.Password_tb.TabIndex = 1;
            this.Password_tb.UseSystemPasswordChar = true;
            this.Password_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_tb_KeyDown);
            // 
            // Login_tb
            // 
            this.Login_tb.Location = new System.Drawing.Point(12, 78);
            this.Login_tb.Name = "Login_tb";
            this.Login_tb.Size = new System.Drawing.Size(176, 20);
            this.Login_tb.TabIndex = 2;
            // 
            // password_l
            // 
            this.password_l.AutoSize = true;
            this.password_l.Location = new System.Drawing.Point(9, 106);
            this.password_l.Name = "password_l";
            this.password_l.Size = new System.Drawing.Size(60, 13);
            this.password_l.TabIndex = 3;
            this.password_l.Text = "password_l";
            // 
            // login_l
            // 
            this.login_l.AutoSize = true;
            this.login_l.Location = new System.Drawing.Point(9, 62);
            this.login_l.Name = "login_l";
            this.login_l.Size = new System.Drawing.Size(37, 13);
            this.login_l.TabIndex = 4;
            this.login_l.Text = "login_l";
            // 
            // welcome_l
            // 
            this.welcome_l.AutoSize = true;
            this.welcome_l.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcome_l.Location = new System.Drawing.Point(6, 19);
            this.welcome_l.Name = "welcome_l";
            this.welcome_l.Size = new System.Drawing.Size(140, 33);
            this.welcome_l.TabIndex = 5;
            this.welcome_l.Text = "welcome_l";
            this.welcome_l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // or_l
            // 
            this.or_l.AutoSize = true;
            this.or_l.Location = new System.Drawing.Point(92, 191);
            this.or_l.Name = "or_l";
            this.or_l.Size = new System.Drawing.Size(24, 13);
            this.or_l.TabIndex = 6;
            this.or_l.Text = "or_l";
            // 
            // signUp_btn
            // 
            this.signUp_btn.Location = new System.Drawing.Point(12, 207);
            this.signUp_btn.Name = "signUp_btn";
            this.signUp_btn.Size = new System.Drawing.Size(176, 31);
            this.signUp_btn.TabIndex = 7;
            this.signUp_btn.Text = "signUp_btn";
            this.signUp_btn.UseVisualStyleBackColor = true;
            this.signUp_btn.Click += new System.EventHandler(this.signUp_Click);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.signUp_btn);
            this.Controls.Add(this.or_l);
            this.Controls.Add(this.welcome_l);
            this.Controls.Add(this.login_l);
            this.Controls.Add(this.password_l);
            this.Controls.Add(this.Login_tb);
            this.Controls.Add(this.Password_tb);
            this.Controls.Add(this.logIn_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logIn_btn;
        private System.Windows.Forms.TextBox Password_tb;
        private System.Windows.Forms.TextBox Login_tb;
        private System.Windows.Forms.Label password_l;
        private System.Windows.Forms.Label login_l;
        private System.Windows.Forms.Label welcome_l;
        private System.Windows.Forms.Label or_l;
        private System.Windows.Forms.Button signUp_btn;
    }
}