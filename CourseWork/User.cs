using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class User
    {
        private static User _reference;
        private int _userID;
        private List<Event> _eventList;

        public int UserID { get { return _userID; } }
        public List<Event> EventList { get { return _eventList; } } 

        private User(int userID)
        {
            _userID = userID;
        }

        static public User GetUser(int userID)
        {
            if (_reference == null)
                _reference = new User(userID);

            return _reference;
        }

        public void SetEventList(List<Event> eventList)
        {
            if (_eventList == null) _eventList = eventList;
            else throw new Exception("List already created.");
        }

        public static User GetUser()
        {
            return _reference;
        }
    }
}
