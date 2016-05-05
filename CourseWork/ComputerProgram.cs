using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ComputerProgram
    {
        private string _name;
        private string _path;

        public string Name { get { return _name; } }
        public string Path { get { return _path; } set { _path = value.Trim(); } }

        public ComputerProgram(string name, string path)
        {
            _name = TranslitWord.GetTranslit(name);
            _path = path.Trim();
        } 

    }
}
