using System;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AddEventForm : Form
    {
        #region --- Главные переменные ---
        
        Event _newEvent;
        Clock _date;
        Clock _notification;

        #endregion


        #region --- Методы для добавления события ---

        // Конструктор
        public AddEventForm()
        {
            InitializeComponent();

            Control.ControlCollection tempControls = this.Controls;
            Language.setControlsText(ref tempControls, this.Name);

            _date = new Clock(Language.getControlText("blockNameDate", this.Name), 10, eventName_tb.Bottom + 10);
            this.Controls.Add(_date.ClockPanel);

            _notification = new Clock(Language.getControlText("blockNameNotification", this.Name), _date.ClockPanel.Right + 3, _date.ClockPanel.Top);
            this.Controls.Add(_notification.ClockPanel);

            if (VoiceAnalizer.getVoiceAnalizer() != null) voiceChecker.Start();
        }

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

                        case "event time": _date.setTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[0]),
                            Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[1]), 0)); break;
                        case "notification time": _notification.setTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                            Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[0]),
                            Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2].Split(' ')[1]), 0)); break;

                        case "event date": readDate("main", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                        case "event notification date": readDate("notification", VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]); break;
                    }

                    voiceCommand_ss.Text = "";
                }
                catch { }
            }
        }

        // Кнопка добавления события
        private void createEvent_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventName_tb.Text != "" &&
                    eventText_tb.Text != "" &&
                    _date.ChoosenDateTime >= DateTime.Now &&
                    _notification.ChoosenDateTime >= DateTime.Now &&
                    _notification.ChoosenDateTime < _date.ChoosenDateTime)
                {
                    _newEvent = new Event(User.GetUser().EventList.Count + 1,
                                         eventName_tb.Text,
                                         eventText_tb.Text,
                                         _date.ChoosenDateTime,
                                         false,
                                         "",
                                         false,
                                         "",
                                         _notification.ChoosenDateTime,
                                         false);

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(Language.getControlText("wroteDataIncorrect_error", this.Name));
                }
            }
            catch { MessageBox.Show(Language.getControlText("someMistake", this.Name)); }   
        }

        // Забрать готовое событие
        public Event getNewEvent()
        {
            return _newEvent;
        }

        #endregion
    }
}