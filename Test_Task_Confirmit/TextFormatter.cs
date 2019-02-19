using System;
using System.Linq;

namespace Test_Task_Confirmit
{
    public class TextFormatter
    {
        private string result;
        private string[] words;

        public string Justify(string text, int width)
        {
            words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            result = string.Empty;
            var pos = 0;
            var pos_prev = 0;

            while (pos < words.Length)
            {
                var rowLength = 0; //length of current row

                do
                {
                    rowLength += words[pos++].Length + 1; // plus space
                } while (pos < words.Length && rowLength + words[pos].Length <= width);

                rowLength--; //take away the last space

                if (pos != words.Length)
                {
                    addLine(pos, pos_prev, width, rowLength);
                    pos_prev = pos;
                }
            }

            for (int j = pos_prev; j < words.Length; j++) // adding the last line
            {
                result += words[j];
                result += (words[j] != words[words.Length - 1]) ? " " : string.Empty;
            }
            return result;
        }

        private void addLine(int pos, int pos_prev, int width, int rowLength)
        {
            var wordsCount = pos - pos_prev;
            var spacesInRowCount = wordsCount - 1;
            var singleSpacesCount = spacesInRowCount + width - rowLength; // cumulative number of spaces for current string

            for (var j = 0; j < wordsCount; j++)
            {
                result += words[pos_prev + j];

                if (j < spacesInRowCount)
                {
                    result += string.Concat(Enumerable.Repeat(" ", singleSpacesCount / spacesInRowCount));

                    if (j < singleSpacesCount % spacesInRowCount)
                    {
                        result += ' ';
                    }
                }
            }
            result += '\n';
        }
    }
}