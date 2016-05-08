using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class MainForm : Form
    {
        #region --- TODO LIST ---
        //  1. Доделать фильтр по дате
        //  2. Постараться доделать фильтр по имени
        //DONE  3. Возможность смены пользователя, не выходя из приложения
        //DONE  4. Сделать уведомление о прошедших событиях, но еще не отмеченных
        //DONE  5. Изменить способ проверки событий (сейчас проверяются сразу все, сделать так, чтобы проверялись только активные)
        //  6. Доработать выбор времени (можно не выбирать время для предварительного уведомления)
        //DONE  7. Сделать иконку приложения
        //DONE  8. Прикрутить голосовое управление к командам: добавить событие, изменить событие.
        //  9. ПИШИ КОММЕНТАРИИ!!!
        //DONE  10. На детализированной панели не отображается время, когда нужно оповестить человека
        //DONE  11. Может добавить задний фон?
        //DONE  12. Уведомление не одно, а дохрена
        //NOPE  13. Кнопки для отметки событий как выполненных переделать в picturebox-ы
        //DONE  14. Меню настроек
        //DONE  15. В меню редактирования добавить пункт для изменения времени уведомления
        //DONE  16. Запилить свои часы
        //DONE  17. Если оповещение к событию отмечено как произошедшее, а мы меняем его на попозже, то оно не сработает
        //DONE  18. Нужно доделать создание голосового помощника для пользователя при запуске
        //DONE  19. Протестировать добавление/его отсутствие голосового помощника при создании пользователя
        //DONE  20. "Засолить пароли" (хеширование с солью)
        //DONE  21. Сделать Gateway static
        //  22. Сделать небольшой уклон в разные языки для интерфейса (скорее всего 2 файла с текстом)
        //DONE  23. Одиночка для VoiceChecker 
        //DONE  24. Загрузка bookmarks в БД и выгрузка их оттуда. При добавлении сверка с уже исмеющимися.
        //DONE  25. Если создать событие, раскрыть его, дождаться уведомления и шелкнуть по нему, что кнопка назад не работает.
        //DONE  26. Добавить возможность добавлять приложения для запуска их голосом.
        //DONE  27. Доделать голосовой вызов и управление формой EditEventForm (вызывает очень много раз окно + не работает голосовое управление)
        //  28. Тот факт, что панели создаются в форме MainForm плох. Отвязать от нее в отдельный класс.
        #endregion


        #region --- Главные переменные --- 

        NotifyIcon _treyIcon;
        List<Event> _eventList;
        AI _AI;
        
        bool _access;
        int _choosenIndexInEventListNow;

        #endregion


        #region --- Загрузка формы и первичная обработка ---
        
        public MainForm()
        {
            InitializeComponent();    

            this.Hide();
            AuthorizationForm auf = new AuthorizationForm();
            auf.ShowDialog();
            if (auf.DialogResult == DialogResult.OK)
            {
                _access = true;
                this.Show();
            }
            else _access = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!_access) this.Close();
            else
            {
                Control.ControlCollection tempControls = this.Controls;
                Language.setControlsText(ref tempControls, this.Name);

                CreateTreyIcon();            // Создаем объект для сворачивания программы в трей
                FillEventList();             // Заполняем _eventList
                LoadAIForChoosenUser();      // Загружаем голосового помощника для выбранного пользователя
                CheckEndedEvents();          // Проверяем события на просроченность
                Checker.Start();             // Запускаем таймер для уведомлений
                CreatePanels();              // Показываем панели событий
            }
        }

        #endregion


        #region --- Голосовой помощик и его методы --- 

        private void LoadAIForChoosenUser()
        {
            Gateway.loadAIForUser(ref _AI, User.GetUser().UserID);
            if (_AI != null)
            {
                VoiceAnalizer.createVoiceAnalizer(_AI); // Если для пользователя есть голосовой помощник, то активируем его
                VoiceChecker.Start();                   // Запускаем таймер для голосовой обработки
            }
        }

        private void VoiceChecker_Tick(object sender, EventArgs e)
        {
            userVoice_ss.Text = VoiceAnalizer.getVoiceAnalizer().UserCommand;

            try
            {
                if (VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[1] == "event")
                {
                    switch (VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[0])
                    {
                        case "create":
                            addEvent();
                            break;

                        case "open":
                            openEvent(Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]) - 1);
                            break;

                        case "edit":
                            editEvent(Convert.ToInt32(VoiceAnalizer.getVoiceAnalizer().UserCommand.Split('/')[2]) - 1);
                            break;
                    }
                    userVoice_ss.Text = "";
                    VoiceAnalizer.getVoiceAnalizer().clearUserCommand();

                }
            }
            catch { }
        }

        #endregion


        #region --- Создание панелей событий ---

        enum EventInfo
        {
            Compressed,
            Unfolded
        }

        EventInfo _eventPanelStatus = EventInfo.Compressed;

        // Главная панель, на которой будут отображаться все события
        Panel _mainPanel;
        private void CreatePanels()
        { 
            int indentTop = 0;

            // Главная панель
            _mainPanel = new Panel();
            _mainPanel.Width = this.Width;
            _mainPanel.Height = this.Height;
            _mainPanel.AutoScroll = true;
            this.Controls.Add(_mainPanel);

            // Выдаем события по их степени "свежести"
            for (int i = _eventList.Count - 1; i >= 0; i--)
            {
                if ((_showEvent == Filter.InProcess && !_eventList[i].IsHappened && !_eventList[i].IsCanceled) ||
                    (_showEvent == Filter.Ended && !_eventList[i].IsHappened && !_eventList[i].IsCanceled) && _eventList[i].Date < DateTime.Now ||
                    (_showEvent == Filter.Happened && _eventList[i].IsHappened) ||
                    (_showEvent == Filter.Canceled && _eventList[i].IsCanceled) ||
                    (_showEvent == Filter.All) ||
                    (_showEvent == Filter.SearchName && searchName(_eventList[i].Name, _searchTemplate)))
                {
                    // Панель содержания
                    Panel commonEventPanel = new Panel();
                    commonEventPanel.Paint += CommonEventPanel_Paint;
                    commonEventPanel.Left = 10;
                    commonEventPanel.Width = _mainPanel.Width - commonEventPanel.Left * 4;
                    commonEventPanel.Top = indentTop + 30;
                    commonEventPanel.Click += Panel_Click;
                    commonEventPanel.Name = _eventList[i].ID.ToString();

                    if (!_eventList[i].IsHappened && !_eventList[i].IsCanceled)
                    {
                                // Кнопка "Событие произошло"
                                Button HappenedBtn = new Button();
                               // PictureBox HappenedBtn = new PictureBox();
                                HappenedBtn.Name = _eventList[i].ID.ToString();
                                HappenedBtn.Width = 25;
                                HappenedBtn.Height = 25;
                                HappenedBtn.BackColor = Color.Green;
                                HappenedBtn.Text = Language.getControlText("smallPanelHappened_btn", this.Name);
                                HappenedBtn.TextAlign = ContentAlignment.MiddleCenter;
                                HappenedBtn.Left = commonEventPanel.Width - HappenedBtn.Width - 5;
                                HappenedBtn.Top = commonEventPanel.Height - HappenedBtn.Height - 30;
                                HappenedBtn.Click += HappenedBtn_Click;
                                commonEventPanel.Controls.Add(HappenedBtn);

                        // Кнопка "Событие отменено"
                        Button CanceledBtn = new Button();
                        CanceledBtn.Name = _eventList[i].ID.ToString();
                        CanceledBtn.Width = 25;
                        CanceledBtn.Height = 25;
                        CanceledBtn.BackColor = Color.Red;
                        CanceledBtn.Text = Language.getControlText("smallPanelCanceled_btn", this.Name);
                        CanceledBtn.TextAlign = ContentAlignment.MiddleCenter;
                        CanceledBtn.Left = commonEventPanel.Width - HappenedBtn.Width - 5;
                        CanceledBtn.Top = commonEventPanel.Height - HappenedBtn.Height - 5;
                        CanceledBtn.Click += CanceledBtn_Click;
                        commonEventPanel.Controls.Add(CanceledBtn);
                    }

                            // Имя события
                            Label eventName = new Label();
                            eventName.Text = cutText(_eventList[i].Name, 100);
                            eventName.Top = 10;
                            eventName.Left = 10;
                            eventName.Width = commonEventPanel.Width / 2;
                            eventName.Font = new Font("Arial", 11, FontStyle.Bold);
                            eventName.BackColor = Color.Transparent;
                            commonEventPanel.Controls.Add(eventName);

                    // Дата события
                    Label eventDate = new Label();
                    eventDate.Text = Language.getControlText("smallPanelDate", this.Name) + _eventList[i].Date.Day + "."
                                              + _eventList[i].Date.Month + "."
                                              + _eventList[i].Date.Year + "\r\n"
                                  + Language.getControlText("smallPanelTime", this.Name) + _eventList[i].Date.Hour + " : "
                                              + _eventList[i].Date.Minute;
                    eventDate.Left = commonEventPanel.Width - eventDate.Width - 10;
                    eventDate.Top = 10;
                    eventDate.Height = 30;
                    eventDate.Font = new Font("Arial", 7, FontStyle.Italic);
                    eventDate.BackColor = Color.Transparent;
                    eventDate.TextAlign = ContentAlignment.TopRight;
                    commonEventPanel.Controls.Add(eventDate);

                            // Подробности события
                            Label eventText = new Label();
                            eventText.Text = cutText(_eventList[i].Text, 100); 
                            eventText.Left = 10;
                            eventText.Top = eventName.Height + eventName.Top + 10;
                            if (!_eventList[i].IsHappened && !_eventList[i].IsCanceled) eventText.Width = commonEventPanel.Width - eventText.Left * 5; // Кнопки есть
                            else eventText.Width = commonEventPanel.Width - eventText.Left * 2; // Кнопок нет
                            eventText.Height = 30;
                            eventText.BackColor = Color.Transparent;
                            commonEventPanel.Controls.Add(eventText);

                    if (!_eventList[i].IsHappened && !_eventList[i].IsCanceled)
                    {
                        // Кнопка редактирования события
                        Button EditBtn = new Button();
                        EditBtn.Name = _eventList[i].ID.ToString();
                        EditBtn.Text = Language.getControlText("smallPanelEdit_btn", this.Name);
                        EditBtn.TextAlign = ContentAlignment.MiddleCenter;
                        EditBtn.Left = 10;
                        EditBtn.Top = eventText.Top + eventText.Height + 3;
                        EditBtn.Height = 29;
                        EditBtn.Width = 100;
                        EditBtn.Click += EditBtn_Click;
                        EditBtn.BackColor = Color.FromKnownColor(KnownColor.Control);
                        commonEventPanel.Controls.Add(EditBtn);

                        // Выравниваем высоту панели
                        commonEventPanel.Height = EditBtn.Top + EditBtn.Height + 10;
                    }
                    else
                    {
                                // Одна из кнопок нажата, надо отобразить отзыв о том, как все прошло или причину отмены
                                Label note = new Label();
                                if (_eventList[i].IsCanceled)
                                {
                                    note.Text = Language.getControlText("smallPanelCanceledReason", this.Name) + "\r\n";
                                    if (_eventList[i].IsCanceledReason.Trim() != "")
                                    {
                                        note.Text += cutText(_eventList[i].IsCanceledReason, 50);
                                    }
                                    else
                                    {
                                        note.Text += Language.getControlText("smallPanelNone", this.Name);
                                    }
                                }
                                else
                                {
                                    if (_eventList[i].IsHappened)
                                    {
                                        note.Text = Language.getControlText("smallPanelHappenedRecall", this.Name) + "\r\n";
                                        if (_eventList[i].IsHappenedNote.Trim() != "")
                                        {
                                            note.Text += cutText(_eventList[i].IsHappenedNote, 50);
                                        }
                                        else
                                        {
                                            note.Text += Language.getControlText("smallPanelNone", this.Name);
                                        }
                                    }
                                }
                                note.Left = 10;
                                note.Top = eventText.Top + eventText.Height + 3;
                                note.Height = 29;
                                note.Width = commonEventPanel.Width - 20;
                                note.BackColor = Color.Transparent;
                                commonEventPanel.Controls.Add(note);
                        
                        commonEventPanel.Height = note.Top + note.Height + 10;
                    }

                    
                    indentTop += commonEventPanel.Height + 10;

                    // Добавление панели события на главную панель
                    _mainPanel.Controls.Add(commonEventPanel);
                }
            }
            // Дополнительная панель для того, чтобы не было проблем со скроллбаром
            Panel emptyPanel = new Panel();
            emptyPanel.Left = 10;
            emptyPanel.Width = 250 - emptyPanel.Left * 2;
            emptyPanel.Height = 70;
            emptyPanel.Top = indentTop + 30;
            _mainPanel.Controls.Add(emptyPanel);
        }

        // Эта панель служит для отображения подробной информации об определенном событии, 
        // которое мы хотим увидеть в новом окне
        Panel _detailedPanel;
        Button _backToMainFormBtn;

        bool _switchBtwDateAndNotify = false;
        private void CreateDetailedPanel(Event eventForShow)
        {
            _detailedPanel = new Panel();
            _detailedPanel.Width = this.Width;
            _detailedPanel.Height = this.Height;
            this.Controls.Add(_detailedPanel);

            // Кнопка возврата
            _backToMainFormBtn = new Button();
            _backToMainFormBtn.Left = 10;
            _backToMainFormBtn.Top = 30;
            _backToMainFormBtn.Width = 50;
            _backToMainFormBtn.Height = 20;
            _backToMainFormBtn.Text = "<--";
            _backToMainFormBtn.Click += BackToMainFormBtn_Click;
            _detailedPanel.Controls.Add(_backToMainFormBtn);

            // Панель отображения события
            Panel neededEventPanel = new Panel();
            neededEventPanel.Left = 10;
            neededEventPanel.Top = _backToMainFormBtn.Top + _backToMainFormBtn.Height + 10;
            neededEventPanel.Width = _detailedPanel.Width - neededEventPanel.Left * 4;
            neededEventPanel.Paint += NeededEventPanel_Paint;            

            // Имя события
            Label eventName = new Label();
            eventName.Left = 10;
            eventName.Top = 10;
            eventName.Text = eventForShow.Name;
            eventName.Font = new Font("Arial", 11, FontStyle.Bold);
            eventName.Height = 40;
            eventName.Width = neededEventPanel.Width - neededEventPanel.Width / 3;
            eventName.BackColor = Color.Transparent;
            neededEventPanel.Controls.Add(eventName);

            // Дата события или дата поповещения
            Label eventDate = new Label();
            if (!_switchBtwDateAndNotify)
            {
                eventDate.Text = Language.getControlText("bigPanelDate", this.Name) + eventForShow.Date.Day + "."
                                          + eventForShow.Date.Month + "."
                                          + eventForShow.Date.Year + " "
                                          + eventForShow.Date.Hour + ":"
                                          + eventForShow.Date.Minute;
            }
            else
            {
                eventDate.Text = Language.getControlText("bigPanelNotification", this.Name) + eventForShow.NotificationDateTime.Day + "."
                                          + eventForShow.NotificationDateTime.Month + "."
                                          + eventForShow.NotificationDateTime.Year + " "
                                          + eventForShow.NotificationDateTime.Hour + ":"
                                          + eventForShow.NotificationDateTime.Minute;
            }
            eventDate.Name = eventForShow.ID.ToString();
            eventDate.Left = neededEventPanel.Width - eventDate.Width - 10;
            eventDate.Top = 10;
            eventDate.Height = 30;
            eventDate.Font = new Font("Arial", 7, FontStyle.Italic);
            eventDate.BackColor = Color.Transparent;
            eventDate.TextAlign = ContentAlignment.TopRight;
            eventDate.Click += EventDate_Click;
            neededEventPanel.Controls.Add(eventDate);

            // Подробности события
            Label eventText = new Label();
            eventText.Text = eventForShow.Text;
            eventText.Left = 10;
            eventText.Top = eventName.Height + eventName.Top;
            eventText.Width = neededEventPanel.Width - eventText.Left * 2;
            eventText.Height = 200;
            eventText.BackColor = Color.Transparent;
            neededEventPanel.Controls.Add(eventText);

            if (!eventForShow.IsHappened && !eventForShow.IsCanceled)
            {
                // Кнопка редактирования события
                Button EditBtn = new Button();
                EditBtn.Name = eventForShow.ID.ToString();
                EditBtn.Text = Language.getControlText("bigPanelEdit_btn", this.Name); ;
                EditBtn.TextAlign = ContentAlignment.MiddleCenter;
                EditBtn.Left = 10;
                EditBtn.Top = eventText.Top + eventText.Height + 5;
                EditBtn.Height = 29;
                EditBtn.Width = 100;
                EditBtn.Click += EditBtn_Click;
                EditBtn.BackColor = Color.FromKnownColor(KnownColor.Control);
                neededEventPanel.Controls.Add(EditBtn);

                neededEventPanel.Height = EditBtn.Top + EditBtn.Height + 10;

                // Кнопка "Событие произошло"
                Button HappenedBtn = new Button();
                HappenedBtn.Name = eventForShow.ID.ToString();
                HappenedBtn.Width = 75;
                HappenedBtn.Height = 25;
                HappenedBtn.BackColor = Color.Green;
                HappenedBtn.Text = Language.getControlText("bigPanelEventHappened_btn", this.Name);
                HappenedBtn.TextAlign = ContentAlignment.MiddleCenter;
                HappenedBtn.Left = neededEventPanel.Width - HappenedBtn.Width - 85;
                HappenedBtn.Top = EditBtn.Top;
                HappenedBtn.Click += HappenedBtn_Click;
                neededEventPanel.Controls.Add(HappenedBtn);

                // Кнопка "Событие отменено"
                Button CanceledBtn = new Button();
                CanceledBtn.Name = eventForShow.ID.ToString();
                CanceledBtn.Width = 75;
                CanceledBtn.Height = 25;
                CanceledBtn.BackColor = Color.Red;
                CanceledBtn.Text = Language.getControlText("bigPanelEventCanceled_btn", this.Name); ;
                CanceledBtn.TextAlign = ContentAlignment.MiddleCenter;
                CanceledBtn.Left = neededEventPanel.Width - HappenedBtn.Width - 5;
                CanceledBtn.Top = EditBtn.Top;
                CanceledBtn.Click += CanceledBtn_Click;
                neededEventPanel.Controls.Add(CanceledBtn);
            }
            else
            {
                // Одна из кнопок нажата, надо отобразить отзыв о том, как все прошло или причину отмены
                Label note = new Label();
                note.BackColor = Color.Transparent;
                if (eventForShow.IsCanceled)
                {
                    note.Text = Language.getControlText("bigPanelHeppenedRecall", this.Name) + "\r\n";
                    if (eventForShow.IsCanceledReason.Trim() != "")
                    {
                        note.Text += eventForShow.IsCanceledReason;
                    }
                    else
                    {
                        note.Text += note.Text = Language.getControlText("bigPanelNone", this.Name);
                    }
                }
                else
                {
                    if (eventForShow.IsHappened)
                    {
                        note.Text = Language.getControlText("bigPanelCanceledReason", this.Name) + "\r\n";
                        if (eventForShow.IsHappenedNote.Trim() != "")
                        {
                            note.Text += eventForShow.IsHappenedNote;
                        }
                        else
                        {
                            note.Text += Language.getControlText("bigPanelNone", this.Name);
                        }
                    }
                }
                note.Left = 10;
                note.Top = eventText.Top + eventText.Height + 5;
                note.Height = 100;
                note.Width = neededEventPanel.Width - 20;
                neededEventPanel.Controls.Add(note);

                neededEventPanel.Height = note.Top + note.Height + 10;
            }

            _choosenIndexInEventListNow = eventForShow.ID - 1;
            _detailedPanel.Controls.Add(neededEventPanel);
        }

        private void NeededEventPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(0, 0, (sender as Panel).Width, (sender as Panel).Height));
            if (_eventList[_choosenIndexInEventListNow].IsHappened)
            {
                g.DrawImage(CourseWork.Properties.Resources.happened, 0, (sender as Panel).Height - CourseWork.Properties.Resources.happened.Height - 20);
            }
            else
            {
                if (_eventList[_choosenIndexInEventListNow].IsCanceled)
                {
                    g.DrawImage(CourseWork.Properties.Resources.canceled, 0, (sender as Panel).Height - CourseWork.Properties.Resources.canceled.Height - 20);
                }
                else
                {
                    g.DrawImage(CourseWork.Properties.Resources.in_process, 0, (sender as Panel).Height - CourseWork.Properties.Resources.in_process.Height - 20);
                }
            }
        }

        private void CommonEventPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(0, 0, (sender as Panel).Width, (sender as Panel).Height));
            if (_eventList[Convert.ToInt32((sender as Panel).Name) - 1].IsHappened)
            {
                g.DrawImage(CourseWork.Properties.Resources.happened, 0, (sender as Panel).Height - CourseWork.Properties.Resources.happened.Height);
            }
            else
            {
                if (_eventList[Convert.ToInt32((sender as Panel).Name) - 1].IsCanceled)
                {
                    g.DrawImage(CourseWork.Properties.Resources.canceled, 0, (sender as Panel).Height - CourseWork.Properties.Resources.canceled.Height);
                }
                else
                {
                    g.DrawImage(CourseWork.Properties.Resources.in_process, 0, (sender as Panel).Height - CourseWork.Properties.Resources.in_process.Height);
                }
            }
        }

        private void EventDate_Click(object sender, EventArgs e)
        {
            _switchBtwDateAndNotify = !_switchBtwDateAndNotify;
            reCreateDetailForm(_eventList[Convert.ToInt32((sender as Label).Name) - 1]);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            openEvent(Convert.ToInt32((sender as Panel).Name) - 1);
        }
        private void openEvent(int eventID)
        {
            _mainPanel.Hide();
            CreateDetailedPanel(_eventList[eventID]);
            _choosenIndexInEventListNow = eventID;
            _eventPanelStatus = EventInfo.Unfolded;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            editEvent(Convert.ToInt32((sender as Button).Name) - 1);
        }
        private void editEvent(int eventID)
        {
            VoiceChecker.Stop();

            _choosenIndexInEventListNow = eventID;
            EditEventForm eef = new EditEventForm(_eventList[_choosenIndexInEventListNow]);
            eef.ShowDialog();
            if (eef.DialogResult == DialogResult.OK)
            {
                _eventList[_choosenIndexInEventListNow] = eef.CorrectEvent;
                Gateway.updateEventInDB(_eventList[_choosenIndexInEventListNow]);
                VoiceAnalizer.getVoiceAnalizer().refreshGrammar();
                if (_eventPanelStatus == EventInfo.Compressed)
                {
                    reCreateMainForm();
                }
                if (_eventPanelStatus == EventInfo.Unfolded)
                {
                    _mainPanel.Hide();
                    reCreateDetailForm(_eventList[_choosenIndexInEventListNow]);
                }
            }

            VoiceChecker.Start();
        }

        private void CanceledBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr_check_canceled = MessageBox.Show(
                Language.getControlText("setEventAsCanceledAttention", this.Name), 
                Language.getControlText("attention", this.Name), 
                MessageBoxButtons.YesNo);
            if (dr_check_canceled == DialogResult.Yes)
            {
                _choosenIndexInEventListNow = Convert.ToInt32((sender as Button).Name) - 1;
                _eventList[_choosenIndexInEventListNow].setEventIsCanceledTrue();

                DialogResult dr_set_note = MessageBox.Show(
                    Language.getControlText("setReasonOfCancel", this.Name), 
                    Language.getControlText("attention", this.Name), 
                    MessageBoxButtons.YesNo);
                if (dr_set_note == DialogResult.Yes)
                {
                    NoteForm nf = new NoteForm(
                        Language.getControlText("noteCANCReason", this.Name),
                        Language.getControlText("noteCANCReasonDescr", this.Name),
                        Language.getControlText("noteCANC_btn", this.Name),
                        Language.getControlText("noteCANCReason_error", this.Name));
                    nf.ShowDialog();
                    if (nf.DialogResult == DialogResult.OK)
                    {
                        _eventList[_choosenIndexInEventListNow].IsCanceledReason = nf.Note;
                    }
                }

                Gateway.updateEventInDB(_eventList[_choosenIndexInEventListNow]);
                reCreateMainForm();
                if (_eventPanelStatus == EventInfo.Unfolded)
                {
                    _mainPanel.Hide();
                    reCreateDetailForm(_eventList[_choosenIndexInEventListNow]);
                }
            }
        }

        private void HappenedBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr_check_happened = MessageBox.Show(
                Language.getControlText("setEventAsHappenedAttention", this.Name),
                Language.getControlText("attention", this.Name),
                MessageBoxButtons.YesNo);
            if (dr_check_happened == DialogResult.Yes)
            {
                _choosenIndexInEventListNow = Convert.ToInt32((sender as Button).Name) - 1;
                _eventList[_choosenIndexInEventListNow].setEventIsHappenedTrue();

                DialogResult dr_set_note = MessageBox.Show(
                Language.getControlText("setRecallAttention", this.Name),
                Language.getControlText("attention", this.Name),
                MessageBoxButtons.YesNo);
                if (dr_set_note == DialogResult.Yes)
                {
                    NoteForm nf = new NoteForm(
                        Language.getControlText("noteHAPPRecall", this.Name),
                        Language.getControlText("noteHAPPRecallDescr", this.Name),
                        Language.getControlText("noteHAPP_btn", this.Name),
                        Language.getControlText("noteHAPPRecall_error", this.Name));
                    nf.ShowDialog();
                    if (nf.DialogResult == DialogResult.OK)
                    {
                        _eventList[_choosenIndexInEventListNow].IsHappenedNote = nf.Note;
                    }
                }

                Gateway.updateEventInDB(_eventList[_choosenIndexInEventListNow]);
                reCreateMainForm();
                if (_eventPanelStatus == EventInfo.Unfolded)
                {
                    _mainPanel.Hide();
                    reCreateDetailForm(_eventList[_choosenIndexInEventListNow]);
                }
            }
        }

        private void BackToMainFormBtn_Click(object sender, EventArgs e)
        {
            showAllEvents();
        }
        private void showAllEvents()
        {
            _choosenIndexInEventListNow = -1;
            this.Controls.Remove(_detailedPanel);
            this.Controls.Remove(_backToMainFormBtn);
            _eventPanelStatus = EventInfo.Compressed;
            reCreateMainForm();
            _mainPanel.Show();
        }

        // Обновление панелей
        private void reCreateMainForm()
        {
            this.Controls.Remove(_mainPanel);
            CreatePanels();
        }
        private void reCreateDetailForm(Event focusedEvent)
        {
            this.Controls.Remove(_detailedPanel);
            CreateDetailedPanel(focusedEvent);
        }

        // Обрезание текста до состояния частичного вывода в превьюшную панель
        private string cutText(string original, int size)
        {
            if (original.Length < size)
            {
                return original;
            }
            else
            {
                int numberOfSpaceInRow = 0;
                for (int i = 0; i < size; i++)
                {
                    if (original[i] == ' ')
                    {
                        numberOfSpaceInRow++;
                    }
                    else
                    {
                        numberOfSpaceInRow = 0;
                    }

                    if (numberOfSpaceInRow > 3)
                    {
                        return original;
                    }
                }
            }
            string newText = original.Remove(size - 3) + "...";
            return newText;
        }

        #endregion


        #region --- Работа с БД ---

        private void FillEventList()
        {
            List<Event> temp;
            Gateway.loadEventFromDB(out temp);
            User.GetUser().SetEventList(temp);
            _eventList = User.GetUser().EventList;
        }

        #endregion


        #region --- События формы, фильтрация, меню ---

        // Добавить элемент к листу событий
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addEvent();
        }
        private void addEvent()
        {
            VoiceChecker.Stop();

            AddEventForm aef = new AddEventForm();
            aef.ShowDialog();
            if (aef.DialogResult == DialogResult.OK)
            {
                User.GetUser().EventList.Add(aef.getNewEvent());
                Gateway.addEventInDB(aef.getNewEvent(), User.GetUser().EventList.Count);
                VoiceAnalizer.getVoiceAnalizer().refreshGrammar();
            }
            reCreateMainForm();

            VoiceChecker.Start();
        }

        // Изменение размеров главной формы
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            _mainPanel.Width = this.Width;
            _mainPanel.Height = this.Height;
            if (_eventPanelStatus == EventInfo.Compressed)
                reCreateMainForm();
            else
                reCreateDetailForm(_eventList[_choosenIndexInEventListNow]);
        }

        // Выход из приложения
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Смена пользователя
        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.getControlText("changeUserAttention", this.Name), Language.getControlText("attention", this.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // Настройки
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            if (sf.DialogResult == DialogResult.OK)
            {

            }
        }

        // Фильтрация событий
        enum Filter
        {
            All,            // Все события
            InProcess,      // События, которые еще совершатся
            Ended,          // События, которые совершились (или нет), но не помечены как таковые
            Happened,       // События, которые произошли
            Canceled,       // Отмененные события
            SearchName,     // Поиск по имени события
            SearchDate      // Поиск по дате
        }

        Filter _showEvent = Filter.All;
        string _searchTemplate = "";

        private void allEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.All;
            reCreateMainForm();
        }

        private void inProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.InProcess;
            reCreateMainForm();
        }

        private void onlyHappenedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.Happened;
            reCreateMainForm();
        }

        private void onlyCanceledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.Canceled;
            reCreateMainForm();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.SearchName;

            NoteForm nf = new NoteForm(
                Language.getControlText("noteSRCHName", this.Name),
                Language.getControlText("noteSRCHNameDescr", this.Name),
                Language.getControlText("noteSRCH_btn", this.Name),
                Language.getControlText("noteSRCHName_error", this.Name));
            nf.ShowDialog();
            if (nf.DialogResult == DialogResult.OK)
            {
                _searchTemplate = nf.Note;
            }

            reCreateMainForm();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showEvent = Filter.SearchDate;

            NoteForm nf = new NoteForm(
                Language.getControlText("noteSRCHDate", this.Name),
                Language.getControlText("noteSRCHDateDescr", this.Name),
                Language.getControlText("noteSRCH_btn", this.Name),
                Language.getControlText("noteSRCHDate_error", this.Name));
            nf.ShowDialog();
            if (nf.DialogResult == DialogResult.OK)
            {
                string neededDate = nf.Note;
            }

            reCreateMainForm();
        }

        // Поиск пока что только по первому слову
        private bool searchName(string eventName, string template)
        {
            int i = 0;
            while(i < template.Length)
            {
                if (eventName[i] != template[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        #endregion


        #region --- Иконка в трее ---

        // Создаем NotifyIcon _treyIcon, которая будет отвечать за иконку в трее
        private void CreateTreyIcon()
        {
            _treyIcon = new NotifyIcon();
            _treyIcon.Icon = CourseWork.Properties.Resources.Icon;
            _treyIcon.DoubleClick += _treyIcon_DoubleClick;
        }

        // Двойное нажатие по иконке
        private void _treyIcon_DoubleClick(object sender, EventArgs e)
        {
            _treyIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        // Сворачивание формы
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                _treyIcon.Visible = true;
            }
        }

        #endregion


        #region --- Уведомления об приближающемся событии ---

        NotifyIcon _notification;           // Уведомление
        int _indexCheckingEventNow = -1;    // Индекс, который отвечает за событие, которое отображается сейчас

        // Таймер каждые 10000 мкс. производит проверку событий на их вызов
        private void Checker_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _eventList.Count; i++)
            {
                if (CheckTime(_eventList[i]))
                {
                    _indexCheckingEventNow = i;
                    Notification(_eventList[i].Name, Language.getControlText("notificationAlert", this.Name) + " " + _eventList[i].Date, ToolTipIcon.Warning);
                    break;
                }
            }
        }

        // Проверка, нужно ли вывести уведомление для следующего события
        private bool CheckTime(Event eventForCheck)
        {
            if (eventForCheck.NotificationDateTime <= DateTime.Now &&
                !eventForCheck.NotificationGot && !eventForCheck.IsHappened && !eventForCheck.IsCanceled)  return true;
           
            return false;
        }

        // Сам вывод уведомления
        private void Notification(string title, string info, ToolTipIcon iconType)
        {
            _notification = new NotifyIcon();
            _notification.BalloonTipClicked += _notification_BalloonTipClicked;
            _notification.BalloonTipClosed += _notification_BalloonTipClosed;
            _notification.Visible = true;
            _notification.Icon = CourseWork.Properties.Resources.Icon;
            _notification.ShowBalloonTip(1000, title, info, iconType);
        }

        // Уведомление ушло
        private void _notification_BalloonTipClosed(object sender, EventArgs e)
        {
            _notification.Visible = false;
        }

        // По уведомлению кликнул пользователь, значит открываем программу и показываем
        // подробную панель для данного события
        private void _notification_BalloonTipClicked(object sender, EventArgs e)
        {
            // Если на момент сворачивания приложения было открыто событие,
            // то мы его сами сворачиваем, иначе не будет адекватного вывода
            if (_eventPanelStatus == EventInfo.Unfolded)
                showAllEvents();

            // Разворачиваем приложение
            _notification.Visible = false;
            setNotificationShowed();
            this.WindowState = FormWindowState.Normal;

            // Показываем событие
            _choosenIndexInEventListNow = _indexCheckingEventNow;
            openEvent(_choosenIndexInEventListNow);
        }

        // Указываем, что сообщение дошло до глаза пользователя
        private void setNotificationShowed()
        {
            _eventList[_indexCheckingEventNow].NotificationGot = true;
            Gateway.updateEventInDB(_eventList[_indexCheckingEventNow]);
        }

        #endregion


        #region --- Уведомления о том, что прошли некоторые события ---

        // При запуске программы проверяем, есть ли у нас события, которые произошли, но еще не отмечены
        private void CheckEndedEvents()
        {
            if (CompareDateNowAndDateOfEvents())
            {
                DialogResult dr = MessageBox.Show(
                Language.getControlText("uncheckedEventsAttention", this.Name),
                Language.getControlText("attention", this.Name),
                MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    _showEvent = Filter.Ended;
                }
                else if (dr == DialogResult.No)
                {
                    _showEvent = Filter.All;
                }
            }
            else
            {
                _showEvent = Filter.All;
            }
        }

        // Ищем события, которые еще не отмечены, но уже совершились
        private bool CompareDateNowAndDateOfEvents()
        {
            for (int i = 0; i < _eventList.Count; i++)
            {
                if (_eventList[i].Date < DateTime.Now &&
                    !_eventList[i].IsHappened &&
                    !_eventList[i].IsCanceled)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion
    }
}