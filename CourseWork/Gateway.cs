using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace CourseWork
{
    class CannotReadTableExeption : Exception
    {
        public CannotReadTableExeption() { }
        public CannotReadTableExeption(string message)
            : base(message)
        { }
        public CannotReadTableExeption(string message, Exception inner)
            : base(message, inner)
        { }
    }

    public class Gateway
    {
        #region --- Главные переменные --- 

        // Главный адаптер, связь с БД.
        private static SqlDataAdapter _dataAdapter = null;

        // Переменная связи с БД.
        private static SqlConnection _connection = null;

        // Команда для CRUD. 
        private static SqlCommand _command = null;

        // Чтение данных по выбранному запросу.
        private static SqlDataReader _dataReader = null;   

        #endregion


        #region --- Подключение к БД и общие методы ---

        // Прописываем подключение к БД к определенной таблице.
        private static void createConnectionToDB(string neededTable)
        {
            // Иницилизируем нужные эелементы для работы с БД (строка связи, комманд и адаптер)
            _connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
               AppDomain.CurrentDomain.BaseDirectory + "MainDB.mdf" +
               ";Integrated Security=True");

            _dataAdapter = new SqlDataAdapter();
            _command = _connection.CreateCommand();
            _command.CommandText = "select * from ["+ neededTable + "]";
            _dataAdapter.SelectCommand = _command;

            // Команды для добавления и редактирования строк БД
            SqlCommandBuilder cb = new SqlCommandBuilder(_dataAdapter);
            _dataAdapter.InsertCommand = cb.GetInsertCommand();
            _dataAdapter.UpdateCommand = cb.GetUpdateCommand();
            _dataAdapter.DeleteCommand = cb.GetDeleteCommand();
        }

        // Открыть соединение с БД.
        private static void openConnectionToTable(string tableName)
        {
            createConnectionToDB(tableName);
            _connection.Open();
        }

        // Закрыть соединение с БД.
        private static void closeConnectionToTable()
        {
            if (_dataReader != null) _dataReader.Close();
            _connection.Close();
        }

        // Прочесть данные из таблицы.
        private static void readTable()
        {
            try {
                _dataReader = _command.ExecuteReader();
            } catch (Exception ex) {
                throw new CannotReadTableExeption("Command did not write", ex); }
        }

        // Заполнение DataSet старыми данными для редкатирования или добавления.
        private static void fillDataInDataset(out DataSet oldData, out DataRow dr)
        {
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData); // Загружаем старый образ
        }

        // Получить количество строк в таблице.
        public static int getCountOfTableRows(string tableName)
        {
            openConnectionToTable(tableName);

            int count = (int)(new SqlCommand(string.Format("SELECT COUNT(*) FROM [{0}];", tableName), _connection).ExecuteScalar());

            closeConnectionToTable();

            return count;
        }

        // Получить максимальный индекс в таблице.
        public static int getLastIndexInTable(string tableName)
        {
            openConnectionToTable(tableName);

            int count = (int)(new SqlCommand(string.Format("SELECT TOP 1 [Id] FROM [{0}] order by Id desc", tableName), _connection).ExecuteScalar());

            closeConnectionToTable();

            return count;   
        }

        #endregion


        #region --- Методы для Event ---

        public static void loadEventFromDB(out List<Event> eventList)
        {
            eventList = new List<Event>();
            openConnectionToTable("Event");
            readTable();

            while (_dataReader.Read())
            {
                if (Convert.ToInt32(_dataReader["UserID"]) == User.GetUser().UserID)
                {
                    eventList.Add(new Event(
                        Convert.ToInt32(_dataReader["InnerID"]),                              // ID
                        _dataReader["Name"].ToString().Trim(),                                // Name
                        _dataReader["Text"].ToString().Trim(),                                // Text
                        Convert.ToDateTime(_dataReader["Date"]),                              // Date
                        Convert.ToBoolean(_dataReader["IsHappened"].ToString().Trim()),       // IsHappened
                        _dataReader["IsHappenedNote"].ToString().Trim(),                      // IsHappenedNote
                        Convert.ToBoolean(_dataReader["IsCanceled"].ToString().Trim()),       // IsCanceled
                        _dataReader["IsCanceledReason"].ToString().Trim(),                    // IsCanceledReason
                        Convert.ToDateTime(_dataReader["NotificationDateTime"]),                   // TimeToGetNotify
                        Convert.ToBoolean(_dataReader["NotificationGot"].ToString().Trim())         // NotifyGot
                        )); 
                }
            }

            closeConnectionToTable();
        }

        public static void addEventInDB(Event eventForAdd, int countInEventList)
        {
            int countOfAllEvents = getCountOfTableRows("Event");

            openConnectionToTable("Event");

            // Сет под старый образ таблицы
            DataSet oldData;
            // Память под новую строку
            DataRow dr;       
            fillDataInDataset(out oldData, out dr);
            dr = oldData.Tables[0].NewRow(); // Новая строка
            dr["ID"] = countOfAllEvents;
            dr["UserID"] = User.GetUser().UserID;
            dr["InnerID"] = eventForAdd.ID;
            dr["Name"] = eventForAdd.Name;
            dr["Text"] = eventForAdd.Text;
            dr["Date"] = eventForAdd.Date;
            dr["IsHappened"] = eventForAdd.IsHappened.ToString();
            dr["IsHappenedNote"] = eventForAdd.IsHappenedNote;
            dr["IsCanceled"] = eventForAdd.IsCanceled.ToString();
            dr["IsCanceledReason"] = eventForAdd.IsCanceledReason;
            dr["NotificationDateTime"] = eventForAdd.NotificationDateTime;
            dr["NotificationGot"] = eventForAdd.NotificationGot.ToString();
            // Загрузка строки в старый образ
            oldData.Tables[0].Rows.Add(dr);
            // Загрузка в основную БД 
            _dataAdapter.Update(oldData); 

            closeConnectionToTable();
        }

        public static void updateEventInDB(Event eventForEdit)
        {
            openConnectionToTable("Event");

            DataSet oldData;
            DataRow dr;
            fillDataInDataset(out oldData, out dr);
            DataRow[] tempdata = oldData.Tables[0].AsEnumerable().Where(p => p["UserID"].ToString() == User.GetUser().UserID.ToString()).ToArray();
            int i = 0;
            while (i < tempdata.Length)
            {
                dr = tempdata[i];
                if (dr["InnerID"].ToString() == eventForEdit.ID.ToString())
                {
                    dr["Name"] = eventForEdit.Name;
                    dr["Text"] = eventForEdit.Text;
                    dr["Date"] = eventForEdit.Date;
                    dr["IsHappened"] = eventForEdit.IsHappened.ToString();
                    dr["IsHappenedNote"] = eventForEdit.IsHappenedNote;
                    dr["IsCanceled"] = eventForEdit.IsCanceled.ToString();
                    dr["IsCanceledReason"] = eventForEdit.IsCanceledReason;
                    dr["NotificationDateTime"] = eventForEdit.NotificationDateTime;
                    dr["NotificationGot"] = eventForEdit.NotificationGot.ToString();
                    break;
                }
                i++;
            }
            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        #endregion


        #region --- Методы для User ---

        public static void checkUser(ref bool access, ref int userID, string wroteLogin, string wrotePass)
        {
            openConnectionToTable("User");
            readTable();

            while (_dataReader.Read())
            {
                if (_dataReader["Login"].ToString().Trim() == wroteLogin)
                {
                    if (PasswordStorage.VerifyPassword(wrotePass, _dataReader["Password"].ToString().Trim()))
                    {
                        access = true;
                        userID = Convert.ToInt32(_dataReader["ID"]);
                    }
                }
            }

            closeConnectionToTable();
        }

        public static void addNewUserInDB(string newLogin, string newPass)
        {
            int newUserID = getCountOfTableRows("User");

            openConnectionToTable("User");

            DataSet oldData; 
            DataRow dr;      
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData); 
            dr = oldData.Tables[0].NewRow();
            dr["ID"] = newUserID;
            dr["Login"] = newLogin;
            dr["Password"] = newPass;
            oldData.Tables[0].Rows.Add(dr); 
            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        #endregion


        #region --- Методы для AI ---

        public static void loadAIForUser(ref AI AIForChoosenUser, int userID)
        {
            int AIID = -1; bool sex = false;

            openConnectionToTable("AI");
            readTable();

            while (_dataReader.Read())
            {
                if (Convert.ToInt32(_dataReader["UserID"]) == userID)
                {
                    sex = Convert.ToBoolean(_dataReader["Sex"].ToString().Trim());
                    AIID = Convert.ToInt32(_dataReader["ID"]);
                }
            }

            if (AIID != -1) AIForChoosenUser = new AI(AIID, loadAINames(AIID), sex);

            closeConnectionToTable();
        }

        public static void addNewAIInDB(AI addedAI)
        {
            int userID = getCountOfTableRows("User") - 1;

            openConnectionToTable("AI");

            DataSet oldData;  
            DataRow dr;        
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData); 
            dr = oldData.Tables[0].NewRow();
            dr["ID"] = addedAI.ID;
            dr["UserID"] = userID;
            dr["Sex"] = addedAI.Sex.ToString();
            oldData.Tables[0].Rows.Add(dr); 
            _dataAdapter.Update(oldData);

            closeConnectionToTable();

            addNewNamesAIInDB(addedAI.ID, addedAI.Names);
        }

        public static List<string> loadAINames(int AIId)
        {
            List<string> names = new List<string>();

            openConnectionToTable("AIName");
            readTable();

            while (_dataReader.Read())
            {
                if (Convert.ToInt32(_dataReader["AIID"]) == AIId)
                {
                    names.Add(_dataReader["Name"].ToString().Trim());
                }
            }

            closeConnectionToTable();

            return names;
        }

        public static void addNewNamesAIInDB(int AIID, List<string> names)
        {
            int nameID = getCountOfTableRows("AIName");

            openConnectionToTable("AIName");

            DataSet oldData;   
            DataRow dr;       
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData); 
            for (int i = 0; i < names.Count; i++)
            {
                dr = oldData.Tables[0].NewRow(); 
                dr["ID"] = nameID + i;
                dr["AIID"] = AIID;
                dr["Name"] = names[i];
                oldData.Tables[0].Rows.Add(dr);
            }
            _dataAdapter.Update(oldData); 

            closeConnectionToTable();
        }

        #endregion


        #region --- Методы для Bookmark ---

        public static List<Bookmark> loadBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>();

            openConnectionToTable("Bookmark");
            readTable();

            while (_dataReader.Read())
            {
                if (Convert.ToInt32(_dataReader["UserID"]) == User.GetUser().UserID)
                {
                    bookmarks.Add(new Bookmark(_dataReader["Name"].ToString(), _dataReader["Link"].ToString()));
                }
            }

            closeConnectionToTable();

            return bookmarks;
        }

        public static void addNewBookmarksInDB(List<Bookmark> bookmarks)
        {
            // Сколько там строк в таблице?
            int numberOfRows = 0;
            if (getCountOfTableRows("Bookmark") > 0) numberOfRows = getLastIndexInTable("Bookmark") + 1;

            openConnectionToTable("Bookmark");

            DataSet oldData;   
            DataRow dr;        
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData); 
            for (int i = 0; i < bookmarks.Count; i++)
            {
                dr = oldData.Tables[0].NewRow();
                dr["ID"] = numberOfRows + i;
                dr["UserID"] = User.GetUser().UserID;
                dr["Name"] = bookmarks[i].Name.ToString();
                dr["Link"] = bookmarks[i].Link.ToString();
                oldData.Tables[0].Rows.Add(dr); 
            }
            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        public static void updateBookmarkInDB(Bookmark bookmark)
        {
            openConnectionToTable("Bookmark");

            DataSet oldData;
            DataRow dr;
            fillDataInDataset(out oldData, out dr);
            DataRow[] tempdata = oldData.Tables[0].AsEnumerable().Where(p => p["UserID"].ToString() == User.GetUser().UserID.ToString()).ToArray();
            int i = 0;
            while (i < tempdata.Length)
            {
                dr = tempdata[i];
                if (dr["Name"].ToString().Trim() == bookmark.Name.ToString())
                {
                    dr["Link"] = bookmark.Link;
                    break;
                }
                i++;
            }
            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        public static void deleteBookmarkFromDB(Bookmark bookmark)
        {
            openConnectionToTable("Bookmark");

            DataSet oldData;
            DataRow dr;
            fillDataInDataset(out oldData, out dr);
            DataRow[] tempdata = oldData.Tables[0].AsEnumerable().Where(p => p["Name"].ToString().Trim() == bookmark.Name.ToString()).ToArray();
            if (tempdata.Length > 0)
            {
                dr = tempdata[0];
                dr.Delete();
            }

            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        #endregion


        #region --- Методы для Program ---

        public static List<ComputerProgram> loadPrograms()
        {
            List<ComputerProgram> programs = new List<ComputerProgram>();

            openConnectionToTable("Program");
            readTable();

            while (_dataReader.Read())
            {
                if (Convert.ToInt32(_dataReader["UserID"]) == User.GetUser().UserID)
                {
                    programs.Add(new ComputerProgram(_dataReader["Name"].ToString(), _dataReader["Path"].ToString()));
                }
            }

            closeConnectionToTable();

            return programs;
        }

        public static void addNewProgramInDB(ComputerProgram program)
        {
            int numberOfRows = 0;

            if (getCountOfTableRows("Program") > 0)
                numberOfRows = getLastIndexInTable("Program") + 1;

            openConnectionToTable("Program");

            DataSet oldData;                        
            DataRow dr;                             
            oldData = new DataSet();
            dr = null;
            _dataAdapter.Fill(oldData);             
            dr = oldData.Tables[0].NewRow();       
            dr["ID"] = numberOfRows;
            dr["UserID"] = User.GetUser().UserID;
            dr["Name"] = program.Name.ToString();
            dr["Path"] = program.Path.ToString();
            oldData.Tables[0].Rows.Add(dr);         
            _dataAdapter.Update(oldData);           

            closeConnectionToTable();
        }

        public static void deleteProgramFromDB(ComputerProgram program)
        {
            openConnectionToTable("Program");

            DataSet oldData;
            DataRow dr;
            fillDataInDataset(out oldData, out dr);
            DataRow[] tempdata = oldData.Tables[0].AsEnumerable().Where(p => p["Name"].ToString().Trim() == program.Name.ToString()).ToArray();
            if (tempdata.Length > 0)
            {
                dr = tempdata[0];
                dr.Delete();
            }

            _dataAdapter.Update(oldData);

            closeConnectionToTable();
        }

        #endregion
    }
}
