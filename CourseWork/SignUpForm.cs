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
                        if (createAIChoose_cb.Checked)
                        {
                            Gateway.addNewAIInDB(new AI(Gateway.getCountOfTableRows("User"), getNames(), maleGenderChoose_rb.Checked));
                        }
                        Gateway.addNewUserInDB(newLogin.Text, PasswordStorage.CreateHash(newPassword.Text));
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Language.getElementText("equPasswords_error", this.Name));
                        newPassword.Text = "";
                        newPasswordConfirm.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(Language.getElementText("userAlreadyExist_error", this.Name));
                }
            }
            else
            {
                if (newPassword.Text == "" && newLogin.Text == "")
                    MessageBox.Show(Language.getElementText("LogOrPassIsEmpty_error", this.Name));
                if (createAIChoose_cb.Checked && ((!maleGenderChoose_rb.Checked && !femaleSexChoose_rb.Checked) || names_lb.Items.Count <= 0))
                    MessageBox.Show(Language.getElementText("AIProperties_error", this.Name));
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
                    Language.getElementText("noteAIName", this.Name),
                    Language.getElementText("noteAINameDescr", this.Name),
                    Language.getElementText("noteAI_btn", this.Name),
                    Language.getElementText("noteAIAttention", this.Name));
                nf.ShowDialog();

                if (nf.DialogResult == DialogResult.OK)
                {
                    if (nf.Note.Length <= 20)
                        names_lb.Items.Add(TranslitWord.GetTranslit(nf.Note));
                    else
                        MessageBox.Show(
                            Language.getElementText("AINameLength_error", this.Name),
                            Language.getElementText("attention", this.Name), 
                            MessageBoxButtons.OK);
                }
            }
            else
                MessageBox.Show(
                        Language.getElementText("AINamesCount_error", this.Name),
                        Language.getElementText("attention", this.Name),
                        MessageBoxButtons.OK);
        }

        // Удаление имени
        private void deleteName_btn_Click(object sender, EventArgs e)
        {
            if (names_lb.SelectedIndex > 0)
                names_lb.Items.RemoveAt(names_lb.SelectedIndex);
            else
                MessageBox.Show(
                    Language.getElementText("AINameDoesntChooseForDelete_error", this.Name),
                    Language.getElementText("attention", this.Name),
                    MessageBoxButtons.OK);
        }

        #endregion
    }
}
