using System;
using System.IO;
using System.Linq;

namespace Test_Task_Confirmit
{
    public class TextFormatter
    {
        public string Justify(string text, int width)
        {
            char[] separators = { ' ' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            int pos = 0;
            int pos_prev = 0;
            for (int i = 0; ; i++) {
                int len = 0; //length of current row
                while (pos < words.Length) {
                    if (len + words[pos].Length >= width) {
                        break;
                    }
                    len += words[pos++].Length;
                    len++; //space
                }
                len--; //take away the last space 
                if (pos == words.Length) {
                    for (int j = pos_prev; j < words.Length; j++) {
                        result += words[j];
                        result += (words[j] == words[words.Length - 1]) ? '\n' : ' ';
                    }
                    return result;
                }
                int n_words = pos - pos_prev;
                int n_spaces = n_words - 1 + width - len; // cumulative number of spaces for current string
                for (int j = 0; j < n_words; j++) {
                    result += words[pos_prev + j];
                    if (j + 1 < n_words) {
                        result += string.Concat(Enumerable.Repeat(" ", n_spaces / (n_words - 1)));
                        if (j < n_spaces % (n_words - 1)) {
                            result += ' ';
                        }
                    }
                    else {
                        result += '\n';
                        int lenght = result.Length;
                    }
                }
                pos_prev = pos;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../input.txt";

            // Delete the file if it doesn't exist.
            if (!File.Exists(path)) {
                System.Console.WriteLine("Input file not found.\n");
                return;
            }
            string text = System.IO.File.ReadAllText(path);
            //System.Console.WriteLine(text);
            //            System.Console.WriteLine(@"You can put a backslash \ here
            //and a new line
            //and tabs			work too. 
            //You can also put in sequences that would normally be seen as escape sequences \n \t");
            //        }
            TextFormatter format = new TextFormatter();
            path = @"../output.txt";
            System.IO.File.WriteAllText(path, format.Justify(text, 30));

        }
    }
}
