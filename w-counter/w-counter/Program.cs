using System;
using System.Linq;

namespace w_counter
{
    static class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = new Path();
            inputFilePath.SetPathFromConsole("Введите путь входного файла: ", true);
            var outputFilePath = new Path();
            outputFilePath.SetPathFromConsole("Введите путь выходного файла: ");
            foreach(var item in FileReader.ReadFromFile(inputFilePath.GetPath()).OrderByDescending(item => item.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
