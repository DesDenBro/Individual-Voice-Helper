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
            this.logIn = new System.Windows.Forms.Button();
            this.Password_tb = new System.Windows.Forms.TextBox();
            this.Login_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.signUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logIn
            // 
            this.logIn.Location = new System.Drawing.Point(12, 152);
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(176, 33);
            this.logIn.TabIndex = 0;
            this.logIn.Text = "Log in";
            this.logIn.UseVisualStyleBackColor = true;
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "WELCOME!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "or";
            // 
            // signUp
            // 
            this.signUp.Location = new System.Drawing.Point(127, 207);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(61, 31);
            this.signUp.TabIndex = 7;
            this.signUp.Text = "Sign up";
            this.signUp.UseVisualStyleBackColor = true;
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 250);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_tb);
            this.Controls.Add(this.Password_tb);
            this.Controls.Add(this.logIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AuthorizationForm";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logIn;
        private System.Windows.Forms.TextBox Password_tb;
        private System.Windows.Forms.TextBox Login_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button signUp;
    }
}