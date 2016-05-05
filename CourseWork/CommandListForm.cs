using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class CommandListForm : Form
    {
        #region --- Главные переменные ---

        Dictionary<string, string[]> _commands = new Dictionary<string, string[]>();
        List<string> _formsNames = new List<string>();
        string _activeFormName;

        #endregion


        #region --- Загрузка формы ---

        // Выгрузка комманд из файла
        public CommandListForm()
        {
            _activeFormName = Form.ActiveForm.Name;

            InitializeComponent();

            foreach (var part in CourseWork.Properties.Resources.Commands.Split('\n'))
            {
                _formsNames.Add(part.Split('|')[0].Trim());
                _commands.Add(part.Split('|')[0].Trim(), part.Split('|')[1].Split('/'));
            }    
        }

        private void CommandListForm_Load(object sender, EventArgs e)
        {
            createPanels();
        }

        #endregion


        #region --- Панели выбора ---

        Panel _commandsPanel;
        private void createPanels()
        {
            Panel mainPanel = new Panel();
            mainPanel.Location = new Point(5, 5);
            mainPanel.Size = new Size(this.Width - mainPanel.Location.X * 5, this.Height - mainPanel.Location.Y * 4);

            int YStep = 0;
            foreach (var name in _formsNames)
            {
                Panel formNamePanel = new Panel();
                formNamePanel.Name = name;
                formNamePanel.Click += FormNamePanel_Click;
                formNamePanel.Paint += FormNamePanel_Paint;
                formNamePanel.Size = new Size(mainPanel.Width / 3, 50);
                formNamePanel.Location = new Point(0, YStep);
                YStep += formNamePanel.Height + 5;

                Label formNamePanel_Name = new Label();
                formNamePanel_Name.Name = name;
                formNamePanel_Name.Location = new Point(5, formNamePanel.Height / 2);
                formNamePanel_Name.Text = name;
                formNamePanel_Name.Click += FormNamePanel_Click;
                formNamePanel_Name.BackColor = Color.Transparent;
                formNamePanel.Controls.Add(formNamePanel_Name);

                mainPanel.Controls.Add(formNamePanel);
            }

            _commandsPanel = new Panel();
            _commandsPanel.Paint += _commandsPanel_Paint;
            _commandsPanel.Location = new Point(mainPanel.Width / 3 - 1, 0);
            _commandsPanel.Size = new Size(mainPanel.Width - mainPanel.Width / 3, mainPanel.Height - 30);
            _commandsPanel.BackColor = Color.White;
            if (_commands.ContainsKey(_activeFormName))
            {
                showCommandsForChoosenForm(_activeFormName);
            }
            else
            {
                showCommandsForChoosenForm(_formsNames[0]);
            }

            mainPanel.Controls.Add(_commandsPanel);

            this.Controls.Add(mainPanel);
        }

        private void _commandsPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawBorders((sender as Panel), g);
        }

        private void FormNamePanel_Click(object sender, EventArgs e)
        {
            _commandsPanel.Controls.Clear();
            showCommandsForChoosenForm((sender as Control).Name);
            _activePanelName = (sender as Control).Name;
            Refresh();
        }

        string _activePanelName = "";
        private void FormNamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if ((sender as Panel).Name == _activePanelName)
                g.FillRectangle(new SolidBrush(Color.Coral), new Rectangle(0, 0, (sender as Panel).Width, (sender as Panel).Height));
            else
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, (sender as Panel).Width, (sender as Panel).Height));

            drawBorders((sender as Panel), g);
        }

        private void drawBorders(Panel panel, Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(0, 0, panel.Width, panel.Height));
        }

        #endregion


        #region Панели комманд

        private void showCommandsForChoosenForm(string name)
        {
            string[] commandsForChoosenForm;
            _commands.TryGetValue(name, out commandsForChoosenForm);

            int YStep = 5;
            foreach (var cmd in commandsForChoosenForm)        
            {
                if (cmd.Trim() != "")
                {
                    Panel cmdPanel = new Panel();
                    cmdPanel.Location = new Point(5, YStep);
                    cmdPanel.Paint += CmdPanel_Paint;
                    cmdPanel.Size = new Size(_commandsPanel.Width - cmdPanel.Location.X * 2, 40);
                    cmdPanel.BackColor = Color.Snow;
                    YStep += cmdPanel.Height + 2;

                    Label cmdPanelText_Name = new Label();
                    cmdPanelText_Name.Location = new Point(5, 5);
                    cmdPanelText_Name.Size = new Size(cmdPanel.Width - cmdPanelText_Name.Location.X * 2, 15);
                    cmdPanelText_Name.Text = cmd.Split(':')[0].Trim();
                    cmdPanelText_Name.BackColor = Color.Transparent;
                    cmdPanel.Controls.Add(cmdPanelText_Name);

                    Label cmdPanelText_Description = new Label();
                    cmdPanelText_Description.Location = new Point(5, 20);
                    cmdPanelText_Description.Size = new Size(cmdPanel.Width - cmdPanelText_Description.Location.X * 2, 15);
                    cmdPanelText_Description.Text = cmd.Split(':')[1].Trim();
                    cmdPanelText_Description.BackColor = Color.Transparent;
                    cmdPanel.Controls.Add(cmdPanelText_Description);

                    _commandsPanel.Controls.Add(cmdPanel);
                }
            }
        }

        private void CmdPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawBorders((sender as Panel), g);
        }

        #endregion
    }
}
