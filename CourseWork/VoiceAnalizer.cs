using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace CourseWork
{
    class VoiceAnalizer
    {
        #region --- Главные переменные и свойства ---

        private static VoiceAnalizer _reference;

        private SpeechSynthesizer _speech = new SpeechSynthesizer();
        private SpeechRecognitionEngine _recongnition = new SpeechRecognitionEngine();
        private string _userCommand = "";
        private string _elaborationToUserCommand = "";
        private List<Bookmark> _bookmarks = new List<Bookmark>();
        private List<ComputerProgram> _programs = new List<ComputerProgram>();

        private Choices _names = new Choices();
        private Choices _commands = new Choices();
        private Choices _objects = new Choices();

        public enum State { ListenAll, ListenForSet }
        private State _state = State.ListenAll;
        public State VAState { get { return _state; } }

        public string UserCommand { get { return _userCommand; } }
        public List<Bookmark> Bookmarks { get { return _bookmarks; } set { _bookmarks = value; } }
        public List<ComputerProgram> Programs { get { return _programs; } set { _programs = value; } }

        #endregion


        #region --- Методы для иницилизации и загрузки ---

        // Первоначальный вызов коструктора
        public static VoiceAnalizer createVoiceAnalizer(AI userAI)
        {
            if (_reference == null)
                _reference = new VoiceAnalizer(userAI);
            return _reference;
        }

        // Последующие вызовы
        public static VoiceAnalizer getVoiceAnalizer()
        {
            return _reference;
        }

        // Отчищаем _userCommand
        public void clearUserCommand()
        {
            _userCommand = "";
        }

        // Первоначальные настроки при создании анализатора
        protected VoiceAnalizer(AI userAI)
        {
            setDefaultRecordDevice();

            _names = new Choices(userAI.Names.ToArray());
            loadBookmarksForThisUser();
            createMainGrammars();

            _recongnition.SpeechRecognized += Rec_SpeechRecognized;
            _recongnition.SpeechHypothesized += Rec_SpeechHypothesized;
            _recongnition.RecognizeAsync(RecognizeMode.Multiple);

            if (userAI.Sex == true)
                _speech.SelectVoiceByHints(VoiceGender.Male);
            else
                _speech.SelectVoiceByHints(VoiceGender.Female);
        }

        // Создание грамматик
        private void createMainGrammars()
        {
            _commands = new Choices(new string[] { "show", "open", "create", "edit", "set" });
            _objects = new Choices(new string[] 
            { "commands", "event", "a new event",
                "event name", "event text", "event time", "notify time", "event date", "event notify date" });

            for (int i = 0; i < _bookmarks.Count; i++)
                if (_bookmarks[i].Name != "")
                    _objects.Add(_bookmarks[i].Name);

            for (int i = 0; i < _programs.Count; i++)
                if (_programs[i].Name != "")
                    _objects.Add(_programs[i].Name);

            for (int i = 0; i < User.GetUser().EventList.Count; i++)
                    _objects.Add("event " + TranslitWord.GetTranslit(User.GetUser().EventList[i].Name));

            GrammarBuilder speech = new GrammarBuilder();
            speech.Append(_names);
            speech.Append(_commands);
            speech.Append(_objects);

            _recongnition.LoadGrammar(new DictationGrammar());
            _recongnition.LoadGrammar(new Grammar(speech));
        }

        // Грамматика для распознования времени
        private void createTimeGrammar()
        {
            Choices hours = new Choices();
            Choices minutes = new Choices();

            for (int i = 0; i < 60; i++)
            {
                if (i < 24) { hours.Add(i.ToString()); }
                minutes.Add(i.ToString());
            }

            GrammarBuilder speech = new GrammarBuilder();
            speech.Append(hours);
            speech.Append(minutes);

            _recongnition.LoadGrammar(new Grammar(speech));
        }

        // Грамматика для распознования даты
        private void createDateGrammar()
        {
            Choices day = new Choices();
            Choices month = new Choices(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            Choices year = new Choices(new string[] { " " } );

            for (int i = 0; i < 31; i++)
            {
                if (i < 12) { month.Add(i.ToString()); year.Add((DateTime.Now.Year + i).ToString()); }
                day.Add(i.ToString());
            }

            GrammarBuilder speech = new GrammarBuilder();
            speech.Append(day);
            speech.Append(month);
            speech.Append(year);

            _recongnition.LoadGrammar(new Grammar(speech));
        }

        // Загрузка закладок браузера
        private void loadBookmarksForThisUser()
        {
            _bookmarks = Gateway.loadBookmarks();
        }

        // Загрузка программ для пользователя
        private void loadProgramsForThisUser()
        {
            _programs = Gateway.loadPrograms();
        }

        // Установить соединение с микрофоном
        public void setDefaultRecordDevice()
        {
            _recongnition.RequestRecognizerUpdate();
            _recongnition.SetInputToDefaultAudioDevice();
        }

        // Обновить грамматику
        public void refreshGrammar()
        {
            _recongnition.UnloadAllGrammars();
            createMainGrammars();
        }
        #endregion


        #region --- Обработка голоса ---

        private void Rec_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            _userCommand = e.Result.Text;
        }

        private void Rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string command = e.Result.Text;
            if (_state == State.ListenForSet)
            {
                _userCommand = _elaborationToUserCommand + command;
                _state = State.ListenAll;
                refreshGrammar();
                return;
            }

            string[] parts = command.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "open" || parts[i] == "show")
                {
                    if (parts[i + 1] == "commands")
                    { CommandListForm clf = new CommandListForm(); clf.ShowDialog(); return; }
                    OpenCommand(parts, i + 1); return;
                }

                if (parts[i] == "create")
                { AddCommand(parts, i + 1); return; }

                if (parts[i] == "edit")
                { EditCommand(parts, i + 1); return; }

                if (parts[i] == "set")
                { SetCommand(parts, i + 1); return; }
            }
        }

        private void OpenCommand(string[] parts, int startIDForReadParts)
        {
            foreach (var item in _bookmarks)
            {
                string fullWord = "";
                for (int i = 0; i < item.Name.Split(' ').Length; i++)
                {
                    if (startIDForReadParts + i >= parts.Length) break;
                    else fullWord += parts[startIDForReadParts + i] + " ";
                }

                if (fullWord.Trim() == item.Name.Trim())
                {
                    Process.Start(item.Link);
                    return;
                }
            }

            foreach (var item in _programs)
            {
                string fullWord = "";
                for (int i = 0; i < item.Name.Split(' ').Length; i++)
                {
                    if (startIDForReadParts + i >= parts.Length) break;
                    else fullWord += parts[startIDForReadParts + i] + " ";
                }

                if (fullWord.Trim() == item.Name.Trim())
                {
                    Process.Start(item.Path);
                    return;
                }
            }

            if (parts[startIDForReadParts] == "event")
            {
                foreach (var item in User.GetUser().EventList)
                {
                    string fullWord = "";
                    for (int i = 0; i < item.Name.Split(' ').Length; i++)
                    {
                        if (startIDForReadParts + 1 + i >= parts.Length) break;
                        else fullWord += parts[startIDForReadParts + 1 + i] + " ";
                    }

                    if (fullWord.Trim() == item.Name.Trim())
                    {
                        _userCommand = "open/event/" + item.ID;
                    }
                }
            }
        }

        private void AddCommand(string[] parts, int startIDForReadParts)
        {
            string fullWord = "";
            for (int i = startIDForReadParts; i < parts.Length; i++)
            {
                fullWord += parts[i] + " ";
            }

            switch (fullWord.Trim())
            {
                case "a new event": 
                case "event":  _userCommand = "create/event"; break;

                default: break;
            }
        }

        private void EditCommand(string[] parts, int startIDForReadParts)
        {
            if (parts[startIDForReadParts] == "event")
            {
                foreach (var item in User.GetUser().EventList)
                {
                    string fullWord = "";
                    for (int i = 0; i < item.Name.Split(' ').Length; i++)
                    {
                        if (startIDForReadParts + 1 + i >= parts.Length) break;
                        else fullWord += parts[startIDForReadParts + 1 + i] + " ";
                    }

                    if (fullWord.Trim() == item.Name.Trim())
                    {
                        _userCommand = "edit/event/" + item.ID;
                    }
                }
            }
        }

        private void SetCommand(string[] parts, int startIDForReadParts)
        {
            string fullWord = "";
            for (int i = startIDForReadParts; i < parts.Length; i++)
            {
                fullWord += parts[i] + " ";
            }

            switch (fullWord.Trim())
            {
                case "event name":
                case "event text":
                    _elaborationToUserCommand = "set/" + fullWord.Trim() + "/";
                    _state = State.ListenForSet;
                    break;
                case "event time":
                case "notify time":
                    _elaborationToUserCommand = "set/" + fullWord.Trim() + "/";
                    _recongnition.UnloadAllGrammars();
                    createTimeGrammar();
                    _state = State.ListenForSet;
                    break;
                case "event date":
                case "event notify date":
                    _elaborationToUserCommand = "set/" + fullWord.Trim() + "/";
                    _recongnition.UnloadAllGrammars();
                    createDateGrammar();
                    _state = State.ListenForSet;
                    break;
            }
        }

        #endregion

    }
}
