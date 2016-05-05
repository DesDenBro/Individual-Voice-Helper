using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class SignUpForm : Form
    {
        #region --- Главные переменные и свойства ---

        private string _login = "";         // Логин пользователя
        private string _password = "";      // Пароль пользователя
        private AI _AIForNewUser;           // Голосовой помощник для пользователя

        public string Login { get { return _login; } }
        public string Password { get { return _password; } }
        public AI AIForNewUser { get { return _AIForNewUser; } }

        #endregion


        #region --- Методы для создания пользователя и его голосового помощника ---

        // Конструктор формы
        public SignUpForm(int numberOfUsers)
        {
            InitializeComponent();
        }

        // Кнопка для создания нового пользователя
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (newPassword.Text != "" && newLogin.Text != "" && 
                (!createAIChoose_cb.Checked || (createAIChoose_cb.Checked && (maleSexChoose_rb.Checked || femaleSexChoose_rb.Checked) && names_lb.Items.Count > 0)))
            {
                
                if (newPassword.Text == newPasswordConfirm.Text)
                {
                    _login = newLogin.Text;
                    _password = PasswordStorage.CreateHash(newPassword.Text);

                    if (createAIChoose_cb.Checked)
                    {
                        _AIForNewUser = new AI(Gateway.getCountOfTableRows("User"), getNames(), maleSexChoose_rb.Checked);
                    }

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Passwords is not equ. Try again");
                    newPassword.Text = "";
                    newPasswordConfirm.Text = "";
                }
            }
            else
            {
                if (newPassword.Text == "" && newLogin.Text == "")
                    MessageBox.Show("Login or password must have one or more simbols");
                if (createAIChoose_cb.Checked && ((!maleSexChoose_rb.Checked && !femaleSexChoose_rb.Checked) || names_lb.Items.Count <= 0))
                    MessageBox.Show("Something didn't choose/add in voice helper form, try again");
            }
        }

        // Получить имена из listbox-а
        private List<string> getNames()
        {
            List<string> names = new List<string>();

            foreach (var item in names_lb.Items)
            {
                names.Add(item.ToString());
            }

            return names;
        }

        // Выбор создания (или нет), голосового помощника для пользователя
        private void createAIChoose_cb_CheckedChanged(object sender, EventArgs e)
        {
            maleSexChoose_rb.Enabled = femaleSexChoose_rb.Enabled = createAIChoose_cb.Checked;
            maleSexChoose_rb.Checked = femaleSexChoose_rb.Checked = false;
            names_lb.Items.Clear(); names_lb.Enabled = createAIChoose_cb.Checked;
            addName_btn.Enabled = deleteName_btn.Enabled = createAIChoose_cb.Checked;
        }

        // Добавление имени
        private void addName_btn_Click(object sender, EventArgs e)
        {
            if (names_lb.Items.Count < 10)
            {
                NoteForm nf = new NoteForm("Add voice name", "Write a new voice helper name", "Add", "Write name");
                nf.ShowDialog();
                if (nf.DialogResult == DialogResult.OK)
                {
                    if (nf.Note.Length <= 20)
                        names_lb.Items.Add(TranslitWord.GetTranslit(nf.Note));
                    else
                        MessageBox.Show("Name can't be more then 20 simbols!", "Attention!", MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show("Names can't be more then 10!", "Attention!", MessageBoxButtons.OK);
        }

        // Удаление имени
        private void deleteName_btn_Click(object sender, EventArgs e)
        {
            if (names_lb.SelectedIndex > 0)
                names_lb.Items.RemoveAt(names_lb.SelectedIndex);
            else
                MessageBox.Show("You must choose element from list before delete it!", "Attention!", MessageBoxButtons.OK);
        }

        #endregion
    }
}
