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
        string[] _itemsInListbox = { "Common", "Profile", "Voice helper" };

        #endregion

        #region --- Загрузка формы ---

        public SettingsForm()
        {
            InitializeComponent();

            this.Size = new Size(577, 336);

            // Заполняем listbox нужными переменными.
            menu_lb.Items.Add(_itemsInListbox[0]);
            menu_lb.Items.Add(_itemsInListbox[1]);
            // Если голосовой помощник не создан для данного пользователя, то и вкладка для редактирования
            // данных, связанных с ним, нам не нужна.
            if (VoiceAnalizer.getVoiceAnalizer() != null) menu_lb.Items.Add(_itemsInListbox[2]);

            // Показываем первую панель и прячем остальные.
            Common_pan.Show();
            Profile_pan.Hide();
            VoiceHelper_pan.Hide();
        }

        private void menu_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Если пользователь ткнул в пустоту в Listboxе, то остается то же меню, что было до щелчка.
            if (menu_lb.SelectedIndex != -1)
            {
                Common_pan.Hide();
                Profile_pan.Hide();
                VoiceHelper_pan.Hide();

                // Common.
                if (menu_lb.SelectedItem.ToString() == _itemsInListbox[0])
                { Common_pan.Show(); return; }

                // Profile.
                if (menu_lb.SelectedItem.ToString() == _itemsInListbox[1])
                { Profile_pan.Show(); Profile_pan.Location = Common_pan.Location; return; }

                // Voice helper.
                if (menu_lb.SelectedItem.ToString() == _itemsInListbox[2])
                { VoiceHelper_pan.Show(); VoiceHelper_pan.Location = Common_pan.Location; return; }
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

        private void reconnectToMicr_btn_Click(object sender, EventArgs e)
        {
            //VoiceAnalizer.getVoiceAnalizer().setDefaultRecordDevice();
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

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            CommandListForm clf = new CommandListForm();
            clf.Show();
        }
    }
}
