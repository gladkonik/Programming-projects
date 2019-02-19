using System;
using System.IO;
using System.Linq;

namespace Test_Task_Confirmit
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../input.txt";

            if (!File.Exists(path)) {
                System.Console.WriteLine("Input file not found.\n");
                return;
            }

            string text = System.IO.File.ReadAllText(path);
            TextFormatter format = new TextFormatter();
            path = @"../output.txt";
            System.IO.File.WriteAllText(path, format.Justify(text, 30));
        }
    }
}
