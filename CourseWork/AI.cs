using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class AI
    {
        private int _ID;
        private List<string> _names;
        private bool _sex;
        
        public int ID { get { return _ID; } }
        public List<string> Names { get { return _names; } }
        public bool Sex { get { return _sex; } }

        public AI(int id, List<string> names, bool sex)
        {
            _ID = id;
            _names = names;
            _sex = sex;
        }

        public AI() { }

    }
}
