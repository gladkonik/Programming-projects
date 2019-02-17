using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_Task_Confirmit
{
    public class TextFormatter
    {
        public string Justify(string text, int width)
        {
            string test = "Hell low";
            string[] myColors = test.Split(' ');

            foreach (string color in myColors)
            {
                System.Console.WriteLine(color);
            }
            return "";
        }
        public string[] DeriveWord(string text)
        {
            //string test = " Hell   low ";
            char[] separators = { ' ' };
            return text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //            System.Console.WriteLine(@"You can put a backslash \ here
            //and a new line
            //and tabs			work too. 
            //You can also put in sequences that would normally be seen as escape sequences \n \t");
            //        }
            string test = " Hell   low world";
            int len = 30;
            char[] separators = { ' ' };
            string[] words = test.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string color in words)
            //{
            //    System.Console.WriteLine(color);
            //}

            string result = "";
            int pos = 0;
            int pos_prev = 0;
            for (int i = 0; ; i++)
            {
                int l = 0; //length of current row
                while (true) { 
                    l += words[pos++].Length;
                    if (l + words[pos].Length >= len)
                        break;
                    l++; //space
                }
                int n_words = pos - pos_prev;
                int to_fill = len - l;
                int n_spaces = to_fill / n_words;
                for (int j = 0; j < n_words; j++)
                {
                    result += n_words;
                    if (j + 1 < n_words) {
                        string.Concat(Enumerable.Repeat(" ", n_spaces / n_words));
                        if (j < n_spaces % n_words)
                            result += ' ';
                    }
                    else
                        result += '\n';
                }
            }
        }
    }
}
