using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AuthorizationForm : Form
    {
        #region --- Главные переменные и свойства --- 

        int _userID = -1;
        int _numberOfUsers = 0;

        public int UserID { get { return _userID; } }

        #endregion


        #region --- Загрузка формы и первичная обработка ---

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            Control.ControlCollection tempControls = this.Controls;
            Language.setControlsText(ref tempControls, this.Name);
        }

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        #endregion


        #region --- Проверка ---

        private void logIn_Click(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void checkLogin()
        {
            bool access = false;
            Gateway.checkUser(ref access, ref _userID, Login_tb.Text, Password_tb.Text);

            if (!access)
            {
                MessageBox.Show(Language.getControlText("auth_error", this.Name));
            }
            else
            {
                User.GetUser(_userID);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Password_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkLogin();
            }
        }

        #endregion


        #region --- Регистрация нового пользователя ---

        private void signUp_Click(object sender, EventArgs e)
        {
            SignUpForm suf = new SignUpForm(_numberOfUsers);
            suf.ShowDialog();
            if (suf.DialogResult == DialogResult.OK)
            {
                Gateway.addNewUserInDB(suf.Login, suf.Password);
                if (suf.AIForNewUser != null)
                {
                    Gateway.addNewAIInDB(suf.AIForNewUser);
                }
                Login_tb.Text = suf.Login;
            }
        }

        #endregion
    }
}