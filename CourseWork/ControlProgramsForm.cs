using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CourseWork
{
    public partial class ControlProgramsForm : Form
    {
        private List<ComputerProgram> _programs;

        private List<ComputerProgram> _programsForAddInDB = new List<ComputerProgram>();
        private List<ComputerProgram> _programsForDeleteFromDB = new List<ComputerProgram>();

        public List<ComputerProgram> Programs { get { return _programs; } }

        private bool _smthChanged = false;

        public ControlProgramsForm()
        {
            InitializeComponent();
            _programs = VoiceAnalizer.getVoiceAnalizer().Programs;

            foreach (var item in _programs)
                programs_cb.Items.Add(item.Name); 
        }

        private void programs_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            path_tb.Text = _programs[programs_cb.SelectedIndex].Path;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = Language.getControlText("filterFiles", this.Name) + " exe|*.exe|" +  Language.getControlText("filterLinks", this.Name) + " lnk|*.lnk" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                NoteForm nf = new NoteForm(
                    Language.getControlText("notePRName", this.Name),
                    Language.getControlText("notePRNameDiscr", this.Name),
                    Language.getControlText("notePR_btn", this.Name),
                    Language.getControlText("notePRNameAttention", this.Name),
                    ofd.SafeFileName);
                nf.ShowDialog();

                if (nf.DialogResult == DialogResult.OK)
                {
                    _programs.Add(new ComputerProgram(nf.Note, path));
                    _programsForAddInDB.Add(_programs[_programs.Count - 1]);
                    programs_cb.Items.Add(nf.Note);
                    _smthChanged = true;
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                Language.getControlText("deletePRAttention", this.Name),
                Language.getControlText("attention", this.Name),
                MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                _programsForDeleteFromDB.Add(_programs[programs_cb.SelectedIndex]);
                _programs.Remove(_programs[programs_cb.SelectedIndex]);
                programs_cb.Items.RemoveAt(programs_cb.SelectedIndex);
                path_tb.Text = "";
                _smthChanged = true;
            }
        }

        private void testProgram_btn_Click(object sender, EventArgs e)
        {
            Process.Start(_programs[programs_cb.SelectedIndex].Path);
        }

        private void ControlProgramsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_smthChanged)
            {
                DialogResult dr = MessageBox.Show(
                Language.getControlText("programCloseAttention", this.Name),
                Language.getControlText("attention", this.Name),
                MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    // Сначала добавляем новые программы.
                    foreach (var item in _programsForAddInDB)
                        Gateway.addNewProgramInDB(item);

                    // И удаляем нужные.
                    foreach (var item in _programsForDeleteFromDB)
                        Gateway.deleteProgramFromDB(item);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
