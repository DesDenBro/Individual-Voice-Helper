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

            Control.ControlCollection tempControls = this.Controls;
            Language.setControlsText(ref tempControls, this.Name);
        }

        // Кнопка для создания нового пользователя
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (newPassword.Text.Trim() != "" && newLogin.Text.Trim() != "" && 
                (!createAIChoose_cb.Checked || (createAIChoose_cb.Checked && 
                (maleGenderChoose_rb.Checked || femaleSexChoose_rb.Checked) && names_lb.Items.Count > 0)))
            {
                if (!Gateway.userAlreadyExist(newLogin.Text))
                {
                    if (newPassword.Text == newPasswordConfirm.Text)
                    {
                        _login = newLogin.Text;
                        _password = PasswordStorage.CreateHash(newPassword.Text);

                        if (createAIChoose_cb.Checked)
                        {
                            _AIForNewUser = new AI(Gateway.getCountOfTableRows("User"), getNames(), maleGenderChoose_rb.Checked);
                        }

                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Language.getControlText("equPasswords_error", this.Name));
                        newPassword.Text = "";
                        newPasswordConfirm.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(Language.getControlText("userAlreadyExist_error", this.Name));
                }
            }
            else
            {
                if (newPassword.Text == "" && newLogin.Text == "")
                    MessageBox.Show(Language.getControlText("LogOrPassIsEmpty_error", this.Name));
                if (createAIChoose_cb.Checked && ((!maleGenderChoose_rb.Checked && !femaleSexChoose_rb.Checked) || names_lb.Items.Count <= 0))
                    MessageBox.Show(Language.getControlText("AIProperties_error", this.Name));
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
            foreach (Control control in AI_gb.Controls)
            {
                control.Enabled = createAIChoose_cb.Checked;
            }
        }

        // Добавление имени
        private void addName_btn_Click(object sender, EventArgs e)
        {
            if (names_lb.Items.Count < 10)
            {
                NoteForm nf = new NoteForm(
                    Language.getControlText("noteAIName", this.Name),
                    Language.getControlText("noteAINameDescr", this.Name),
                    Language.getControlText("noteAI_btn", this.Name),
                    Language.getControlText("noteAIAttention", this.Name));
                nf.ShowDialog();

                if (nf.DialogResult == DialogResult.OK)
                {
                    if (nf.Note.Length <= 20)
                        names_lb.Items.Add(TranslitWord.GetTranslit(nf.Note));
                    else
                        MessageBox.Show(
                            Language.getControlText("AINameLength_error", this.Name),
                            Language.getControlText("attention", this.Name), 
                            MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show(
                        Language.getControlText("AINamesCount_error", this.Name),
                        Language.getControlText("attention", this.Name),
                        MessageBoxButtons.OK);
        }

        // Удаление имени
        private void deleteName_btn_Click(object sender, EventArgs e)
        {
            if (names_lb.SelectedIndex > 0)
                names_lb.Items.RemoveAt(names_lb.SelectedIndex);
            else
                MessageBox.Show(
                    Language.getControlText("AINameDoesntChooseForDelete_error", this.Name),
                    Language.getControlText("attention", this.Name),
                    MessageBoxButtons.OK);
        }

        #endregion
    }
}
