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
    public partial class EditEventForm : Form
    {
        #region --- Главные переменные и свойства ---

        private Event _tempEvent;
        private Clock _date;
        private Clock _notify;

        public Event CorrectEvent { get { return _tempEvent; } }

        #endregion

        #region --- Методы редактирования события ---

        public EditEventForm(Event eventForEdit)
        {
            InitializeComponent();
            _tempEvent = eventForEdit;
            eventName_tb.Text = eventForEdit.Name;
            eventText_tb.Text = eventForEdit.Text;

            _date = new Clock("Date", 10, eventName_tb.Bottom + 10);
            _date.setTime(eventForEdit.Date);
            this.Controls.Add(_date.ClockPanel);

            _notify = new Clock("Time to notify", _date.ClockPanel.Right + 3, _date.ClockPanel.Top);
            _notify.setTime(eventForEdit.TimeToGetNotify);
            this.Controls.Add(_notify.ClockPanel);

            voiceChecker.Start();
        }

        private void editEvent_btn_Click(object sender, EventArgs e)
        {
            if (eventName_tb.Text != "" &&
                    eventText_tb.Text != "" &&
                    _date.ChoosenDateTime >= DateTime.Now &&
                    _notify.ChoosenDateTime >= DateTime.Now &&
                    _notify.ChoosenDateTime < _date.ChoosenDateTime)
            {
                _tempEvent.Name = eventName_tb.Text;
                _tempEvent.Text = eventText_tb.Text;
                _tempEvent.Date = _date.ChoosenDateTime;
                if (_tempEvent.TimeToGetNotify < DateTime.Now)
                {
                    _tempEvent.NotifyGot = false;
                }
                _tempEvent.TimeToGetNotify = _notify.ChoosenDateTime;

                voiceChecker.Stop();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Определенные данные введены некорректно!");
            }
        }

        #endregion

        #region --- Управление голосом ---

        private void readDate(string type, string date)
        {
            DateTime tempDate;
            DateTime.TryParse(date, out tempDate);

            if (type == "main") _date.setDate(tempDate);
            if (type == "notify") _notify.setDate(tempDate);
        }

        private void voiceChecker_Tick(object sender, EventArgs e)
        {
            voiceCommand_ss.Text = VoiceAnalizer.getVoiceAnalizer().UserCommand;

            if (VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[0] == "set")
            {
                try
                {
                    switch (VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[1])
                    {
                        case "event name": eventName_tb.Text = VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]; break;

                        case "event text": eventText_tb.Text = VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]; break;

                        case "event time":
                            _date.setTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                 Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[0]),
                                 Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[1]), 0)); break;
                        case "notify time":
                            _notify.setTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[0]),
                                Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[1]), 0)); break;

                        case "event date": readDate("main", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                        case "event notify date": readDate("notify", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                    }

                    voiceCommand_ss.Text = "";
                }
                catch { }
            }
        }

        #endregion
    }
}
