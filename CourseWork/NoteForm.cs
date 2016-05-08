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
    public partial class NoteForm : Form
    {
        #region --- Главные переменные и свойства ---

        private string _note;
        private string _emptyFieldErrorText;

        public string Note { get { return _note; } }
        #endregion


        #region --- Методы для обработки заметки ---

        public NoteForm(string formName, string needInfo, string btnName, string emptyFieldErrorText)
        {
            InitializeComponent();

            this.Text = formName;
            text_l.Text = needInfo;
            send_btn.Text = btnName;
            _emptyFieldErrorText = emptyFieldErrorText;
        }

        public NoteForm(string formName, string needInfo, string btnName, string emptyFieldErrorText, string wroteTextInTextbox)
        {
            InitializeComponent();

            this.Text = formName;
            text_l.Text = needInfo;
            send_btn.Text = btnName;
            _emptyFieldErrorText = emptyFieldErrorText;
            note_tb.Text = wroteTextInTextbox;
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (note_tb.Text.Trim() != "")
            {
                _note = note_tb.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(_emptyFieldErrorText, "Attention!", MessageBoxButtons.OK);  
        }

        #endregion
    }
}
