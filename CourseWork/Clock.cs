using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseWork
{
    public class Clock
    {
        #region --- Главные переменные и свойства ---

        // Панели, которые используются для демонстрации часов
        private Panel _panel;
        private PictureBox _pictureBoxForClock;
        private DateTimePicker _date;
        private Label _timeInString;
        private PictureBox _sun, _moon;
        
        // Хранение координат, времени и уже заданных точек     
        private int _mouseX, _mouseY;
        private int _hour, _minute;
        private Point _pointForHour, _pointForMinute;
        private int _dayTime = 12; // значение 0 : 00 - 11, значение 12 : 12 - 23

        // Свойства на отправку в другой класс
        public Panel ClockPanel { get { return _panel; } }
        public DateTime ChoosenDateTime { get { return new DateTime(_date.Value.Year, _date.Value.Month, _date.Value.Day, _hour, _minute, 0); } }

        #endregion

        // Конструктор для часов
        public Clock(string name, int xPosition, int yPosition)
        {
            // Панель, где все лежит
            _panel = new Panel();
            _panel.Left = xPosition;
            _panel.Top = yPosition;
            _panel.Width = 175;
            _panel.Height = 150;
            _panel.BorderStyle = BorderStyle.FixedSingle;
            //_panel.BackColor = Color.Green;

            // Назначение блока
            Label blockName = new Label();
            blockName.Left = 5;
            blockName.Top = 5;
            blockName.Text = name;
            _panel.Controls.Add(blockName);

            // Дата
            _date = new DateTimePicker();
            _date.Left = 10;
            _date.Top = blockName.Bottom;
            _date.Width = _panel.Width - 22;
            _date.Value = DateTime.Now;
            _panel.Controls.Add(_date);

            // Время
            _pictureBoxForClock = new PictureBox();
            _pictureBoxForClock.Left = 0;
            _pictureBoxForClock.Top = _date.Bottom + 5;
            _pictureBoxForClock.Width = 100;
            _pictureBoxForClock.Height = 100;
            _pictureBoxForClock.MouseClick += _pictureBoxForClock_MouseClick;
            _pictureBoxForClock.Paint += _pictureBoxForClock_Paint;
            _panel.Controls.Add(_pictureBoxForClock);

            // label для времени
            _timeInString = new Label();
            _timeInString.Left = _pictureBoxForClock.Right;
            _timeInString.Top = _pictureBoxForClock.Top + 5;
            _timeInString.Text = "Hours:\r\n0 \r\nMinutes: \r\n0";
            _timeInString.Height = _pictureBoxForClock.Height / 2;
            _panel.Controls.Add(_timeInString);

            // День и вечер
            _sun = new PictureBox();
            _sun.Left = _timeInString.Left;
            _sun.Top = _timeInString.Bottom + 5;
            _sun.Width = 32;
            _sun.Height = 32;
            _sun.BackgroundImage = CourseWork.Properties.Resources.sun_light;
            _sun.Click += _sun_Click;
            _panel.Controls.Add(_sun);

            // Ночь и утро
            _moon = new PictureBox();
            _moon.Left = _sun.Right + 5;
            _moon.Top = _timeInString.Bottom + 5;
            _moon.Width = 32;
            _moon.Height = 32;
            _moon.BackgroundImage = CourseWork.Properties.Resources.moon;
            _moon.Click += _moon_Click;
            _panel.Controls.Add(_moon);

            _pictureBoxForClock.Refresh();
        }

        // День и вечер
        private void _sun_Click(object sender, EventArgs e)
        {
            _dayTime = 12;
            _sun.BackgroundImage = CourseWork.Properties.Resources.sun_light;
            _moon.BackgroundImage = CourseWork.Properties.Resources.moon;
        }

        // Ночь и утро
        private void _moon_Click(object sender, EventArgs e)
        {
            _dayTime = 0;
            _sun.BackgroundImage = CourseWork.Properties.Resources.sun;
            _moon.BackgroundImage = CourseWork.Properties.Resources.moon_light;
        }

        public void setDate(DateTime date)
        {
            _date.Value = date;
        }

        // Установить время на часах
        public void setTime(DateTime dateTime)
        {
            //_date.va = dateTime;

            _hour = dateTime.Hour;
            if (_hour >= 12)
            {
                _dayTime = 12;
                _sun.BackgroundImage = CourseWork.Properties.Resources.sun_light;
                _moon.BackgroundImage = CourseWork.Properties.Resources.moon;
            }
            else
            {
                _dayTime = 0;
                _sun.BackgroundImage = CourseWork.Properties.Resources.sun;
                _moon.BackgroundImage = CourseWork.Properties.Resources.moon_light;
            }

            _minute = dateTime.Minute;

            _timeInString.Text = "Hours:\r\n" + _hour.ToString() + "\r\nMinutes: \r\n" + _minute.ToString();

            _pictureBoxForClock.Refresh();
        }

        // Определение положения стрелки
        private void _pictureBoxForClock_MouseClick(object sender, MouseEventArgs e)
        {
            _mouseX = e.X;
            _mouseY = e.Y;

            int tempAngle = (int)(findAngle(new Point(_mouseX, _mouseY)) * 180.0 / Math.PI + 180);

            // От выбора, какая кнопка нажата, будет определенное действие
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _pointForHour = new Point(_mouseX, _mouseY);
                    _hour = calcHour(tempAngle);
                    break;

                case MouseButtons.Right:
                    _pointForMinute = new Point(_mouseX, _mouseY);
                    _minute = calcMinute(tempAngle);
                    break;

                case MouseButtons.Middle:
                    _pointForHour = _pointForMinute = new Point(0, 0);
                    break;
            }

            _timeInString.Text = "Hours:\r\n" + _hour.ToString() + "\r\nMinutes: \r\n" + _minute.ToString();

            _pictureBoxForClock.Refresh();
        }

        // Найти угол относительно координатной оси для определенной точки
        private double findAngle(Point point)
        {
            float xDiff = _pictureBoxForClock.Width / 2 - point.X;
            float yDiff = _pictureBoxForClock.Height / 2 - point.Y;

            return Math.Atan2(yDiff, xDiff);
        }

        // Высчитываем из найденного угла часы
        private int calcHour(int angle)
        {
            int tempHour = angle / 30 + 3;
            if (tempHour >= 12) { tempHour -= 12; }

            return tempHour + _dayTime;
        }

        // Высчитываем из найденного угла минуты
        private int calcMinute(int angle)
        {
            int tempMinute = (angle / 30 + 3) * 5;
            if ((tempMinute - 12) * 5 >= 240) { tempMinute -= 60; }

            return tempMinute;
        }

        // Отрисовка _pictureBoxForClock
        private void _pictureBoxForClock_Paint(object sender, PaintEventArgs e)
        {
            // Битмап, где хранится все
            Bitmap _clock;
            _clock = new Bitmap(_pictureBoxForClock.Width, _pictureBoxForClock.Height);

            var gForPicturebox = e.Graphics;
            Graphics gForBitmap = Graphics.FromImage(_clock);
            Pen pen = new Pen(Color.Black, 3);

            // Длина стрелки
            int lineWidht = (_pictureBoxForClock.Width - _pictureBoxForClock.Width / 4) / 2;
            int lineHeight = (_pictureBoxForClock.Height - _pictureBoxForClock.Height / 4) / 2;

            // Элипс 
            gForBitmap.DrawEllipse(pen, new Rectangle(_pictureBoxForClock.Width / 8,
                                             _pictureBoxForClock.Height / 8,
                                             _pictureBoxForClock.Width - _pictureBoxForClock.Width / 4,
                                             _pictureBoxForClock.Height - _pictureBoxForClock.Height / 4));

            // Угол поворота
            double rotDegrees = findAngle(new Point(_mouseX, _mouseY)) + Math.PI;

            // Начальная точка
            Point startPoint = new Point(_pictureBoxForClock.Width / 2, _pictureBoxForClock.Height / 2);

            // Часовая стрелка
            e.Graphics.DrawLine(new Pen(Color.Red, 3), startPoint,
                new Point((int)(_pictureBoxForClock.Width / 2 + Math.Cos(findAngle(_pointForHour) + Math.PI) * lineWidht),
                          (int)(_pictureBoxForClock.Height / 2 + Math.Sin(findAngle(_pointForHour) + Math.PI) * lineHeight)));

            // Минутная стрелка
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), startPoint,
                new Point((int)(_pictureBoxForClock.Width / 2 + Math.Cos(findAngle(_pointForMinute) + Math.PI) * lineWidht),
                          (int)(_pictureBoxForClock.Height / 2 + Math.Sin(findAngle(_pointForMinute) + Math.PI) * lineHeight)));

            gForBitmap.Dispose();
            gForPicturebox.DrawImage(_clock, 0, 0);
        }
    }
}
