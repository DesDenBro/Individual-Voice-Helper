using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseWork
{
    public class Bookmark
    {
        private string _name;
        private string _link;

        public string Name { get { return _name; } }
        public string Link { get { return _link; } set { _link = value.Trim(); } }

        public Bookmark(string name, string link)
        {
            _name = TranslitWord.GetTranslit(name);
            _link = link.Trim();
        }
    }

    public abstract class AbstractBookmarkReader
    {
        protected List<Bookmark> _bookmarks;
        
        public abstract List<Bookmark> Parse();
    }

    public class BookmarksReaderChrome : AbstractBookmarkReader
    {
        public override List<Bookmark> Parse()
        {
            _bookmarks = new List<Bookmark>();

            string name = ""; bool readName = false;
            try
            {
                File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) +
                     @"\Google\Chrome\User Data\Default\Bookmarks").ToList().ForEach(s =>
                {
                    var arr = s.Trim().Split(' '); // Разделитель, до которого считываем.
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (readName) name += arr[i] + " ";

                        if (arr[i] == "\"name\":")
                        {
                            readName = true;
                        }
                        else if (arr[i] == "\"url\":")
                        {
                            string[] nameSplit = name.Split(',', '"');
                            name = "";
                            for (int j = 0; j < nameSplit.Length; j++) name += nameSplit[j];
                            _bookmarks.Add(new Bookmark(name, arr[i + 1]));
                            name = "";
                        }

                        if (arr[i] == "\"folder\"")
                        {
                            name = "";
                            readName = false;
                        }
                    }
                    readName = false;
                });
            }
            catch { }

            return _bookmarks;
        }
    }

    public class BookmarksReaderYandexBrowser : AbstractBookmarkReader
    {
        public override List<Bookmark> Parse()
        {
            _bookmarks = new List<Bookmark>();

            string name = ""; bool readName = false;
            try
            {
                File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) +
                     @"\Yandex\YandexBrowser\User Data\Default\Bookmarks").ToList().ForEach(s =>
                     {
                         var arr = s.Trim().Split(' '); //разделитель до которого считываем
                         for (int i = 0; i < arr.Length; i++)
                         {
                             if (readName) name += arr[i] + " ";

                             if (arr[i] == "\"name\":")
                             {
                                 readName = true;
                             }
                             else if (arr[i] == "\"url\":")
                             {
                                 string[] nameSplit = name.Split(',', '"');
                                 name = "";
                                 for (int j = 0; j < nameSplit.Length; j++) name += nameSplit[j];
                                 _bookmarks.Add(new Bookmark(name, arr[i + 1]));
                                 name = "";
                             }

                             if (arr[i] == "\"folder\"")
                             {
                                 name = "";
                                 readName = false;
                             }
                         }
                         readName = false;
                     });
            }
            catch { }

            return _bookmarks;
        }
    }
}
