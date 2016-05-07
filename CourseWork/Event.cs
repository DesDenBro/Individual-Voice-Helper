using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Event
    {
        // Переменные
        private int _ID;
        private string _name;
        private string _transliterationName;
        private string _text;
        private DateTime _date;
        private bool _isHappened = false;
        private string _isHappenedNote;
        private bool _isCanceled = false;
        private string _isCanceledReason;
        private DateTime _notificationDateTime;
        private bool _notificationGot = false;

        // Свойства переменных
        public int ID { get { return _ID; } }
        public string Name { get { return _name; } set { _name = value; _transliterationName = TranslitWord.GetTranslit(_name); } }
        public string TranslitirationName { get { return _transliterationName; } }
        public string Text { get { return _text; } set { _text = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public bool IsHappened  { get { return _isHappened; } }
        public string IsHappenedNote
        {
            get { return _isHappenedNote; }
            set { if (_isHappened) _isHappenedNote = value; }
        }
        public bool IsCanceled { get { return _isCanceled; } }
        public string IsCanceledReason
        {
            get { return _isCanceledReason; }
            set { if (_isCanceled) _isCanceledReason = value; }
        }
        public DateTime NotificationDateTime { get { return _notificationDateTime; } set { _notificationDateTime = value; } }
        public bool NotificationGot { get { return _notificationGot; } set { _notificationGot = value; } }

        // Отдельные методы
        public bool setEventIsHappenedTrue()
        {
            if (_isCanceled)
            {
                return false;
            }
            else
            {
                _isHappened = true;
                return true;
            }
        }

        public bool setEventIsCanceledTrue()
        {
            if (_isHappened)
            {
                return false;
            }
            else
            {
                _isCanceled = true;
                return true;
            }
        }

        // Конструктор для загрузки данных
        public Event(int id, 
                     string name, 
                     string text, 
                     DateTime date,
                     bool isHappend,
                     string isHappenedNote,
                     bool isCanceled,
                     string isCanceledReason,
                     DateTime notificationDateTime,
                     bool notifyGot)
        {
            try
            {
                // Индекс позволяет отследить код события, записанный в БД
                this._ID = id;

                // Имя события, которое кратко излагает суть
                _name = name; 
                // Имя события в транслите без лишних символов                        
                _transliterationName = TranslitWord.GetTranslit(name);
                // Подробное описание события
                _text = text;
                // Дата проведения события                     
                _date = date;

                // Установка, было ли событие проведено 
                _isHappened = isHappend;
                // Запись о том, как прошло событие       
                _isHappenedNote = isHappenedNote;

                // Установка, было ли событие отменено
                _isCanceled = isCanceled;
                // Запись, объясняющая причину отмены события
                _isCanceledReason = isCanceledReason;

                // Время, во сколько должно сработать оповещение
                _notificationDateTime = notificationDateTime;
                // Сработало ли оповещение
                _notificationGot = notifyGot;               
            }
            catch { }
        }

        // Общий конструктор
        public Event(int id,
                     string name,
                     string text,
                     DateTime date,
                     DateTime timeToGetNotify,
                     bool notifyGot)
        {
            try
            {
                this._ID = id;                               
                _name = name;
                _transliterationName = TranslitWord.GetTranslit(name);                     
                _text = text;                         
                _date = date;
                _notificationDateTime = timeToGetNotify;   
                _notificationGot = notifyGot;                     
            }
            catch { }
        }

    }

}
