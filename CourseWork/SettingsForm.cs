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
    public partial class SettingsForm : Form
    {
        #region --- Главные переменные ---

        // Элементы в listbox
        Panel[] _allPanels;

        #endregion


        #region --- Загрузка формы ---

        public SettingsForm()
        {
            InitializeComponent();

            Control.ControlCollection tempControls = this.Controls;
            Language.setControlsText(ref tempControls, this.Name);

            _allPanels = new Panel[] { Common_pan, Profile_pan, VoiceHelper_pan };

            Common_pan.Tag = Language.getControlText("Common_panTag", this.Name);
            Profile_pan.Tag = Language.getControlText("Profile_panTag", this.Name);
            VoiceHelper_pan.Tag = Language.getControlText("VoiceHelper_panTag", this.Name);

            this.Size = new Size(577, 336);

            // Заполняем listbox нужными переменными.
            foreach (var panel in _allPanels) { menu_lb.Items.Add(panel.Tag); }

            // Если голосовой помощник не создан для данного пользователя, 
            // то и вкладка для редактирования данных, связанных с ним, нам не нужна.
            if (VoiceAnalizer.getVoiceAnalizer() == null)
                foreach (Control control in _allPanels[2].Controls)
                { control.Enabled = false; }
        }

        private void menu_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если пользователь ткнул в пустоту в Listboxе, то остается то же меню, что было до щелчка.
            if (menu_lb.SelectedIndex != -1)
            {
                foreach (var panel in _allPanels) panel.Hide();

                _allPanels[menu_lb.SelectedIndex].Show();
                _allPanels[menu_lb.SelectedIndex].Location = Common_pan.Location;
            }
        }

        #endregion


        #region --- Вкладка Voice helper ---

        private void ControlBM_btn_Click(object sender, EventArgs e)
        {
            ControlBookmarksForm cbf = new ControlBookmarksForm();
            cbf.ShowDialog();
            if (cbf.DialogResult == DialogResult.OK)
            {
                VoiceAnalizer.getVoiceAnalizer().Bookmarks = cbf.Bookmarks;
                VoiceAnalizer.getVoiceAnalizer().refreshGrammar();
            }
        }

        private void controlPrograms_btn_Click(object sender, EventArgs e)
        {
            ControlProgramsForm cpf = new ControlProgramsForm();
            cpf.ShowDialog();
            if (cpf.DialogResult == DialogResult.OK)
            {
                VoiceAnalizer.getVoiceAnalizer().Programs = cpf.Programs;
                VoiceAnalizer.getVoiceAnalizer().refreshGrammar();
            }
        }

        private void showCommands_btn_Click(object sender, EventArgs e)
        {
            CommandListForm clf = new CommandListForm();
            clf.Show();
        }

        #endregion


        private void languages_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.getControlText("changeLanguageAttention", this.Name), Language.getControlText("attention", this.Name), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (languages_cb.SelectedItem.ToString())
                {
                    case "English": CourseWork.Properties.Settings.Default.Language = "eng"; break;
                    case "Русский": CourseWork.Properties.Settings.Default.Language = "rus"; break;
                }

                CourseWork.Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
}
