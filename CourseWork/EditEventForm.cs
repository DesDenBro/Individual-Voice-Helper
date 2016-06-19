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
        private Clock _notification;

        public Event CorrectEvent { get { return _tempEvent; } }

        #endregion


        #region --- Методы редактирования события ---

        public EditEventForm(Event eventForEdit)
        {
            InitializeComponent();

            Control.ControlCollection tempControls = this.Controls;
            Language.setControlsText(ref tempControls, this.Name);

            _tempEvent = eventForEdit;
            eventName_tb.Text = eventForEdit.Name;
            eventText_tb.Text = eventForEdit.Text;

            _date = new Clock(Language.getElementText("blockNameDate", this.Name), 10, eventName_tb.Bottom + 10);
            _date.setTime(eventForEdit.Date);
            this.Controls.Add(_date.ClockPanel);

            _notification = new Clock(Language.getElementText("blockNameNotification", this.Name), _date.ClockPanel.Right + 3, _date.ClockPanel.Top);
            _notification.setTime(eventForEdit.NotificationDateTime);
            this.Controls.Add(_notification.ClockPanel);

            if (VoiceAnalizer.getVoiceAnalizer() != null) voiceChecker.Start();
        }

        private void editEvent_btn_Click(object sender, EventArgs e)
        {
            if (eventName_tb.Text != "" &&
                    eventText_tb.Text != "" &&
                    _date.ChoosenDateTime >= DateTime.Now &&
                    _notification.ChoosenDateTime >= DateTime.Now &&
                    _notification.ChoosenDateTime < _date.ChoosenDateTime)
            {
                _tempEvent.Name = eventName_tb.Text;
                _tempEvent.Text = eventText_tb.Text;
                _tempEvent.Date = _date.ChoosenDateTime;
                if (_tempEvent.NotificationDateTime < DateTime.Now)
                {
                    _tempEvent.NotificationGot = false;
                }
                _tempEvent.NotificationDateTime = _notification.ChoosenDateTime;

                if (VoiceAnalizer.getVoiceAnalizer() != null) voiceChecker.Stop();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(Language.getElementText("wroteDataIncorrect_error", this.Name));
            }
        }

        #endregion


        #region --- Управление голосом ---

        private void readDate(string type, string date)
        {
            DateTime tempDate;
            DateTime.TryParse(date, out tempDate);

            if (type == "main") _date.setDate(tempDate);
            if (type == "notification") _notification.setDate(tempDate);
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
                        case "notification time":
                            _notification.setTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[0]),
                                Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[1]), 0)); break;

                        case "event date": readDate("main", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                        case "notification date": readDate("notification", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                    }

                    voiceCommand_ss.Text = "";
                }
                catch { }
            }
        }

        #endregion
    }
}
