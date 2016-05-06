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
            _allPanels = new Panel[] { Common_pan, Profile_pan, VoiceHelper_pan };

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
    }
}
