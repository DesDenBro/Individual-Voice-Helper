using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public static class TranslitWord
    {
        private static Dictionary<string, string> transliter;

        private static void prepareTranslit()
        {
            if (transliter == null)
            {
                transliter = new Dictionary<string, string>();
                transliter.Add("а", "a");
                transliter.Add("б", "b");
                transliter.Add("в", "v");
                transliter.Add("г", "g");
                transliter.Add("д", "d");
                transliter.Add("е", "e");
                transliter.Add("ё", "yo");
                transliter.Add("ж", "zh");
                transliter.Add("з", "z");
                transliter.Add("и", "i");
                transliter.Add("й", "j");
                transliter.Add("к", "k");
                transliter.Add("л", "l");
                transliter.Add("м", "m");
                transliter.Add("н", "n");
                transliter.Add("о", "o");
                transliter.Add("п", "p");
                transliter.Add("р", "r");
                transliter.Add("с", "s");
                transliter.Add("т", "t");
                transliter.Add("у", "u");
                transliter.Add("ф", "f");
                transliter.Add("х", "h");
                transliter.Add("ц", "c");
                transliter.Add("ч", "ch");
                transliter.Add("ш", "sh");
                transliter.Add("щ", "sch");
                transliter.Add("ъ", "j");
                transliter.Add("ы", "i");
                transliter.Add("ь", "j");
                transliter.Add("э", "e");
                transliter.Add("ю", "yu");
                transliter.Add("я", "ya");

                transliter.Add("a", "a");
                transliter.Add("b", "b");
                transliter.Add("c", "c");
                transliter.Add("d", "d");
                transliter.Add("e", "e");
                transliter.Add("f", "f");
                transliter.Add("g", "g");
                transliter.Add("h", "h");
                transliter.Add("i", "i");
                transliter.Add("j", "j");
                transliter.Add("k", "k");
                transliter.Add("l", "l");
                transliter.Add("m", "m");
                transliter.Add("n", "n");
                transliter.Add("o", "o");
                transliter.Add("p", "p");
                transliter.Add("q", "q");
                transliter.Add("r", "r");
                transliter.Add("s", "s");
                transliter.Add("t", "t");
                transliter.Add("u", "u");
                transliter.Add("v", "v");
                transliter.Add("w", "w");
                transliter.Add("x", "x");
                transliter.Add("y", "y");
                transliter.Add("z", "z");

                transliter.Add("@", "a");
                transliter.Add("#", " # ");
                transliter.Add("+", " + ");
                transliter.Add("&", " and ");
                transliter.Add("-", " ");

                transliter.Add(" ", " ");

                for (int i = 0; i < 10; i++) transliter.Add(i.ToString(), " " + i.ToString() + " ");
            }
        }

        public static string GetTranslit(string sourceText)
        {
            prepareTranslit();

            StringBuilder ans = new StringBuilder();
            string lowerText = sourceText.Trim().ToLower();

            try
            {
                for (int i = 0; i < lowerText.Length; i++)
                {
                    if (transliter.ContainsKey(lowerText[i].ToString()))
                    {
                        if (ans.Length == 0)
                            ans.Append(transliter[lowerText[i].ToString()]);
                        else
                            if (ans.Length > 0)
                            if (lowerText[i] != ' ' || (ans[ans.Length - 1] != ' ' && lowerText[i] == ' '))
                                ans.Append(transliter[lowerText[i].ToString()]);
                    }
                }
            }
            catch { }

            StringBuilder clearAns = new StringBuilder();
            var temp = ans.ToString().Split(' ');
            foreach (var item in temp)
            {
                if (item != "") clearAns.Append(item + " ");
            }

            return clearAns.ToString().Trim();
        }
    }
}
