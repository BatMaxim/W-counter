using System;

namespace w_counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = new Path();
            inputFilePath.SetPathFromConsole("Введите путь до начального файла: ", true);
            Console.WriteLine(inputFilePath.GetPath());
        }
    }
}
