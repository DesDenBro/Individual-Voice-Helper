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
        private DateTime _timeToGetNotify;
        private bool _notifyGot = false;

        // Свойства переменных
        public int ID { get { return _ID; } }
        public string Name { get { return _name; } set { _name = value; } }
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
        public DateTime TimeToGetNotify { get { return _timeToGetNotify; } set { _timeToGetNotify = value; } }
        public bool NotifyGot { get { return _notifyGot; } set { _notifyGot = value; } }

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
                     DateTime timeToGetNotify,
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
                _timeToGetNotify = timeToGetNotify;
                // Сработало ли оповещение
                _notifyGot = notifyGot;               
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
                _timeToGetNotify = timeToGetNotify;   
                _notifyGot = notifyGot;                     
            }
            catch { }
        }

    }

}
